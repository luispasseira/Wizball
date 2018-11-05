// UPLOAD USER IMAGE ******************************************************************************************
var fileUpload = document.getElementById("fileuploadUserPicture");
var customFileUpload    = document.getElementById("btnCustomFileUpload");
var userPic             = document.getElementById("imgUserPic");
var uploadStatus        = document.getElementById("upload-status");

customFileUpload.addEventListener("click", function () {

    fileUpload.click();

});
fileUpload.addEventListener("change", function () {

    if (this.files && this.files[0]) {

        if (!validFileType(this.files[0])) {
            uploadStatus.innerHTML = "Acceptable file types: jpeg, png, ico";
            return;
        }
        else if (this.files[0].size > 512000) {
            uploadStatus.innerHTML = "Max file size: 500 Kb";
            return;
        }
        else {
            uploadStatus.innerHTML = "";

            var fileReader = new FileReader();

            fileReader.readAsDataURL(this.files[0]);

            fileReader.onload = function (data) {
                userPic.src = data.target.result;
            };
        }       
    }

});
function validFileType(file) {
    var fileTypes = ["image/jpeg", "image/jpg", "image/ico", "image/x-icon", "image/png"];

    for (var i = 0; i < fileTypes.length; i++) {
        if (file.type === fileTypes[i]) {
            return true;
        }
    }    
    return false;
}
// UPLOAD USER IMAGE ******************************************************************************************





// AJAX VALIDATION ********************************************************************************************
var currentEmail = document.getElementById("txtEmail").value;
var currentUsername = document.getElementById("txtUsername").value;

function isEmailTaken() {

    var txtEmail = document.getElementById("txtEmail").value;
    var emailStatus = document.getElementById("emailStatus");


    if (currentEmail === txtEmail) return;      // If the current email is equal to current user mail. Dont do nothing.

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

    if (currentUsername === txtUsername) return;      // If the current username is equal to current user username. Dont do nothing.


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
// AJAX VALIDATION ********************************************************************************************





// FORM VALIDATION ********************************************************************************************
function isUserPictureReady() {

    var result = true;

    if (uploadStatus.innerText.length > 0) {
        result = false;
    }

    return result;
}
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

function isPasswordsReady()
{
    var txtPassword         = document.getElementById("txtPassword").value;
    var passwordStatus      = document.getElementById("passwordStatus");
    var txtPasswordTwo      = document.getElementById("txtPasswordTwo").value;
    var passwordTwoStatus   = document.getElementById("passwordStatusTwo");

    if (txtPassword.length > 0 || txtPasswordTwo.length > 0) {              // Verifies if at least one of the two passwords has values.
        if (txtPassword === txtPasswordTwo) {                               // If true then both must be equals.

            var result = true;

            if (!isPasswordReady()) {                                       // and if both passes validations. (this way it can validate and write in both status)
                result = false;
            }
            if (!isPasswordReadyTwo()) {                                    // and if both passes validations.
                result = false;
            }

            return result;
        }
        else {
            passwordStatus.innerText = "Passwords dont match";
            passwordTwoStatus.innerText = "Passwords dont match";
            return false;
        }
    }
    else {
        return true;
    }
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
function isPasswordReadyTwo() {

    var result = true;

    var txtPassword = document.getElementById("txtPasswordTwo").value;
    var passwordStatus = document.getElementById("passwordStatusTwo");

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
    if (!isPasswordsReady()) {
        result = false;
    }

    if (result) {
        document.getElementById("outter-modal").style.display = "block";
    }

    return result;
}
// FORM VALIDATION ********************************************************************************************





// MODAL UPDATE USER PROFILE CONFIRMATION.
document.getElementById("btnModalCancel").addEventListener("click", function () {

    document.getElementById("currentPassword").value = "";
    document.getElementById("currentPasswordStatus").innerText = "";
    document.getElementById("outter-modal").style.display = "none";

});
function passwordValitation() {

    var result          = false;
    var txtPassword     = document.getElementById("currentPassword").value;
    var passwordStatus  = document.getElementById("currentPasswordStatus");

    if (txtPassword.length === 0) {
        passwordStatus.innerText = "Required";
        return false;
    }
    else if (txtPassword.length < 6) {
        passwordStatus.innerText = "Min length 6";
        return false;
    }
    else if (txtPassword.length > 100) {
        passwordStatus.innerText = "Max length 100";
        return false;
    }


    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "../WizballWS.asmx/UserLogin",
        data: "{Username: '" + currentUsername + "', Password: '" + txtPassword + "'}",
        dataType: "json",

        success: function (data) {
            if (data.d !== null) {
                result = true;
            }
            else {
                passwordStatus.innerText = "Incorrect password";
            }
        },

        error: function (data, status, error) {
            alert(error);
        }

    });

    return result;

}


// MODAL CHANGES CONFIRMATION *******************************************************************
function recoverPasswordConfirmation() {

    // Shows modal.
    var modal = document.getElementById('outterModalx');
    modal.style.display = "block";

    // Get elements.
    var counter = document.getElementById("modal-counterx");
    var currentValue = parseInt(counter.innerText);

    window.setTimeout(closeViewRecoverPassword, currentValue * 1000);

    window.setInterval(function () {
        counter.innerText = currentValue === 0 ? 0 : --currentValue;
    }, 1000);
}
function closeViewRecoverPassword() {
    window.location.replace("/Pages/ViewHome.aspx");
}
document.getElementById("modal-closex").addEventListener("click", closeViewRecoverPassword);
