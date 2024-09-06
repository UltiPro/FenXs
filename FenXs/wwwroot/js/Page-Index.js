if (GetCookie("whereLogged") != null) ToggleIndexBox("#SignInSelector", "#LoginInSelector", "#SignInBox", "#LoginInBox", 0);

$(document).ready(function () {
    $("#SignInSelector").bind("click", function () {
        ToggleIndexBox("#LoginInSelector", "#SignInSelector", "#LoginInBox", "#SignInBox", 1);
    })
})

$(document).ready(function () {
    $("#LoginInSelector").bind("click", function () {
        ToggleIndexBox("#SignInSelector", "#LoginInSelector", "#SignInBox", "#LoginInBox", 1);
    })
})

$(document).ready(function () {
    $("#SignInInfoBtn").bind("click", function () {
        ToggleInfoBox("#SignInLoginInBox", "#SignInInfoBox");
    })
})

$(document).ready(function () {
    $("#SignInInfoBtnQuit").bind("click", function () {
        ToggleInfoBox("#SignInInfoBox", "#SignInLoginInBox");
    })
})

function ToggleIndexBox(fromSelector, toSelector, fromBox, toBox, playAudio) {
    if ($(toSelector).hasClass("FenXs-Dark-Wooden")) {
        if (playAudio) AudioChangeWindow();
        $(fromBox).hide();
        $(fromSelector).removeClass("FenXs-Wooden");
        $(fromSelector).addClass("FenXs-Dark-Wooden");
        $(toBox).show();
        $(toSelector).removeClass("FenXs-Dark-Wooden");
        $(toSelector).addClass("FenXs-Wooden");
        switch (toSelector) {
            case "#LoginInSelector":
                $(fromSelector).addClass("border-start-0");
                $(toSelector).removeClass("border-end-0");
                break;
            case "#SignInSelector":
                $(fromSelector).addClass("border-end-0");
                $(toSelector).removeClass("border-start-0");
                break;
        }
    }
}

function ToggleInfoBox(fromBox, toBox) {
    AudioChangeWindow();
    $(fromBox).hide();
    $(toBox).show();
}

function ValidateSignIn() {
    let pass = true;
    const login = $("input[name='r.login']");
    const email = $("input[name='r.email']");
    const password = $("input[name='r.password']");
    const c_password = $("input[name='r.confirmPassword']");
    pass = Validation(CheckLogin, login, pass);
    pass = Validation(CheckEmail, email, pass);
    pass = Validation(CheckPassword, password, pass);
    pass = CheckPasswords(password, c_password, pass);
    if (!pass) AudioValidateFail();
    return pass;
}

function ValidateLoginIn() {
    let pass = true;
    const login = $("input[name='l.login']");
    const password = $("input[name='l.password']");
    pass = Validation(CheckLogin, login, pass);
    pass = Validation(CheckPassword, password, pass);
    if (!pass) AudioValidateFail();
    return pass;
}