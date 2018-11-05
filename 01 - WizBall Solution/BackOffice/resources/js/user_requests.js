
//HTML ELEMENTS
var btn_grant_all_users = $('#grant_all_users');
var btn_revoke_all_users = $('#revoke_all_users');

//ARRAYS
//contains all user ids to grant/revoke.
var pending_users_ids = [];



//FUNCTIONS
//remove action buttons when there are no user requests.
function removeActionButtons() {
    btn_grant_all_users.remove();
    btn_revoke_all_users.remove();
}

//approves or revokes the given user id, depending on given value as "is_granted".
function approveUser(id, is_granted) {
    var permission = "Revoked";

    if (is_granted) {
        permission = "Granted";
    }

    var User = {};
    var UserHistory = {};
    var BeforeUserState = {};
    var AfterUserState = {};
    var Admin = {};

    Admin['Id'] = $.session.get('AdminId') === "" ? 1 : $.session.get('AdminId');

    User['Id'] = id;

    UserHistory['Admin'] = Admin;
    UserHistory['User'] = User;

    BeforeUserState['Id'] = parseInt($('#user_state').attr('user_state'));
    UserHistory['BeforeState'] = BeforeUserState;

    AfterUserState['Id'] = is_granted ? 21 : 11;
    UserHistory['AfterState'] = AfterUserState;

    UserHistory['Description'] = permission + " by " + $.session.get('AdminUsername');

    console.log(UserHistory);

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/InsertUserHistory",
        data: "{UserHistory:" + JSON.stringify(UserHistory) + "}",
        dataType: "json",
        success: function (data) {
            console.log(data.d);
            if (data.d) {
                swal({
                    title: "Success!",
                    text: "User successfully " + permission.toLowerCase() + "!",
                    icon: "success",
                    timer: 3000
                }).then((value) => {
                    //GetPendingUsers();
                    window.location.reload();
                });
            } else {
                swal({
                    title: "Info!",
                    text: "User unsuccessfully " + permission.toLowerCase() + "!",
                    icon: "warning",
                    timer: 3000
                }).then((value) => {

                });
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

//assigns actions to all buttons on tabla.
function assignActionBtnClickEvents() {

    $('.btn_grant').on("click", function () {
        swal({
            title: "Are you sure?",
            text: "If necessary, you can change this later.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    approveUser($(this).closest("tr").attr('value'), true);
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });

    });

    $('.btn_revoke').on("click", function () {
        swal({
            title: "Are you sure?",
            text: "If necessary, you can change this later.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    approveUser($(this).closest("tr").attr('value'), false);
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });
    });
}

//gets pending users to table.
function GetPendingUsers() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllUsers",
        data: "",
        dataType: "json",
        success: function (data) {
            tbl_users_body.empty();
            if (data.d.length > 0) {
                let ran_if = false;
                let i = 0;
                $.each(data.d, function (index, value) {
                    if (value.CurrentUserHistory.AfterState.Description === "Pending") {
                        ran_if = true;
                        pending_users_ids[i] = value.Id;
                        i++;
                        tbl_users_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width: 8%;\" class=\"text-center\"><input user_id=\"" + value.Id + "\" class=\"check-all\" type=\"checkbox\"/></td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/Users/" + value.Picture + "\" /></span></td>  <td style=\"width:17%;\">" + value.Username + "</td> <td style=\"width:29%;\">" + value.Email + "</td> <td id=\"user_state\" user_state=\"" + value.CurrentUserHistory.AfterState.Id + "\" style=\"width:16%;\">" + value.CurrentUserHistory.AfterState.Description + "</td> <td style=\"width:10%;\"><a class=\"btn_grant\"><i class=\"glyphicon glyphicon-ok\"></i></a></td> <td style=\"width:10%;\"><a class=\"btn_revoke\"><i class=\"glyphicon glyphicon-trash\"></i></a></td></tr>");
                    }
                });
                if (ran_if) {
                    paginateTable(tbl_users, 3);
                    assignActionBtnClickEvents();
                    $(".se-pre-con").fadeOut();
                } else {
                    $(".se-pre-con").fadeOut();
                    swal({
                        title: "Info!",
                        text: "There are no user requests at the moment.",
                        icon: "info",
                        timer: 3000
                    });
                    removeActionButtons();
                    tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No user requests to display! <td></td><td></td><td></td></td></tr>");
                }
            }
            else {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Info!",
                    text: "There are no user requests at the moment.",
                    icon: "info",
                    timer: 3000
                });
                removeActionButtons();
                tbl_users.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No user requests to display! <td></td><td></td><td></td></td></tr>");
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

//approves or revokes given users, depending on given value as "is_granted".
function aproveAllUsers(ids, is_granted) {
    var permission = "Revoked";

    if (is_granted) {
        permission = "Granted";
    }

    for (i = 0; i < ids.length; i++) {
        approveUser(ids[i], is_granted);
    }

    swal({
        title: "Success!",
        text: "Users successfully " + permission.toLowerCase() + "!",
        icon: "success",
        timer: 3000
    }).then((value) => {
        //GetPendingUsers();
        window.location.reload();
    });

}



//CALLS
GetPendingUsers();



//EVENTS
btn_grant_all_users.click(function () {
    console.log(checked_user_ids);
    if (checked_user_ids.length > 0) {
        // any user is checked
        swal({
            title: "Are you sure?",
            text: "This action will grant selected users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    for (var i = 0; i < checked_user_ids.length; i++) {
                        approveUser(checked_user_ids[i], true);
                    }
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });
    }
    else {
        swal({
            title: "Are you sure?",
            text: "This action will grant all users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveAllUsers(pending_users_ids, true);
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });
    }
});

btn_revoke_all_users.click(function () {
    if (checked_user_ids.length > 0) {
        // any user is checked
        swal({
            title: "Are you sure?",
            text: "This action will revoke selected users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    for (var i = 0; i < checked_user_ids.length; i++) {
                        approveUser(checked_user_ids[i], false);
                    }
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });
    }
    else {
        swal({
            title: "Are you sure?",
            text: "This action will revoke all users.",
            icon: "warning",
            buttons: true
        })
            .then((willDelete) => {
                if (willDelete) {
                    aproveAllUsers(pending_users_ids, false);
                } else {
                    swal({
                        title: "Cancelled!",
                        icon: "info",
                        timer: 2500
                    });
                }
            });
    }
});


console.log('READY user_requests.js');
