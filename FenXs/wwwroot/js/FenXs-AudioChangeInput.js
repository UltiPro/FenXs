$(document).ready(function () {
    $("input").bind("click", function () {
        AudioChangeInput();
    })
})

function AudioChangeInput() {
    const audio = new Audio("../audio/Change_Input.wav");
    audio.play();
}