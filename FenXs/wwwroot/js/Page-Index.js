$(document).ready(function () {
    $("#SignInSelector").bind("click", function () {
        ToggleIndexBox("#LoginInSelector", "#SignInSelector", "#LoginInBox", "#SignInBox");
    })
})

$(document).ready(function () {
    $("#LoginInSelector").bind("click", function () {
        ToggleIndexBox("#SignInSelector", "#LoginInSelector", "#SignInBox", "#LoginInBox");
    })
})

$(document).ready(function () {
    $("#SignInInfoBtn").bind("click", function () {
        ToggleInfoBox("#SignInLoginInBox", "#InfoBox");
    })
})

$(document).ready(function () {
    $("#InfoBoxQuitBtn").bind("click", function () {
        ToggleInfoBox("#InfoBox", "#SignInLoginInBox");
    })
})

function ToggleIndexBox(from, to, whatfrom, whatto) {
    if ($(to).hasClass("FenXs-Dark-Wooden")) {
        AudioChangeWindow();
        $(whatfrom).hide();
        $(from).removeClass("FenXs-Wooden");
        $(from).addClass("FenXs-Dark-Wooden");
        $(whatto).show();
        $(to).removeClass("FenXs-Dark-Wooden");
        $(to).addClass("FenXs-Wooden");
        switch (to) {
            case "#LoginInSelector":
                $(from).addClass("border-start-0");
                $(to).removeClass("border-end-0");
                break;
            case "#SignInSelector":
                $(from).addClass("border-end-0");
                $(to).removeClass("border-start-0");
                break;
        }
    }
}

function ToggleInfoBox(from, to) {
    AudioChangeWindow();
    $(from).hide();
    $(to).show();
}

function ValidateSignIn() {
    let pass = true;
    const login = $("input[name='R.login']");
    const email = $("input[name='R.email']");
    const password = $("input[name='R.password']");
    const c_password = $("input[name='R.c_password']");
    pass = Validation(CheckLogin, login, pass);
    pass = Validation(CheckEmail, email, pass);
    pass = Validation(CheckPassword, password, pass);
    pass = CheckPasswords(password, c_password, pass);
    if (!pass) AudioValidateFail();
    return pass;
}

function ValidateLoginIn() {
    let pass = true;
    const login = $("input[name='L.login']");
    const password = $("input[name='L.password']");
    pass = Validation(CheckLogin, login, pass);
    pass = Validation(CheckPassword, password, pass);
    if (!pass) AudioValidateFail();
    return pass;
}