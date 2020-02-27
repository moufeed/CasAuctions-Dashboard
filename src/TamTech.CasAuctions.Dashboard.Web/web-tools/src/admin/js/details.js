//#region
const OUTBID = 1;
const ACTIVE = 2;
const CLOSE = 3;
const CANCEL = 4;
const WebSockets = [];
var lastOutbidTimeAgo = null;
let IsUTC = true;
const actual_timer = {};
const GetDays = distance => {
  return Math.floor(distance / (1000 * 60 * 60 * 24));
};
const GetHours = distance => {
  return Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
};
const GetMinutes = distance => {
  return Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
};
const GetSeconds = distance => {
  return Math.floor((distance % (1000 * 60)) / 1000);
};

const lastOutbidTemplate = outbid => {
  return `
 <li data-id="${outbid.id}">
  <picture>
      <img src="/Admin/img/auction.png" class="img-responsive" />
  </picture>
  <div class="outbid-info">
      <strong class="outbids-name">${outbid.pfn}</strong>
      <div>
          <span class="outbid-price"><strong class="price">${
            outbid.pr
          }</strong> <small class="currency"></small></span>
          <span class="outbid-date" id="OutbidDate">
              ${moment(outbid.d).fromNow()}
          </span>
      </div>
  </div>
  </li>
`;
};

const outbidTemplate = outbid => {
  return `
<li id="pr-${outbid.pid}">
    <picture>
        <img src="/Admin/img/auction.png" alt="" width="70">
    </picture>
    <div class="outbid-info">
        <strong class="outbids-name">${outbid.pfn}</strong>
        <div>
            <span class="outbid-price"><strong class="price">${
              outbid.pr
            }</strong> <small class="currency"></small></span>
            <span class="outbid-date">
                <strong class="utc ${IsUTC ? "" : "hidden"}"> ${moment(outbid.d)
    .utc()
    .format("DD/MM/YYYY -  kk:mm:ss a")} (<small>UTC</small>)</strong>
                <strong class="local ${IsUTC ? "hidden" : ""}">${moment(
    outbid.d
  ).format("DD/MM/YYYY - kk:mm:ss a")}(<small>local</small>)</strong>
            </span>
        </div>
    </div>
</li>`;
};

function Timer(EndDate, target, callback) {
  var _endDate = EndDate;
  var timer = setInterval(() => {
    var distance = _endDate - Date.now();
    if (distance <= 0) {
      clearInterval(timer);
      return false;
    }
    if (callback && typeof callback == "function") {
      callback(
        GetDays(distance),
        GetHours(distance),
        GetMinutes(distance),
        GetSeconds(distance),
        target
      );
    }
  }, 1000);
  return timer;
}
function callback(d, h, m, s, target) {
  var time = "";
  var ele = $(target);
  if (d > 0) {
    time = `${d}:`;
  }
  if (h > 0) {
    time = `${time}${h}:`;
  }
  ele.text(`${time}${m}:${s}`);
}

//#endregion

/***
 *
 *
 */
class AuctionWebSocket {
  constructor(id, outbids, endDate, ActualEndDate, socketUrl) {
    this.id = id;
    this.outbids = outbids;
    this.endDate = endDate;
    this.ActualEndDate = ActualEndDate;
    this.socketUrl = socketUrl;
    this.CountDown();
    this.actual_timer = null;
    this.end_timer = null;
  }

  log(...arg) {
    if (isDev) console.log(...arg);
  }

  handleCloseEvent(event) {
    this.log("[handleCloseEvent]", event);

    if ($(`#liveView[data-auction='${this.id}']`).hasClass("in")) {
      $(`#liveView[data-auction='${this.id}']`).modal("hide");
      $notification.info(event.code, "connection closed");
    }
    WebSockets[this.id] = null;
  }

  CountDown() {
    this.endTimer();
    this.actualEndTimer(this.ActualEndDate);
  }
  actualEndTimer(a_date) {
    if (actual_timer[this.id] && actual_timer[this.id] != null) {
      this.log(" [clearInterval] actual_timer", actual_timer[this.id]);
      clearInterval(actual_timer[this.id]);
      actual_timer[this.id] = null;
    }
    actual_timer[this.id] = Timer(
      new Date(a_date),
      `#modal-${this.id} .actual_end_timer`,
      (d, h, m, s, target) => {
        callback(d, h, m, s, target);
        if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
          setTimeout(() => location.reload(), 5000);
        }
      }
    );
  }

  endTimer() {
    this.end_timer = Timer(
      new Date(this.endDate),
      `#modal-${this.id} .end_timer`,
      (d, h, m, s, target) => {
        callback(d, h, m, s, target);
        if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
          $(`#modal-${this.id} .time_to_end`).addClass("hidden");
          $(`#modal-${this.id} .time_to_actual_end`).removeClass("hidden");
        }
      }
    );
  }

  WebSocketConnect() {
    if (this.socketUrl && this.socketUrl.length > 0) {
      let socket = new WebSocket(this.socketUrl);
      this.log("[socket]", socket);
      socket.onopen = event => {
        this.log(`[websocket] open`, event);
      };

      socket.onmessage = event => {
        this.log("[message] Data received from server", event);

        if (event.data != null) {
          var msg = JSON.parse(event.data);

          if (msg.mt == OUTBID) {
            this.log("msg.aaed", msg.aaed);
            this.actualEndTimer(msg.aaed);
            this.OnOutbidMsg(msg);
          } else if (msg.mt == ACTIVE) {
            this.log(msg);
          } else if (msg.mt == CLOSE) {
            setTimeout(() => location.reload(), 500);
          }
        }
      };

      WebSockets[this.id] = socket;
    } else {
      this.log("[connect] socket url is missing");
    }
  }
  OnOutbidMsg(msg) {
    this.log("[Outbid] Data received ", msg);
    this.CreateOutbidsList(msg);
    this.CreateLastOutbid(msg.a);
  }

  CreateOutbidsList(msg) {
    if (msg.a == this.id) {
      var list = [];
      var ob = msg.o;
      if (this.outbids.length > 0) {
        if (this.outbids.findIndex(o => o.pid == ob.pid) > -1) {
          this.outbids = this.outbids.filter(ot => ot.pid != ob.pid);
        }
      }
      this.outbids.push(ob);
      this.outbids = this.outbids
        .sort((a, b) => new Date(a.d) - new Date(b.d))
        .sort((a, b) => b.pr - a.pr);

      var html = "";
      this.outbids.forEach(itm => (html += outbidTemplate(itm)));
      $(`#modal-${this.id} .outbids-list`).html(html);
    }
  }
  CreateLastOutbid(id) {
    let outbid = this.outbids[0];
    this.log("[last outbid]", outbid);
    if (id == this.id) {
      $(`#modal-${this.id} .lv-outbids-list`).html(lastOutbidTemplate(outbid));
      $(`#modal-${this.id} .hprice`).text(outbid.pr);

      if (lastOutbidTimeAgo != null) {
        clearInterval(lastOutbidTimeAgo);
      }
      lastOutbidTimeAgo = setInterval(() => {
        $(`#modal-${this.id} #OutbidDate`).text(
          moment(new Date(outbid.d)).fromNow()
        );
      }, 1000);
    }
  }
}

$(".ac-date").on("click", function(e) {
  $(".ac-date , .outbid-date")
    .find(".utc,.local")
    .toggleClass("hidden");
  IsUTC = !IsUTC;
});

var hasStarted;

$(`#liveView[data-auction='${AuctionId}']`).on("show.bs.modal", () => {
  if (!hasStarted) {
    if (lastOutbidTimeAgo != null) {
      clearInterval(lastOutbidTimeAgo);
    }
    lastOutbidTimeAgo = setInterval(() => {
      var date = $(`#modal-${AuctionId} .lv-outbids-list .outbid-date`).data(
        "date"
      );
      $(`#modal-${AuctionId} .lv-outbids-list .outbid-date`).text(
        moment(new Date(`${date} UTC`)).fromNow()
      );
    }, 1000);
    hasStarted = true;
  }
});

$(`#liveView[data-auction='${AuctionId}']`).on("shown.bs.modal", () => {
  if ("WebSocket" in window) {
    if (WebSockets[AuctionId] == null) {
      WebSockets[AuctionId] = new AuctionWebSocket(
        AuctionId,
        auctions[AuctionId].outbids,
        auctions[AuctionId].endDate,
        auctions[AuctionId].ActualEndDate,
        auctions[AuctionId].socketUrl
      );
      WebSockets[AuctionId].WebSocketConnect();
    }
  } else {
    $notification.error(
      "Error",
      "LiveView is not supported by your browser",
      5000
    );
    $(`#liveView[data-auction='${AuctionId}']`).modal("hide");
  }
});

$(`#liveView[data-auction='${AuctionId}']`).on("hidden.bs.modal", () => {});
