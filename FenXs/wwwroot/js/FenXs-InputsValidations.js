function Validation(fun, obj, pass) {
    if (fun(obj.val())) {
        obj.removeClass("is-invalid");
        obj.addClass("is-valid");
        return pass;
    }
    obj.addClass("is-invalid");
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

function CheckPasswords(password, password2, pass) {
    if ((password.val() != password2.val()) || (password.val() == "") || (password2.val() == "")) {
        password2.addClass("is-invalid");
        return false;
    }
    password2.removeClass("is-invalid");
    password2.addClass("is-valid");
    return pass;
}