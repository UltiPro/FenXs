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
    const loginRegex = /^(?=.*?[a-zA-Z\d])[a-zA-Z][a-zA-Z\d_-]{2,28}[a-zA-Z\d]$/;
    if ((login.length < 3 || login.length > 15) || (!(loginRegex.test(login)))) return false;
    return true;
}

function CheckEmail(email) {
    const emailRegex = /^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/;
    if ((email.length < 3 || email.length > 320) || (!(emailRegex.test(email)))) return false;
    return true;
}

function CheckPassword(password) {
    const passwordRegex = /^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'"/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'"/,|{}<>?]{8,40}$/;
    if ((password.length < 8 || password > 40) || (!(passwordRegex.test(password)))) return false;
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