function AudioChangeWindow() {
    const audio = new Audio("../audio/Change_Window.wav");
    audio.play();
}

function AudioChangeInput() {
    const audio = new Audio("../audio/Change_Input.wav");
    audio.play();
}

function AudioValidateFail(pass) {
    if (!pass) {
        const audio = new Audio("../audio/Unsuccess.wav");
        audio.play();
    }
}