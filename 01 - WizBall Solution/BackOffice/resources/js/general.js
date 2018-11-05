
//GLOBAL SCOPE
//GLOBAL HTML ELEMENTS
var tbl_users = $('#users_table');
var tbl_users_body = $('#users_table_body');
var users_table_foot = $('#users_table_foot');
var pagination = $('#pg_users_table');

var session_label_username = $('#username');
var cb_check_all_users = $('#check-all');

//GLOBAL VARS
var user_requests_count = 0;
var has_next_tips = false;

var bell = $('#bell');
var error = $('#error_message');

//save the value if there are matches in the database or not.
var has_matches = undefined;

//save the value if there are tips in the database or not.
//var has_tips = false;

//GLOBAL ARRAYS
//contains checked users ids to do an action (just grant/revoke at the moment).
var checked_user_ids = [];



//GLOBAL FUNCTIONS
//clear the content of the given table.
function clearTable(table) {
    table.empty();
}

//uncheck all checked checkboxes with "check-all" as class.
function uncheckCheckedCheckbox() {
    $('.check-all').prop('checked', false);
}

//gets the users ids of those who have been selected and save them in an array.
function GetCheckedUserIdsToArray() {
    checked_user_ids = $('.check-all').filter(":checked").map(function () {
        return $(this).attr('user_id');
    }).get();
}

//creates pages in the given table.
function paginateTable(table, limit) {
    table.DataTable({
        destroy: true,
        "pageLength": limit,
        "bLengthChange": false,
        "bAutoWidth": false,
        "fnDrawCallback": function (oSettings) {
            $('#check-all').on('change', function () {
                GetCheckedUserIdsToArray();
            });
            uncheckCheckedCheckbox();
            $('.check-all').on('change', function () {
                GetCheckedUserIdsToArray();
                console.log(checked_user_ids);
            });
            if (window.location.href.split("/").pop() === "Users.aspx") {
                loadSideBarEffectsScripts();
                assignBtnEditClickEvent();
            }
            if (window.location.href.split("/").pop() === "UserRequests.aspx") {
                assignActionBtnClickEvents();
            }
        }
    });
}

//uses regex to check if the given email is a valid email.
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

//checks if there are matches data in the database and saves that value in "has_matches" so that the code can
//then decide whether to perform a full sync or if there are no matches for the next few days when "GetMatches()" is performed.
function hasMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/MatchesHasRows",
        data: "",
        dataType: "json",
        success: function (data) {
            has_matches = data.d;
        },
        error: function (data, status, error) {
            console.log("Error 500 getting matches top 1");
        }
    });
}

//gets the username of the logged admin and places it on top-right nav.
function GetSessionUsernameToNavbar() {
    session_label_username.text($.session.get('AdminUsername'));
}

//checks if the current page isn't "UserRequests.aspx" and send a notification if there are pending requests.
function notifyUsersRequests(number_user_requests) {
    if (window.location.href.split("/").pop() !== "UserRequests.aspx") {
        if (number_user_requests !== 0) {
            $.notify({
                message: 'You have ' + number_user_requests + ' pending user requests! Click here to see more details.',
                url: "UserRequests.aspx"
            }, {
                    type: 'danger',
                    url_target: ""
                });
            bell.css("color", "#ffd300");
        }

    }
}

//gets the number of user requests and calls "notifyUsersRequests" to notify the logged admin.
function GetPendingUsersCount() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllUsers",
        data: "",
        dataType: "json",
        success: function (data) {
            if (data.d.length > 0) {
                $.each(data.d, function (index, value) {
                    if (value.CurrentUserHistory.AfterState.Description === "Pending") {
                        user_requests_count++;
                    }
                });
                notifyUsersRequests(user_requests_count);
            }
        }
    });
}



//GLOBAL CALLS
hasMatches();
GetPendingUsersCount();
GetSessionUsernameToNavbar();



//GLOBAL EVENTS
$(document).keydown(function (e) {
    if (e.keyCode === 27) {
        $('.st-pusher').trigger('click');
    }
});

cb_check_all_users.change(function () {
    if (this.checked) {
        $('.check-all').prop('checked', true);

    } else {
        uncheckCheckedCheckbox();
    }
});


console.log('READY general.js');
