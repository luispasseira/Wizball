
//HTML ELEMENTS
var input_username = $('#input_username');
var input_password = $('#input_password');
var icon_eye = $('#eye');
var btn_login = $('#login');
var form = $('#form_login');
var error = $('#error_message');

//VARS
var passShown = 0;
var is_logged = false;



//FUNCTIONS
//clears all session vars.
function clearSession(){
    $.session.clear();
}

//shows the text of the password input.
function showPassword() {
    input_password.attr("type", "text");
}

//hides the text of the password input.
function hidePassword() {
    input_password.attr("type", "password");
}

//validates the login form.
function validateForm() {
    var validated = true;
    $(".has-error").removeClass("has-error");

    if (input_password.val() === "") {
        input_password.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the password field.");
        validated = false;
    }

    if (input_username.val() === "") {
        input_username.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the username field.");
        validated = false;
    }


    if (validated) {
        error.hide();
        error.find('.message').text("");
    } else {
        error.fadeIn();
    }

    return validated;
}

//clears the login form.
function clearForm() {
    input_username.val("");
    input_password.val("");
}

//submits the form.
function authenticate() {
    if (!validateForm()) {
        return;
    }
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/AdminLogin",
        dataType: "json",
        data: "{Username: " + JSON.stringify(input_username.val()) + ", Password:" + JSON.stringify(input_password.val()) + "}",
        success: function (data) {
            if (data.d !== null) {
                $.session.set("AdminUsername", data.d['Username']);
                $.session.set("AdminEmail", data.d['Email']);
                $.session.set("AdminPassword", data.d['Password']);
                $.session.set("AdminId", data.d['Id']);
                console.log($.session.get("AdminPassword"));
                console.log($.session.get("AdminEmail"));
                is_logged = true;
                swal({
                    title: "Success!",
                    text: "You are logged in.",
                    icon: "success",
                    timer: 3000
                })
                    .then((value) => {
                        window.location.href = 'Users.aspx';
                    });
            } else {
                swal("Error!", "Incorrect username or password. ", "warning").then((value) => {
                    clearForm();
                });
            }

        },
        error: function (data, status, error) {
            swal("Error!", " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ", "warning");
        }
    });
}



//CALLS
clearSession();



//EVENTS
icon_eye.click(function () {
    if (passShown === 0) {
        passShown = 1;
        showPassword();
        icon_eye.removeClass("fa-eye").addClass("fa-eye-slash");
    } else {
        passShown = 0;
        hidePassword();
        icon_eye.removeClass("fa-eye-slash").addClass("fa-eye");
    }
});

btn_login.click(function () {
    // prevent double enter click
    if (!is_logged) {
        authenticate();
    }
});

$(document).keydown(function (e) {
    if (e.keyCode === 13) {
        btn_login.trigger('click');
    }
});


console.log('READY login.js');
