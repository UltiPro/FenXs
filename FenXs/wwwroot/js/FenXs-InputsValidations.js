function Validation(fun, what, pass) {
    if (fun(what.val())) {
        what.removeClass("is-invalid");
        what.addClass("is-valid");
        return pass;
    }
    what.addClass("is-invalid");
    return false;
}

function ValidationPasswords(password, password2, pass) {
    if (CheckPasswordCompatibility(password.val(), password2.val())) {
        password2.removeClass("is-invalid");
        password2.addClass("is-valid");
        return pass;
    }
    password2.addClass("is-invalid");
    return false;
}

function CheckLogin(login) {
    const loginRegex = /^[A-Za-z][A-Za-z0-9_-]{1,13}[A-Za-z0-9]$/;
    if ((login.length < 3 || login.length > 15) || (!(loginRegex.test(login)))) return false;
    return true;
}

function CheckEmail(email) {
    const emailRegex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
    if ((email.length < 3 || email.length > 320) || (!(emailRegex.test(email)))) return false;
    return true;
}

function CheckPassword(password) {
    const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$/;
    if ((password.length < 8 || password > 30) || (!(passwordRegex.test(password)))) return false;
    return true;
}

function CheckPasswordCompatibility(password, password2) {
    if ((password != password2) || (password == "") || (password2 == "")) return false;
    return true;
}