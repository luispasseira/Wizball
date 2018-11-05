
//HTML ELEMENTS
var data_table = $('#data_table');
var data_table_head = $('#data_table_head');
var data_table_body = $('#data_table_body');

//VARS

//is used to validate whether a synchronization method was successful or not.
var is_sync = false;

//ARRAYS
//contains all areas. The index is the id and the value is the name.
var Areas = [];

var past_matches = [];

var MatchesIds = [];

var tips_by_match = [];



//FUNCTIONS
//fills the table head according to the given entity.
function fillContentTableHead(entity) {
    clearTable(data_table_head);
    if (entity.toLowerCase() === "next_matches") {
        data_table_head.append("<tr> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Competition<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Home team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:8%\" class=\"text-center\"></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Away team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:18%\" class=\"text-center\"><a class=\"order-by-desc\">Date<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else if (entity.toLowerCase() === "teams") {
        data_table_head.append("<tr> <th style=\"width:10%\" class=\"text-center\"><a class=\"order-by-desc\">TLA<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\">Logo</th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Short name<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Full name<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Region<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th>  <th style=\"width:20%\" class=\"text-center\"><a class=\"order-by-desc\">Website<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else if (entity.toLowerCase() === "played_matches") {
        data_table_head.append("<tr> <th style=\"width:10%\" class=\"text-center\"><a class=\"order-by-desc\">Competition<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:14%\" class=\"text-center\"><a class=\"order-by-desc\">Home team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:8%\" class=\"text-center\"></th> <th style=\"width:10%\" class=\"text-center\"></th> <th style=\"width:14%\" class=\"text-center\"><a class=\"order-by-desc\">Away team<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:14%\" class=\"text-center\"><a class=\"order-by-desc\">Date<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\"><a class=\"order-by-desc\">Bet<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> <th style=\"width:10%\" class=\"text-center\"><a class=\"order-by-desc\">Result<i class=\"glyphicon glyphicon-chevron-down\"></i></a></th> </tr>");
    } else {
        swal({
            title: "Error!",
            text: "Could not load content table header.",
            icon: "warning",
            timer: 3000
        }).then((value) => {
            location.reload(true);
        });
    }
}

//fills the table body according to the given entity.
function fillDataTableBody(entity, values) {
    clearTable(data_table_body);
    if (entity.toLowerCase() === "next_matches") {
        let bet_no_bet = false;
        let tip = "";
        $.each(values, function (index, value) {
            MatchesIds.push(value.Id);
            if (tips_by_match[value.Id] === undefined) {
                tip = "Refresh page";
            } else {
                bet_no_bet = tips_by_match[value.Id].BetNoBet;
                if (bet_no_bet) {
                    tip = tips_by_match[value.Id].Forecast ? "+2,5" : "-2,5";
                } else {
                    tip = "No bet";
                }
            }

            data_table_body.append("<tr value=\"" + value.Id + "\"> <td style=\"width:18%\">" + value.Competition.Name + "</td> <td style=\"width:18%\">" + value.HomeTeam.Name + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.HomeTeam.Area.Name.toLowerCase() + "/" + value.HomeTeam.Flag + "\" /></span></td> <td style=\"width:8%\" class=\"no-users\">" + tip + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + value.AwayTeam.Area.Name.toLowerCase() + "/" + value.AwayTeam.Flag + "\" /></span></td> <td style=\"width:18%\">" + value.AwayTeam.Name + "</td> <td style=\"width:18%\">" + value.UtcDate + "</td> </tr>");
        });
    } else if (entity.toLowerCase() === "teams") {
        $.each(values, function (index, value) {
            data_table_body.append("<tr value=\"" + value.Id + "\">  <td style=\"width:10%\">" + value.TLA + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + Areas[value.Area.Id].toLowerCase() + "/" + value.Flag + "\" /></span></td> <td style=\"width:20%\">" + value.ShortName + "</td> <td style=\"width:20%\">" + value.Name + "</td> <td style=\"width:20%\">" + Areas[value.Area.Id] + "</td> <td style=\"width:20%\"> <a class=\"order-by-desc\" href=\"" + value.WebSite + "\" target=\"_blank\">" + value.WebSite + "&nbsp;<i class=\"glyphicon glyphicon-share-alt\"></i></a></td> </tr>");
        });
    } else if (entity.toLowerCase() === "played_matches") {
        let tip = "";
        let result = "";
        for (var i = 0; i < values.length; i++) {
            if (tips_by_match[values[i].Id] === undefined) {
                tip = "Refresh page";
                result = "Refresh page";
            } else {
                let bet_no_bet = tips_by_match[values[i].Id].BetNoBet === undefined ? false : tips_by_match[values[i].Id].BetNoBet;
                if (bet_no_bet) {
                    tip = tips_by_match[values[i].Id].Forecast ? "+2,5" : "-2,5";
                    result = tips_by_match[values[i].Id].Result ? "Win" : "Loss";
                } else {
                    tip = "No bet";
                    result = "---";
                }
            }


            data_table_body.append("<tr value=\"" + values[i].Id + "\"> <td style=\"width:10%\">" + values[i].Competition + "</td> <td style=\"width:14%\">" + values[i].HomeTeamName + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + values[i].HomeTeamFlag + "\" /></span></td> <td style=\"width:8%\" class=\"no-users\">" + values[i].ScoreHome + " - " + values[i].ScoreAway + "</td> <td><span style=\"width:10%;\" class=\"avatar avatar-online\"><img src=\"/resources/imgs/teams/" + values[i].AwayTeamFlag + "\" /></span></td> <td style=\"width:14%\">" + values[i].AwayTeamName + "</td> <td style=\"width:14%\">" + values[i].Date + "</td> <td style=\"width:10%\" class=\"no-users\">" + tip + "</td> <td style=\"width:10%\" class=\"no-users\">" + result + "</td> </tr>");
        }

    } else {
        swal({
            title: "Error!",
            text: "Could not load content table body.",
            icon: "warning",
            timer: 3000
        }).then((value) => {
            location.reload(true);
        });
    }
    paginateTable(data_table, 5);
}

//adds passed matches to past_matches array
function addMatchesToPastMatchesArray(matches) {

    //only for matches that ended at 90 mins
    past_matches = [];

    $.each(matches, function (index, match) {
        let single_match = {};
        single_match['Id'] = match.Id;
        single_match['HomeTeamName'] = match.HomeTeam.ShortName;
        single_match['HomeTeamFlag'] = match.HomeTeam.Area.Name.toLowerCase() + "/" + match.HomeTeam.Flag;
        single_match['AwayTeamName'] = match.AwayTeam.ShortName;
        single_match['AwayTeamFlag'] = match.AwayTeam.Area.Name.toLowerCase() + "/" + match.AwayTeam.Flag;;
        single_match['Competition'] = match.Competition.Name;
        single_match['ScoreHome'] = match.Score.FullTime.HomeTeam;
        single_match['ScoreAway'] = match.Score.FullTime.AwayTeam;
        single_match['Date'] = match.UtcDate;

        past_matches.push(single_match);
    });

}

//gets all the areas vai ajax and places them in an array where the index is the id of the Area and the value is the respective name.
function GetAllAreasToArr() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllAreas",
        data: "",
        dataType: "json",
        success: function (data) {
            $.each(data.d, function (index, value) {
                Areas[value.Id] = value.Name;
            });
        },
        error: function (data, status, error) {
            console.log("Error 500 getting areas");
        }
    });
}

//synchronizes the matches that exist in the API with those that exist in the database and updates all that data.
function MatchesSync() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SyncMatchesTierOne",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function (data, status, error) {
            is_sync = false;
        }
    });
}

//synchronizes the teams that exist in the API with those that exist in the database and updates all that data.
function TeamsSync() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SyncTeams",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function (data, status, error) {
            is_sync = false;
        }
    });
}

//synchronizes all the data that exist in the API with those that exist in the database and updates all that.
function FullDatabaseSync() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/FullDatabaseSync",
        data: "",
        dataType: "json",
        success: function (data) {
            is_sync = false;
            if (data.d) {
                is_sync = true;
            }
            else {
                is_sync = false;
            }
        },
        error: function () {
            is_sync = false;
        }
    });
}

//alert, and if the action is confirmed, performs a synchronization method depending on the given entity.
function alertAndSyncEntity(entity) {

    swal({
        title: "Are you sure?",
        text: "This may take a few seconds.",
        icon: "warning",
        buttons: true
    }).then((willDelete) => {
        if (willDelete) {
            var time = 15000;
            switch (entity.toLowerCase()) {
                case "teams":
                    is_sync = false;
                    TeamsSync();
                    break;
                case "matches":
                    is_sync = false;
                    MatchesSync();
                    break;
                case "data":
                    is_sync = false;
                    FullDatabaseSync();
                    time = 140000;
                    break;
            }

            entity.toLowerCase().replace(/\b[a-z]/g).toUpperCase();

            swal({
                title: "Synchronizing " + entity.toLowerCase(),
                text: "Please wait a few seconds...",
                icon: "info",
                timer: time,
                buttons: false,
                closeOnEsc: false,
                closeOnClickOutside: false
            }).then((value) => {
                if (is_sync) {
                    swal({
                        title: "Success!",
                        text: "Data synchronized successfully.",
                        icon: "success",
                        timer: 3000
                    }).then((value) => {
                        switch (entity.toLowerCase()) {
                            case "teams":
                                GetTeams();
                                break;
                            case "matches":
                                generateNextMatchesTips();
                                break;
                            default:
                                generateNextMatchesTips();
                        }
                    });
                } else {
                    swal({
                        title: "Info!",
                        text: "Could not sync " + entity.toLowerCase() + "...",
                        icon: "info",
                        timer: 3000
                    });
                }
            });
        } else {
            swal({
                title: "Cancelled!",
                text: "",
                icon: "info",
                timer: 3000
            });
        }
    });
}

//gets all the teams from the database. if there are no teams will be presented an alert to perform 
//a full sync. if the admin does not perform this action, he will be redirected to the user requests management
//page if there are requests, otherwise it will be redirected to the users management page.
function GetTeams() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllTeams",
        data: "",
        dataType: "json",
        success: function (data) {
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
                fillContentTableHead("teams");
                fillDataTableBody("teams", data.d);
                $(".se-pre-con").fadeOut();
            }
            else {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "There are no teams at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        full_sync: {
                            closeModal: false,
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                    closeModal: false
                })
                    .then((value) => {
                        switch (value) {
                            case "sync":
                                alertAndSyncEntity("data");
                                break;
                            default:
                                if (user_requests_count <= 0) {
                                    window.location.href = "Users.aspx";
                                } else {
                                    window.location.href = "UserRequests.aspx";
                                }
                        }
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

//gets all the matches from the database. if there are no matches will be presented an alert to perform 
//a full sync. if the admin does not perform this action, he will be redirected to the user requests management
//page if there are requests, otherwise it will be redirected to the users management page.
function GetNextMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetNextMatchesByTierOneCompetitionsWithLocalDate",
        dataType: "json",
        success: function (data) {
            //check if GetNextMatchesByTierOneCompetitions returns more than zero matches
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
                fillContentTableHead("next_matches");
                fillDataTableBody("next_matches", data.d);
                $(".se-pre-con").fadeOut("slow");
            } else if (has_matches) {
                $(".se-pre-con").fadeOut("slow");
                data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> There are no matches for the next few days. <td></td><td></td><td></td></td></tr>");
                swal({
                    title: "Info!",
                    text: "There are no matches for the next few days.",
                    icon: "info",
                    timer: 3000
                });
            } else {
                $(".se-pre-con").fadeOut();
                //if GetNextMatchesByTierOneCompetitions returns zero and data base doenst have matches
                swal({
                    title: "There are no matches at the moment",
                    text: "Please run full sync.",
                    icon: "info",
                    buttons: {
                        sync: {
                            text: "Sync now!",
                            value: "sync"
                        }
                    },
                }).then((value) => {
                    switch (value) {
                        case "sync":
                            FullDatabaseSync();
                            swal({
                                title: "Synchronizing data.",
                                text: "Please wait a few seconds...",
                                icon: "info",
                                timer: 150000,
                                buttons: false,
                                closeOnEsc: false,
                                closeOnClickOutside: false
                            }).then((value) => {
                                if (is_sync) {
                                    swal({
                                        title: "Success!",
                                        text: "Data synchronized successfully.",
                                        icon: "success",
                                        timer: 3000
                                    }).then((value) => {
                                        GetNextMatches();
                                    });
                                } else {
                                    swal({
                                        title: "Info!",
                                        text: "Could not sync data...",
                                        icon: "info",
                                        timer: 3000
                                    });
                                    clearTable(data_table_body);
                                    data_table_body.append("<tr style=\"width:100%;\"><td></td><td></td><td></td><td class=\"text-center no-users\"> No " + entity.toLowerCase() + " to display! <td></td><td></td><td></td></td></tr>");
                                }
                            });
                            break;
                        default:
                            if (user_requests_count <= 0) {
                                window.location.href = "Users.aspx";
                            } else {
                                window.location.href = "UserRequests.aspx";
                            }
                    }
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

//gets all past matches from the last season.
function GetPastMatches() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetPastMatches",
        data: "",
        dataType: "json",
        success: function (data) {
            if ($.fn.DataTable.isDataTable('#data_table')) {
                $('#data_table').DataTable().destroy();
            }

            if (data.d.length > 0) {
                addMatchesToPastMatchesArray(data.d);
                fillContentTableHead("played_matches");
                fillDataTableBody("played_matches", past_matches);
                $(".se-pre-con").fadeOut();
            }
        },
        error: function () {

        }
    });
}

//gets all tips for matches that sys will display to admins to an array "tips_by_match".
function GetTipsToArray() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/GetAllTips",
        data: "",
        dataType: "json",
        success: function (data) {
            $.each(data.d, function (index, value) {
                tips_by_match[value.Match.Id] = value;
            });
            GetNextMatches();
        },
        error: function () {

        }
    });
}

//generates tips for next matches.
function generateNextMatchesTips() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SetNextMatchesTipsAndResults",
        data: "",
        dataType: "json",
        success: function (data) {
            GetTipsToArray();
        },
        error: function () {
            swal("Error", "Something unexpected happened while trying to generate tips", "warning");
        }
    });

}

//generates tips for past matches.
function generatePastMatchesTips() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SetHistoryMatchesTips",
        data: "",
        dataType: "json",
        success: function (data) {
        },
        error: function () {
            swal("Error", "Something unexpected happened while trying to generate tips", "warning");
        }
    });

}



//CALLS
GetAllAreasToArr();
generateNextMatchesTips();
generatePastMatchesTips();



//EVENTS
$('#full_sync').click(function () {
    alertAndSyncEntity("data");
});

$('#sync_matches').click(function () {
    alertAndSyncEntity("matches");
});

$('#sync_teams').click(function () {
    alertAndSyncEntity("teams");
});

$('#show_matches').click(function () {
    $(".se-pre-con").fadeIn();
    GetNextMatches();
});

$('#show_teams').click(function () {
    $(".se-pre-con").fadeIn();
    GetTeams();
});

$('#show_tips').click(function () {
    $(".se-pre-con").fadeIn();
    GetPastMatches();
});


console.log('READY data-management.js');