ToggleFotter();

$(window).resize(function () {
    ToggleFotter();
})

function ToggleFotter() {
    if ($(window).width() < 768) {
        $("footer").removeClass("footer-min");
        $("footer").addClass("footer-max");
        $("footer").removeClass("border-start");
    } else {
        $("footer").removeClass("footer-max");
        $("footer").addClass("footer-min");
        $("footer").addClass("border-start");
    }
}