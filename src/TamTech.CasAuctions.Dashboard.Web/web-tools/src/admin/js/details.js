//----------
// Live Message Type Enum
const OUTBID = 1;
const ACTIVE = 2;
const CLOSE = 3;
const CANCEL = 4;
let IsUTC = true;
var ws = null;
var TimerToCLose;
var time = null;
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

function handleCloseEvent(event) {
  console.log(`[handleCloseEvent] ${event}`);
  if ($("#liveView").hasClass("in")) {
    $("#liveView").modal("hide");
    $notification.info(event.code, "connection closed");
  }
  ws = null;
}

//#region  timer

function Timer(EndDate, target, callback) {
  var _endDate = new Date(EndDate).getTime();
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

/**
 *
 *
 *
 */
var end_timer = Timer(new Date(endDate), ".end_timer", (d, h, m, s, target) => {
  callback(d, h, m, s, target);
  if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
    $(".time_to_end").addClass("hidden");
    $(".time_to_actual_end").removeClass("hidden");
  }
});
/**
 *
 *
 */
var actual_timer = Timer(
  new Date(ActualEndDate),
  ".actual_end_timer",
  (d, h, m, s, target) => {
    callback(d, h, m, s, target);
    if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
      TimerToCLose = setTimeout(() => location.reload(), 5000);
    }
  }
);

//#endregion

/**
 * socket
 */

if (socketUrl && socketUrl.length > 0) {
  const StartWS = () => {
    let socket = new WebSocket(socketUrl);
    socket.onopen = event => {
      console.log(`[websocket] open : ${event}`);
    };

    socket.onmessage = event => {
      console.log("[message] Data received from server", event);
      if (event.data != null) {
        var msg = JSON.parse(event.data);
        switch (msg.mt) {
          case OUTBID:
            OnOutbidMsg(msg.o);
            if (actual_timer != null) {
              clearInterval(actual_timer);
            }
            actual_timer = Timer(
              new Date(msg.aaed),
              ".actual_end_timer",
              (d, h, m, s, target) => {
                callback(d, h, m, s, target);
                if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
                  TimerToCLose = setTimeout(() => location.reload(), 5000);
                }
              }
            );
            break;
          case ACTIVE:
            OnActiveMsg(msg);
            break;
          case CLOSE:
            OnCloseMsg(msg);
            break;
        }
      }
    };

    socket.onclose = event => {
      console.log(`[websocket] close : ${event}`);
      handleCloseEvent(event);
    };

    socket.onerror = event => {
      console.log(event);
      $notification.error("", "There was an error with your live view", 3500);
    };
    return socket;
  };

  /**
   * call ws on open live view modal
   */
  var hasStarted;

  $("#liveView").on("show.bs.modal", () => {
    if (outbids != null) {
      /*   outbidsList = outbids.reduce(
        (list, outbid) => {
          return {
            ...list,
            [outbid.id]: outbid
          };
        },
        { ...outbidsList }
      ); */
    }
    if (!hasStarted) {
      if (time != null) {
        clearInterval(time);
      }
      time = setInterval(() => {
        var date = $(".lv-outbids-list .outbid-date").data("date");
        $(".lv-outbids-list .outbid-date").text(
          moment(new Date(`${date} UTC`)).fromNow()
        );
      }, 1000);
      hasStarted = true;
    }
  });
  $("#liveView").on("shown.bs.modal", () => {
    if ("WebSocket" in window) {
      if (ws == null) ws = StartWS();
    } else {
      $notification.error(
        "Error",
        "LiveView is not supported by your browser",
        5000
      );
      $("#liveView").modal("hide");
    }
  });

  $("#liveView").on("hidden.bs.modal", () => {});
}

function GetHighestOutBid(outbid) {
  if (lastOutbid === null || outbid.pr > lastOutbid.pr) {
    lastOutbid = outbid;
    return outbid;
  }
  if (outbid.pr == lastOutbid.pr) {
    if (moment(lastOutbid.d).isSameOrBefore(outbid.d)) {
      return lastOutbid;
    }
  }
  lastOutbid = outbid;
  return outbid;
}
function ChangeOutbidsList(msg) {
  var list = [];

  if (outbids.length > 0) {
    if (outbids.findIndex(o => o.pid == msg.pid) > -1) {
      outbids = outbids.filter(ot => ot.pid != msg.pid);
    }
  }
  outbids.push(msg);
  outbids = outbids
    .sort((a, b) => new Date(b.d) - new Date(a.d))
    .sort((a, b) => b.pr - a.pr);
  console.log(outbids);
  var html = "";
  outbids.forEach(itm => (html += outbidTemplate(itm)));
  $(".outbids-list").html(html);
}

//#region messages
const OnOutbidMsg = msg => {
  console.log("[Outbid] Data received ", msg);
  let hestOutbid = GetHighestOutBid(msg);
  $(".lv-outbids-list").html(lastOutbidTemplate(hestOutbid));
  $(".hprice").text(hestOutbid.pr);

  ChangeOutbidsList(msg);

  if (time != null) {
    clearInterval(time);
  }
  time = setInterval(() => {
    $("#OutbidDate").text(moment(new Date(msg.d)).fromNow());
  }, 1000);
};

/**
 * close websocket by reloading the page
 * @param {*} msg
 */
const OnCloseMsg = msg => setTimeout(() => location.reload(), 500);

const OnActiveMsg = msg => {
  console.log(msg);
};
////#endregion

$(".ac-date").on("click", function(e) {
  $(".ac-date , .outbid-date")
    .find(".utc,.local")
    .toggleClass("hidden");
  IsUTC = !IsUTC;
});

//
