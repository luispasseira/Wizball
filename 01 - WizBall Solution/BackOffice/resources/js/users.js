
//HTML ELEMENTS
var btn_cancel = $('#btn_can');
var btn_submit = $('#btn_submit');
var form = $('#form_edit_user');
var error = $('#error_message');

//FORM ELEMENTS
var toggle_status = $('#toggle_edit_status');
var toggle_newsletter = $('#toggle_edit_newsletter');
var txt_description = $('#txt_edit_description');
var input_username = $('#input_edit_username');
var input_email = $('#input_edit_email');
var user_photo_input = $('#photo');
var user_photo = $('#user_photo');
var photo_real_name = $('#photo_nme');
var old_description = $('#old_description');

//VARS
//saves if the textarea is disabled.
var is_text_area_disabled = true;

//saves if the status toggle was changed by a human or by code.
var is_code_changed = false;

//OBJECTS
var Unedited_user = {};



//FUNCTIONS
//assigns the click event to the buttons generated dynamically.
function assignBtnEditClickEvent() {
    $('.btn_edit').on("click", function () {
        GetClickedUserToForm($(this).closest("tr").attr('value'));
    });
}

//cleans the edit form. this method is called whenever the "pencil" is pressed.
function clearForm() {
    photo_real_name.val("");
    user_photo.attr("src", "/resources/imgs/users/");
    input_username.val("");
    input_email.val("");
    txt_description.val("");
    error.hide();
    error.find('.message').text("");
}

//loads the choosen image to live preview without sending it to the server.
function loadImage(event) {
    user_photo.attr('src', event.target.result);
}

//disables the textarea to prevent writing.
function disableFormTextArea() {
    is_text_area_disabled = true;
    txt_description.val("");
    txt_description.attr('disabled', 'disabled');
}

//enables the textarea to be able to write on it.
function enableFormTextArea() {
    is_text_area_disabled = false;
    txt_description.removeAttr('disabled');
}

//loads side bar effects scripts after generating table rows.
function loadSideBarEffectsScripts() {
    $.getScript('/resources/js/plugins/sidebar/classie.js');
    $.getScript('/resources/js/plugins/sidebar/sidebar-effects.js');
}

//checks if the status toggle is checked.
function checkToggleStatus(status) {
    if (status.Description === "Granted") {
        is_code_changed = true;
        toggle_status.bootstrapToggle('on');
        toggle_status.attr('status_id', status.Id);
    } else {
        toggle_status.bootstrapToggle('off');
        toggle_status.attr('status_id', status.Id);
    }
}

//checks if the newsletter toggle is checked.
function checkToggleNewsletter(news) {
    if (news) {
        toggle_newsletter.bootstrapToggle('on');
    } else {
        toggle_newsletter.bootstrapToggle('off');
    }
}

//toggles the newsletter and status toggles with given values.
function toggleBothFormToggles(status, news) {
    checkToggleStatus(status);
    checkToggleNewsletter(news);
}

//paginate the table and calls the "loadSideBarEffectsScripts" function.
function paginateTableAndLoadSideBarScripts(table, limit) {
    paginateTable(table, limit);
    loadSideBarEffectsScripts();
}

//saves the unedited user into an object to then compare with the submitted user and see if there are any changes.
function feedUneditedUser(Table_user) {

    Unedited_user['Id'] = String(Table_user.Id);
    Unedited_user['Username'] = Table_user.Username;
    Unedited_user['Email'] = Table_user.Email;
    Unedited_user['Newsletter'] = Table_user.Newsletter;
    Unedited_user['Picture'] = Table_user.Picture;
    Unedited_user['Password'] = $.session.get('UserPassword');
}

//gets all user and displays them.
function GetUsers() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllUsers",
        data: "",
        dataType: "json",
        success: function (data) {
            clearTable(tbl_users_body);
            if (data.d.length > 0) {
                let ran_if = false;
                $.each(data.d, function (index, value) {
                    if (value.CurrentUserHistory.AfterState.Description !== "Pending") {
                        ran_if = true;
                        tbl_users_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width:8%;\" class=\"text-center\"><input class=\"check_all\" type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/users/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td style=\"width:13%;\">" + value.CurrentUserHistory.AfterState.Description + "</td>  <td style=\"width:13%;\"> " + (value.Newsletter ? "Yes" : "No") + " </td> <td style=\"width:10%;\" class=\"st-trigger-effects\"><a class=\"btn_edit\" data-effect=\"st-effect-1\"><i class=\"glyphicon glyphicon-pencil\"></i></a></td> </tr>");
                    }
                });
                if (ran_if) {
                    paginateTableAndLoadSideBarScripts(tbl_users, 3);
                    assignBtnEditClickEvent();
                    $(".se-pre-con").fadeOut();
                } else {
                    $(".se-pre-con").fadeOut();
                    swal({
                        title: "Info!",
                        text: "There are no user to display.",
                        icon: "info",
                        timer: 3000
                    });
                    tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No users to display! <td></td><td></td><td></td></td></tr>");
                }
            }
            else {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Info!",
                    text: "There are no user to display.",
                    icon: "info",
                    timer: 3000
                });
                tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No users to display! <td></td><td></td><td></td></td></tr>");
            }
        },
        error: function (data, status, error) {
            swal({
                title: "Error!",
                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                icon: "warning",
                timer: 3000
            });
        }
    });
}

//gets the clicked user and puts their values into the form.
function GetClickedUserToForm(id) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetUserById",
        data: "{Id: " + JSON.stringify(id) + "}",
        dataType: "json",
        statusCode: {
            404: function (data) {
                swal({
                    title: "Oops!",
                    text: "This user no longer exists...",
                    icon: "info",
                    timer: 3000
                }).then((value) => {
                    location.reload(true);
                });
            },
            500: function (data) {
                swal({
                    title: "Oops!",
                    text: "Sorry, we are currently unable to fulfill your request!",
                    icon: "info",
                    timer: 3000
                }).then((value) => {
                    location.reload(true);
                });
            }
        },
        success: function (data) {
            clearForm();
            if (data.d !== null) {
                user_photo.attr('src', '/resources/imgs/users/' + data.d.Picture);
                photo_real_name.val(data.d.Picture);
                feedUneditedUser(data.d);
                input_username.val(data.d.Username);
                input_username.attr('user_id', data.d.Id);
                input_email.val(data.d.Email);
                toggleBothFormToggles(data.d.CurrentUserHistory.AfterState, data.d.Newsletter);
                disableFormTextArea();
                old_description.text(data.d.CurrentUserHistory.Description);
                old_description.each(function () {
                    $(this).height(0).height(this.scrollHeight);
                }).find('textarea').change();
                $.session.set("UserPassword", data.d.Password);
            }
        },
        error: function (data, status, error) {
            swal({
                title: "Error!",
                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                icon: "warning",
                timer: 3000
            });
        }
    });
}

//validates form before send the data to server and shows a custom error message if there is something wrong.
function validateForm() {
    var validated = true;
    $(".has-error").removeClass("has-error");

    if (!is_text_area_disabled) {
        if (txt_description.val() === "") {
            txt_description.closest(".form-group").addClass("has-error");
            error.fadeIn();
            error.find('.message').text("Please fill in the description field.");
            validated = false;
        }
    }

    if (input_email.val() === "") {
        input_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the e-mail field.");
        validated = false;
    }
    if (!isEmail(input_email.val())) {
        input_email.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please input a valid email.");
        validated = false;
    }
    if (input_email.val().length > 100) {
        input_username.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The email must be less than 100 characters.");
        validated = false;
    }

    if (input_username.val() === "") {
        input_username.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the username field.");
        validated = false;
    }
    if (input_username.val().length > 50) {
        input_username.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The username must be less than 50 characters.");
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

//compares two given users to check if something has changed to then update the user or not. 
//This will prevent a large amount of unnecessary calls to the server.
function isEquivalent(User1, User2) {

    var User1Props = Object.getOwnPropertyNames(User1);
    var User2Props = Object.getOwnPropertyNames(User2);

    if (User1Props.length !== User2Props.length) {
        return false;
    }

    for (var i = 0; i < User1Props.length; i++) {
        var prop = User1Props[i];

        if (User1[prop] !== User2[prop]) {
            return false;
        }
    }

    return true;
}

//checks if the user state has changed after form submission.
function userStateHasChanged(description) {
    if (description !== "") {
        return true;
    } else {
        return false;
    }
}

//calls "validateForm" function and submit the changes if something has changed and if the form is valid.
function validateAndSubmit() {
    if (!validateForm()) {
        return;
    }
    var User = {};
    var UserHistory = {};
    var BeforeUserState = {};
    var AfterUserState = {};
    var Admin = {};
    var user_has_changed = true;
    var ajax_url = "";
    var ajax_data = "";

    Admin['Id'] = $.session.get('AdminId') === "" ? 1 : $.session.get('AdminId');

    User['Id'] = input_username.attr('user_id');

    User['Username'] = input_username.val();

    User['Email'] = input_email.val();
    User['Newsletter'] = toggle_newsletter.prop('checked');
    User['Password'] = $.session.get('UserPassword');

    UserHistory['Admin'] = Admin;

    BeforeUserState['Id'] = toggle_status.attr('status_id');
    UserHistory['BeforeState'] = BeforeUserState;

    AfterUserState['Id'] = toggle_status.prop('checked') ? toggle_status.attr('granted_id') : toggle_status.attr('blocked_id');
    UserHistory['AfterState'] = AfterUserState;
    UserHistory['Description'] = txt_description.val();

    User['Picture'] = photo_real_name.val();

    UserHistory['User'] = User;


    if (userStateHasChanged(txt_description.val())) {
        ajax_url = "UpdateUserAndUserHistory";
    } else if (!isEquivalent(User, Unedited_user)) {
        ajax_url = "UpdateUser";
    } else {
        ajax_url = undefined;
        user_has_changed = false;
    }



    if (ajax_url === "UpdateUser") {
        ajax_data = "{User: " + JSON.stringify(User) + "}";
    } else if (ajax_url === "UpdateUserAndUserHistory") {
        ajax_data = "{User: " + JSON.stringify(User) + ", UserHistory:" + JSON.stringify(UserHistory) + "}";
    } else {
        ajax_data = undefined;
    }

    //confrimation
    if (user_has_changed) {
        swal({
            title: "Are you sure?",
            text: "If necessary, you can change this later.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "../WebService.asmx/" + ajax_url,
                        data: ajax_data,
                        dataType: "json",
                        success: function (data) {
                            swal({
                                title: "Success!",
                                text: "User successfully updated!",
                                icon: "success",
                                timer: 3000
                            }).then((value) => {
                                window.location.reload();
                                //GetUsers();
                            });
                        },
                        error: function (data, status, error) {
                            swal({
                                title: "Error!",
                                text: " " + (error.message === undefined ? "Sorry, we are currently unable to fulfill your request!" : error.message) + " ",
                                icon: "warning",
                                timer: 3000
                            });
                        }
                    });


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



//CALLS
GetUsers();



//EVENTS
user_photo_input.change(function () {
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = loadImage;
        reader.readAsDataURL(this.files[0]);

        photo_real_name.val("");
        photo_real_name.val(this.files[0].name);
        console.log(photo_real_name.val());
    }
});

$('.st-pusher').click(function () {
    is_code_changed = false;
});

btn_cancel.on("click", function () {
    $('.st-pusher').trigger('click');
});

$(document).keydown(function (e) {
    if (e.keyCode === 27) {
        $('.st-pusher').trigger('click');
    }
});

toggle_status.on('change', function (ev) {
    ev.preventDefault();
    if (!is_code_changed) {
        if (is_text_area_disabled) {
            enableFormTextArea();
        } else {
            disableFormTextArea();
        }
    } else {
        is_code_changed = false;
    }
});

btn_submit.click(function () {
    validateAndSubmit();
});


console.log('READY users.js');
