function CreateLabel(tooltipItem, data) {
  var label = data.labels[tooltipItem.index];
  var values = data.datasets[tooltipItem.datasetIndex].data;
  var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
  var total = 0;
  for (var i in values) {
    total += values[i];
  }
  var percentage = Math.round((value / total) * 100);
  var totally = total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
  return (
    label +
    " : " +
    // value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") +
    "[ " +
    percentage +
    "% ]"
  );

  // if (tooltipItem.datasetIndex < data.datasets.length - 1) {
  //   return label + " : " + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' (' + percentage + '%)';
  // } else {
  //   return [label + " : " + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' (' + percentage + '%)', "Total : " + totally];
  // }
}

function getLabels(data) {
  // console.log("getLabels", data.labels);
  if (!data.labels) {
    return [];
  }
  return data.labels.split(",");
}

function getHoverColors(data) {
  if (!data.hoverColors) {
    return [
      "rgba(255, 99, 132, 1)",
      "rgba(54, 162, 235, 1)",
      "rgba(255, 206, 86, 1)",
      "rgba(75, 192, 192, 1)",
      "rgba(153, 102, 255, 1)",
      "rgba(255, 159, 64, 1)"
    ];
  }
  return data.hoverColors.split("-");
}

function getColors(data) {
  // console.log("getColors", data.backgrounds);
  if (!data.backgrounds) {
    return [
      "rgba(255, 99, 132, 0.2)",
      "rgba(54, 162, 235, 0.2)",
      "rgba(255, 206, 86, 0.2)",
      "rgba(75, 192, 192, 0.2)",
      "rgba(153, 102, 255, 0.2)",
      "rgba(255, 159, 64, 0.2)"
    ];
  }
  return data.backgrounds.split("-");
}

function getBorderColors(data) {
  // console.log("getBorderColors", data.borderColor);
  if (!data.borderColors) {
    return [
      "rgba(255, 99, 132, 1)",
      "rgba(54, 162, 235, 1)",
      "rgba(255, 206, 86, 1)",
      "rgba(75, 192, 192, 1)",
      "rgba(153, 102, 255, 1)",
      "rgba(255, 159, 64, 1)"
    ];
  }
  return data.borderColors.split("-");
}

function legendOptions(data) {
  // console.log("legendOptions", data.legend);
  if (data.legend) {
    return data.legend;
  }
  var legendPosition = data.legendPosition ? data.legendPosition : "top";
  var legendDisplay = data.legendDisplay ? data.legendDisplay : false;
  var legendAlign = data.legendAlign ? data.legendAlign : "center";
  var legendPadding = data.legendPadding ? data.legendPadding : 10;

  var legendFontFamily = data.legendFontFamily
    ? data.legendFontFamily
    : "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif";

  var legendFontColor = data.legendFontcolor ? data.legendFontcolor : "black";
  return {
    position: legendPosition,
    display: legendDisplay,
    align: legendAlign,
    labels: {
      fontFamily: legendFontFamily,
      fontColor: legendFontColor,
      padding: legendPadding
    }
  };
}

function getOptions(data) {
  // console.log("getOptions", data.chartOptions);
  if (data.chartOptions) {
    return data.chartOptions;
  }
  return {
    tooltips: {
      callbacks: {
        label: CreateLabel
      }
    },
    legend: legendOptions(data)
  };
}

function getData(data) {
  // console.log("getData", data.chartData);
  if (data.chartData) {
    return data.chartData;
  }
  var Values = data.values ? data.values : [];
  var borderWidth = data.borderWidth ? data.borderWidth : 1;
  return {
    labels: getLabels(data),
    datasets: [
      {
        data: Values,
        backgroundColor: getColors(data),
        hoverBackgroundColor: getHoverColors(data),
        borderWidth: borderWidth,
        borderColor: getBorderColors(data)
      }
    ]
  };
}
function getCenterText(data) {
  if (!data.centerText || !data.centerDisplay) {
    return {
      display: false,
      text: ""
    };
  }

  return {
    display: true,
    text: data.centerText
  };
}

function drawTotals(chart) {
  var width = chart.chart.width,
    height = chart.chart.height,
    ctx = chart.chart.ctx;

  ctx.restore();
  var fontSize = (height / 114).toFixed(2);
  ctx.font = fontSize + "em sans-serif";
  ctx.textBaseline = "middle";

  var r = Math.round(chart.chart.chartArea.right);

  var text = chart.config.centerText.text,
    textX = Math.round((width - ctx.measureText(text).width) / 2),
    textY = height / 2;

  var tx = Math.round((width - r) / 2);
  ctx.fillText(text, textX - tx, textY);
  ctx.save();
}

if (typeof Chart != "undefined") {
  $(".chart-widget").each(function() {
    var ChartWidget = $(this);
    var _data = $(this).data();
    var type = _data.chartType ? _data.chartType : "pie";

    var chart = new Chart(ChartWidget, {
      type: type,
      data: getData(_data),
      options: getOptions(_data),
      centerText: getCenterText(_data),
      plugins: [
        {
          beforeDraw: function(chart, options) {
            if (
              chart.config.centerText.display !== null &&
              typeof chart.config.centerText.display !== "undefined" &&
              chart.config.centerText.display
            ) {
              drawTotals(chart);
            }
          }
        }
      ]
    });
  });
}
