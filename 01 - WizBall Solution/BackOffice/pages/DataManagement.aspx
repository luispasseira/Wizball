<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataManagement.aspx.cs" Inherits="BackOffice.pages.DataManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Wizball - Data Management</title>

    <!-- Stylesheets section -->

    <!-- Favicon img -->
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />

    <!-- Bootstrap and font-awesome stylesheets -->
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link href="/resources/css/plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/resources/css/plugins/animations/animate.css" rel="stylesheet" />

    <!-- Custom paging stylesheet -->
    <link href="/resources/css/pagination.css" rel="stylesheet"/>

    <!-- Global BackOffice stylesheet -->
    <link href="/resources/css/style_all.css" rel="stylesheet" />
    <link href="/resources/css/data-table.css" rel="stylesheet" />
</head>
<body>
    <div class="se-pre-con"></div>
    <!-- top navigation bar -->
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="Users.aspx">

                    <img src="/resources/imgs/logo_with_name.png" />
                </a>
            </div>
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar"
                aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <div id="navbar" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a>DATA MANAGEMENT</a></li>
                    <li><a href="Users.aspx">USERS</a></li>
                    <li><a href="UserRequests.aspx">USER REQUESTS</a></li>
                    <li><a href="Newsletter.aspx">NEWSLETTER</a></li>
                </ul>
                <form runat="server">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="UserRequests.aspx"><i id="bell" class="glyphicon glyphicon-bell"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                                aria-expanded="false">
                                <label id="username"></label>
                                <span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu">
                                <li><a class="drop-a" href="Profile.aspx">Profile</a></li>
                                <li>
                                    <asp:Button ID="Btn_logout" OnClick="Btn_logout_Click" runat="server" CssClass="drop-a" Text="Logout" /></li>
                            </ul>
                        </li>
                    </ul>
                </form>
            </div>
        </div>
    </nav>
    <!-- / top navigation bar -->

    <div id="st-container" class="st-container st-effect-1">

        <!-- Central content -->
        <div class="st-pusher">
            <div class="st-content">

                <div class="head-container">

                    <!-- title -->

                    <div class="row text-center">
                        <h3>Data Management</h3>
                        <div class="col-12 col-xs-12">
                            <button id="full_sync" style="width: 120px" class="btn btn-primary">Full sync</button>
                            <button id="sync_matches" style="width: 120px" class="btn btn-primary">Sync matches</button>
                            <button id="sync_teams" style="width: 120px" class="btn btn-primary">Sync teams</button>
                            <button id="show_tips" style="width: 120px" class="btn btn-primary">Tips history</button>
                            <button id="show_matches" style="width: 120px" class="btn btn-primary">Matches</button>
                            <button id="show_teams" style="width: 120px" class="btn btn-primary">Teams</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="body-container">
                    <div class="row">
                        <div class="col-lg-12">
                            <!-- list/table-->
                            <div class="content table-full-width" style="position: relative;">
                                <table id="data_table" class="table table-hover text-center">
                                    <thead id="data_table_head" class="text-center">
                                    </thead>
                                    <tbody id="data_table_body" class="text-center">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- / Central content -->

    </div>
    <!-- Scripts Section-->

    <!-- JQuery scripts -->
    <script src="/resources/js/plugins/jquery/jquery.min.js"></script>
    <script src="/resources/js/plugins/jquery/jquery-ui.min.js"></script>

    <!-- Custom table paging script -->
    <script src="/resources/js/plugins/pagination/data-table-options.js"></script>
    <script src="/resources/js/plugins/pagination/data-tables.js"></script>

    <!-- Bootstrap script -->
    <script src="/resources/js/plugins/bootstrap/bootstrap.min.js"></script>

    <!-- Custom alert script -->
    <script src="/resources/js/plugins/sweetalert/sweetalert.min.js"></script>

    <!-- JQuery session script -->
    <script src="/resources/js/plugins/jquery/jquery.session.js"></script>

    <!-- Notifications script -->
    <script src="/resources/js/plugins/notification/bootstrap-notify.js"></script>

    <!-- General script -->
    <script src="/resources/js/general.js"></script>

    <!-- Data management script -->
    <script src="/resources/js/data-management.js"></script>
</body>
</html>
