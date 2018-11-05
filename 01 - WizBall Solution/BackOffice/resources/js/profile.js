
//HTML ELEMENTS
var admin_username = $('#input_admin_username');
var admin_email = $('#input_admin_email');
var new_admin_password = $('#input_new_admin_password');
var new_admin_password_confirmation = $('#input_new_admin_password_confirmation');

//VARS


//ARRAYS


//FUNCTIONS
//updates the admin session values.
function updateSession(Admin) {
    $.session.clear();
    $.session.set("AdminUsername", Admin['Username']);
    $.session.set("AdminPassword", Admin['Password']);
    $.session.set("AdminEmail", Admin['Email']);
    $.session.set("AdminId", Admin['Id']);
}

//compares the submited admin with the session admin.
function isEquivalent(Admin) {

    if (Admin['Username'] !== $.session.get('AdminUsername')) {
        return false;
    } else if (Admin['Email'] !== $.session.get('AdminEmail')) {
        return false;
    } if (Admin['Password'] !== $.session.get('AdminPassword')) {
        return false;
    }

    return true;
}

//cleans the passwords fileds.
function cleanPasswordFields() {
    new_admin_password.val();
    new_admin_password_confirmation.val();
}

//gets the session admin to form.
function GetAdminToForm() {
    admin_username.val($.session.get("AdminUsername"));
    console.log($.session.get("AdminEmail"));
    admin_email.val($.session.get("AdminEmail"));
    cleanPasswordFields();
    $(".se-pre-con").fadeOut();
}

//validates the form.
function validateForm() {
    var validated = true;
    $(".has-error").removeClass("has-error");

    if (new_admin_password_confirmation.val() === "" && new_admin_password.val() !== "") {
        new_admin_password_confirmation.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("New password don't match.");
        validated = false;
    }
    if (new_admin_password_confirmation.val() !== "" && new_admin_password_confirmation.val().length > 60) {
        new_admin_password_confirmation.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The password must be less than 60 characters.");
        validated = false;
    }
    if (new_admin_password_confirmation.val() !== "" && new_admin_password_confirmation.val().length <= 5) {
        new_admin_password_confirmation.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The password must be atleast 6 characters.");
        validated = false;
    }

    if (new_admin_password.val() === "" && new_admin_password_confirmation.val() !== "") {
        new_admin_password.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("New password don't match.");
        validated = false;
    }
    if (new_admin_password.val() !== "" && new_admin_password.val().length > 60) {
        new_admin_password.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The password must be less than 60 characters.");
        validated = false;
    }
    if (new_admin_password.val() !== "" && new_admin_password.val().length <= 5) {
        new_admin_password.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The password must be atleast 6 characters.");
        validated = false;
    }

    if (new_admin_password_confirmation.val() !== new_admin_password.val()) {
        new_admin_password.closest(".form-group").addClass("has-error");
        new_admin_password_confirmation.closest(".form-group").addClass("has-error");
        new_admin_password.val("");
        new_admin_password_confirmation.val("");
        error.fadeIn();
        error.find('.message').text("The new passwords don't match.");
        validated = false;
    }

    if (admin_email.val() === "") {
        admin_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the email field.");
        validated = false;
    }
    if (!isEmail(admin_email.val())) {
        admin_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please input a valid email.");
        validated = false;
    }
    if (admin_email.val().length > 100) {
        admin_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The email must be less than 100 characters.");
        validated = false;
    }

    if (admin_username.val() === "") {
        admin_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the username field.");
        validated = false;
    }
    if (admin_username.val().length > 60) {
        admin_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The username must be less than 60 characters.");
        validated = false;
    }


    if (validated) {
        error.hide();
        error.find('.message').text("");
    } else {
        error.fadeIn();
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }

    return validated;
}

//checks if the form is valid and confirms the action.
function confirmAndSubmit() {
    if (!validateForm()) {
        return;
    }

    var Admin = {};
    Admin['Id'] = $.session.get('AdminId');
    Admin['Username'] = admin_username.val();
    Admin['Password'] = new_admin_password.val() === "" ? $.session.get('AdminPassword') : new_admin_password.val();
    Admin['Email'] = admin_email.val();
    Admin['Picture'] = "user.png";

    console.log(Admin);
    
    if (!isEquivalent(Admin)) {
        swal({
            title: "Confirm update",
            text: "Type your password to apply changes",
            icon: "warning",
            content: {
                element: "input",
                attributes: {
                    placeholder: "Password",
                    type: "password",
                },
            },
        })
            .then((value) => {
                if (value === $.session.get('AdminPassword')) {
                    $(".se-pre-con").fadeIn();
                    updateAdmin(Admin);
                } else {
                    error.fadeIn();
                    error.find('.message').text("Incorrect Password.");
                    cleanPasswordFields();
                    validated = false;
                }
            });
    } else {
        swal({
            title: "Nothing to update...",
            text: "",
            icon: "info",
            timer: 2500
        });
    }


}

//updates the given admin.
function updateAdmin(Admin) {

    updateSession(Admin);

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/UpdatetAdmin",
        data: "{Admin: " + JSON.stringify(Admin) + "}",
        dataType: "json",
        success: function (data) {
            if (data.d) {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Success!",
                    text: "Successfully updated!",
                    icon: "success",
                    timer: 3000
                }).then((value) => {
                    window.location = "Users.aspx";

                });
            } else {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Error!",
                    text: "Sorry, we are currently unable to fulfill your request!",
                    icon: "warning",
                    timer: 3000
                });
            }
        },
        error: function () {
            $(".se-pre-con").fadeOut();
            swal({
                title: "Error!",
                text: "Sorry, we are currently unable to fulfill your request!",
                icon: "warning",
                timer: 3000
            });
        }
    });
}



//CALLS
GetAdminToForm();



//EVENTS
$('#discard_profile_changes').click(function () {
    window.location = "Users.aspx";
});

$('#update_profile').click(function () {
    confirmAndSubmit();
});


console.log('READY profile.js');