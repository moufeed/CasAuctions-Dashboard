const fetchData = (startDate, endDate, ChartUrl) => {
  const timeZone = /\((.*)\)/
    .exec(new Date().toString())[1]
    .replace(/[:]+[0-9]*/, "")
    .replace("GMT", "");
  return $.ajax({
    type: "GET",
    contentType: "application/json; charset=utf-8",
    url: ChartUrl,
    data: {
      fromdate: startDate,
      todate: endDate,
      TimeZone: timeZone
    }
  });
};

/**
 *
 * @param {number} day  - count of  day's
 */
const collectDate = day =>
  new Date(new Date().getTime() - day * 60 * 60 * 1000).toISOString();

/**
 *
 * @param {string} selector  html selector
 * @param {object} data   chart data
 */
const drawChart = (selector, data) => {
  const canvas = $(selector).find("canvas");
  return new Chart(canvas, {
    type: "pie",
    data: {
      labels: data.labels || [],
      datasets: [
        {
          data: data.data || [],
          backgroundColor: getColors(data),
          hoverBackgroundColor: getHoverColors(data),
          borderWidth: 1,
          borderColor: getBorderColors(data)
        }
      ]
    },
    options: {
      tooltips: {
        callbacks: {
          label: CreateLabel
        }
      },
      legend: {
        position: "right",
        align: "start"
      }
    }
  });
};

/**
 *
 * @param {*} selector
 * @param {*} data
 */
const updateDom = (selector, inStart, showCanvas) => {
  const canvas = $(selector).find("canvas");
  const loading = $(selector).find(".chart-loading");
  const noData = $(selector).find(".svg-no-data");

  if (inStart) {
    canvas.hide();
    loading.addClass("flex-display");
    noData.hide();
  } else {
    loading.removeClass("flex-display");
    if (showCanvas) {
      noData.hide();
      canvas.show();
    } else {
      canvas.hide();
      noData.show();
    }
  }
};

/**
 *
 * @param {*} chart
 * @param {*} data
 */
const updateChart = (chart, data) => {
  chart.data.labels = data.labels || [];
  chart.data.datasets.forEach(dataset => {
    dataset.data = data.data || [];
  });
  chart.update();
};

/**
 *
 * @param {*} selector
 * @param {*} data
 */
const Charts = [];
const createOrUpdateChart = (selector, data) => {
  if (data.labels.length && data.data.length) {
    if (Charts[selector]) {
      updateChart(Charts[selector], data);
    } else {
      Charts[selector] = drawChart(selector, data);
    }
  }
};
/**
 *
 * @param {string} selector   html selector
 * @param {date} startDate  start date
 * @param {date} endDate   end date
 */

const loadChart = (selector, startDate, endDate) => {
  updateDom(selector, true);
  const chartData = fetchData(startDate, endDate, Urls[selector]);
  chartData.done(response => {
    const data = response.data;
    updateDom(selector, false, data.labels.length && data.data.length);
    createOrUpdateChart(selector, data);
  });
};

const SwitchDate = (selector, date) => {
  const endDate = new Date().toISOString();
  switch (date) {
    case "h":
      var d = new Date(new Date().getTime() - 1 * 60 * 1000).toISOString();
      loadChart(selector, d, endDate);
      break;
    case "w":
      loadChart(selector, collectDate(7), endDate);
      break;
    case "m":
      loadChart(selector, collectDate(30), endDate);
      break;
    default:
      loadChart(selector, collectDate(1), endDate);
  }
};

$(document).ready(function() {
  loadChart("#AuctionsChart", collectDate(1), new Date().toISOString());
  loadChart("#DSItemsChart", collectDate(1), new Date().toISOString());
});

$('input[name="customDate"]').on("change", function() {
  var selector = $(
    $(this)
      .parents(".radio")
      .get(0)
  ).data("parent");
  $(selector)
    .find('input[name="startDate"]')
    .prop("checked", false);
  $(selector)
    .find(".customDateForm")
    .show();
});

$('input[name="startDate"]').on("change", function() {
  const $this = $(this);
  const selector = $(
    $(this)
      .parents(".radio")
      .get(0)
  ).data("parent");
  $(selector)
    .find('input[name="customDate"]')
    .prop("checked", false);
  $(selector)
    .find(".customDateForm")
    .hide()
    .trigger("reset");

  if ($this.val() !== previousValue[selector]) {
    previousValue[selector] = $this.val();
    SwitchDate(selector, $this.val());
  }
});
