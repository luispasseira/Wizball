// EXEC EVERY PAGE LOAD
clearForm();



// AJAX VALIDATION *********************************************************
function isEmailTaken() {

    var txtEmail = document.getElementById("txtEmail").value;
    var emailStatus = document.getElementById("emailStatus");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WizballWS.asmx/UserMailExists",
        data: "{Email: '" + txtEmail + "'}",
        dataType: "json",

        success: function (data) {
            if (data.d === true) {
                emailStatus.innerText = "Email already taken";
            }
            else {
                emailStatus.innerText = "";
            }
        },

        error: function (data, status, error) {
            alert(error);
        }

    });
}
function isUsernameTaken() {

    var txtUsername = document.getElementById("txtUsername").value;
    var usernameStatus = document.getElementById("usernameStatus");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WizballWS.asmx/UsernameExists",
        data: "{Username: '" + txtUsername + "'}",
        dataType: "json",

        success: function (data) {
            if (data.d === true) {
                usernameStatus.innerText = "Username already taken";
            }
            else {
                usernameStatus.innerText = "";
            }
        },

        error: function (data, status, error) {
            alert(error);
        }

    });
}
document.getElementById("txtEmail").addEventListener("keyup", isEmailTaken);
document.getElementById("txtUsername").addEventListener("keyup", isUsernameTaken);



// MODAL *******************************************************************
function recoverPasswordConfirmation() {

    // Shows modal.
    var modal = document.getElementById('outterModal');
    modal.style.display = "block";

    // Get elements.
    var counter = document.getElementById("modal-counter");
    var currentValue = parseInt(counter.innerText);

    window.setTimeout(closeViewRecoverPassword, currentValue * 1000);

    window.setInterval(function () {
        counter.innerText = currentValue === 0 ? 0 : --currentValue;
    }, 1000);
}
function closeViewRecoverPassword() {
    window.location.replace("/Pages/ViewHome.aspx");
}
document.getElementById("modal-close").addEventListener("click", closeViewRecoverPassword);



// FORM VALIDATION *********************************************************
function isUsernameReady() {

    var result = true;

    var txtUsername = document.getElementById("txtUsername").value;
    var usernameStatus = document.getElementById("usernameStatus");

    if (usernameStatus.innerText.length > 0) {
        result = false;
    }
    else if (txtUsername.length === 0) {
        usernameStatus.innerText = "Required";
        result = false;
    }
    else if (txtUsername.length > 50) {
        usernameStatus.innerText = "Max length 50";
        result = false;
    }
    else {
        usernameStatus.innerText = "";
    }

    return result;
}
function isEmailReady() {

    var result = true;

    var txtEmail = document.getElementById("txtEmail").value;
    var emailStatus = document.getElementById("emailStatus");

    var emailValidator = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()\.,;\s@\"]+\.{0,1})+[^<>()\.,;:\s@\"]{2,})$/;


    if (emailStatus.innerText.length > 0) {
        result = false;
    }
    else if (txtEmail.length === 0) {
        emailStatus.innerText = "Required";
        result = false;
    }
    else if (txtEmail.length > 100) {
        emailStatus.innerText = "Max length 100";
        result = false;
    }
    else if (!emailValidator.test(txtEmail)) {
        emailStatus.innerText = "Invalid email format";
        result = false;
    }
    else {
        emailStatus.innerText = "";
    }

    return result;
}
function isPasswordReady() {

    var result = true;

    var txtPassword = document.getElementById("txtPassword").value;
    var passwordStatus = document.getElementById("passwordStatus");

    if (txtPassword.length === 0) {
        passwordStatus.innerText = "Required";
        result = false;
    }
    else if (txtPassword.length < 6) {
        passwordStatus.innerText = "Min length 6";
        result = false;
    }
    else if (txtPassword.length > 100) {
        passwordStatus.innerText = "Max length 100";
        result = false;
    }
    else {
        passwordStatus.innerText = "";
    }

    return result;
}

function IsFormValid() {

    var result = true;

    if (!isUsernameReady()) {
        result = false;
    }
    if (!isEmailReady()) {
        result = false;
    }
    if (!isPasswordReady()) {
        result = false;
    }


    return result;
}
function clearForm() {
    document.getElementById("txtUsername").value = "";
    document.getElementById("txtEmail").value = "";
    document.getElementById("txtPassword").value = "";

    document.getElementById("btnSubmit").blur();
}