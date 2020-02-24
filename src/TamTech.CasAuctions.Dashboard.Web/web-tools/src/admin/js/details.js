//----------
// Live Message Type Enum
const OUTBID = 1;
const ACTIVE = 2;
const CLOSE = 3;
const CANCEL = 4;
let IsUTC = true;
var ws = null;
var TimerToCLose;

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

const timeDifference = (current, previous) => {
  let msPerMinute = 60 * 1000;
  let msPerHour = msPerMinute * 60;
  let msPerDay = msPerHour * 24;
  let msPerMonth = msPerDay * 30;
  let msPerYear = msPerDay * 365;
  let elapsed = current - previous;
  if (elapsed < msPerMinute) {
    return Math.round(elapsed / 1000) + " seconds ago";
  } else if (elapsed < msPerHour) {
    return Math.round(elapsed / msPerMinute) + " minutes ago";
  } else if (elapsed < msPerDay) {
    return Math.round(elapsed / msPerHour) + " hours ago";
  } else if (elapsed < msPerMonth) {
    return "approximately " + Math.round(elapsed / msPerDay) + " days ago";
  } else if (elapsed < msPerYear) {
    return "approximately " + Math.round(elapsed / msPerMonth) + " months ago";
  } else {
    return "approximately " + Math.round(elapsed / msPerYear) + " years ago";
  }
};

const lastOutbidTemplate = outbid => {
  return `
 <li data-id="${outbid.id}">
  <picture>
      <img src="/Admin/img/Avatar.svg" class="img-responsive" />
  </picture>
  <div class="outbid-info">
      <strong class="outbids-name">${outbid.pfn}</strong>
      <div>
          <span class="outbid-price"><strong class="price">${
            outbid.pr
          }</strong> <small class="currency"></small></span>
          <span class="outbid-date">
              ${timeDifference(Date.now(), new Date(outbid.d).getTime())}
          </span>
      </div>
  </div>
  </li>
`;
};

const outbidTemplate = outbid => {
  return `
<li>
    <picture>
        <img src="/Admin/img/Avatar.svg" alt="" width="70">
    </picture>
    <div class="outbid-info">
        <strong class="outbids-name">${outbid.pfn}</strong>
        <div>
            <span class="outbid-price"><strong class="price">${
              outbid.pr
            }</strong> <small class="currency"></small></span>
            <span class="outbid-date">
                <strong class="utc ${IsUTC ? "" : "hidden"}"> ${new Date(
    outbid.d
  ).toUTCString()} (<small>UTC</small>)</strong>
                <strong class="local ${IsUTC ? "hidden" : ""}">${new Date(
    outbid.d
  )}(<small>local</small>)</strong>
            </span>
        </div>
    </div>
</li>`;
};

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

var end_timer = Timer(new Date(endDate), ".end_timer", (d, h, m, s, target) => {
  callback(d, h, m, s, target);
  if ((d == 0) & (h == 0) & (m == 0) & (s == 0)) {
    $(".time_to_end").addClass("hidden");
    $(".time_to_actual_end").removeClass("hidden");
  }
});

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
      console.log(event);
    };

    socket.onmessage = event => {
      console.log("[message] Data received from server", event);
      if (event.data != null) {
        var msg = JSON.parse(event.data);
        switch (msg.mt) {
          case OUTBID:
            OnOutbidMsg(msg.o);
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
      console.log(event);
    };

    socket.onerror = error => {
      console.log(error);
    };
    return socket;
  };

  /**
   * call ws on open live view modal
   */
  $("#liveView").on("show.bs.modal", () => {
    ws = StartWS();
  });

  /**
   * stop ws after close live view modal
   */
  $("#liveView").on("hidden.bs.modal", () => {
    if (ws != null) {
      ws.close();
      ws = null;
    }
  });
}

const OnOutbidMsg = msg => {
  console.log("[Outbid] Data received ", msg);
  var LstTpl = lastOutbidTemplate(msg);
  var OutTpl = outbidTemplate(msg);
  $(".lv-outbids-list").html(LstTpl);
  $(".outbids-list").prepend(OutTpl);
  $(".hprice").text(msg.p);
};

const OnActiveMsg = msg => {
  console.log(msg);
};

/**
 * close websocket by reloading the page
 * @param {*} msg
 */
const OnCloseMsg = msg => setTimeout(() => location.reload(), 500);

$(".ac-date").on("click", function(e) {
  $(".ac-date , .outbid-date")
    .find(".utc,.local")
    .toggleClass("hidden");
  IsUTC = !IsUTC;
});

//
