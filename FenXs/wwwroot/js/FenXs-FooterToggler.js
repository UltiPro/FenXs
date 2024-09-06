ToggleFotter();

$(window).resize(function () {
    ToggleFotter();
})

function ToggleFotter() {
    if ($(window).width() < 768) {
        $("footer").removeClass("FooterMin");
        $("footer").addClass("FooterMax");
        $("footer").removeClass("border-start");
    } else {
        $("footer").removeClass("FooterMax");
        $("footer").addClass("FooterMin");
        $("footer").addClass("border-start");
    }
}