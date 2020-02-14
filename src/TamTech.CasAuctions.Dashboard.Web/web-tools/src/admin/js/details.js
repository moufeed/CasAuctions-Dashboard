$(".ac-date").on("click", function(e) {
  $(this)
    .find(".utc,.local")
    .toggleClass("hidden");
});
