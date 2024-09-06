document.getElementById("TurnOffServerStart").addEventListener("click", StartTimer);
document.getElementById("TurnOffServerStop").addEventListener("click", StopTimer);

let time = 60;
let blockOffButton = false;
let intervalId;

function StartTimer() {
    if (!blockOffButton) {
        blockOffButton = true;
        ChangeTimeHelper();
        intervalId = setInterval(ChangeTimeHelper, 1000);
    }
}

function StopTimer() {
    clearInterval(intervalId);
    time = 60;
    blockOffButton = false;
    document.getElementById("TurnOffServerText").innerHTML = "Turn Off Server?";
}

function ChangeTimeHelper() {
    time--;
    document.getElementById("TurnOffServerText").innerHTML = "Time left... <span class='text-danger'>" + time + "s</span>.";
    if (time == 0) clearInterval(intervalId);
}