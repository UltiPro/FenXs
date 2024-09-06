$(document).ready(function () {
    $("input").bind("click", function () {
        AudioChangeInput();
    });
});

function AudioChangeInput() {
    const audio = new Audio("../audio/ChangeInput.wav");
    audio.play();
}