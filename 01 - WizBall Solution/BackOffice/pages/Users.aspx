<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BackOffice.pages.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Wizball - Users</title>

    <!-- Stylesheets section -->

    <!-- Favicon img -->
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />

    <!-- Bootstrap and font-awesome stylesheets -->
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link href="/resources/css/plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/resources/css/plugins/animations/animate.css" rel="stylesheet" />

    <!-- Custom paging stylesheet -->
    <link href="/resources/css/pagination.css" rel="stylesheet" />

    <!-- Custom toggle stylesheet -->
    <link href="/resources/css/plugins/toggle/bootstrap2-toggle.min.css" rel="stylesheet" />

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
                    <li><a href="DataManagement.aspx">DATA MANAGEMENT</a></li>
                    <li class="active"><a>USERS</a></li>
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
        <!-- lateral form edit -->
        <div class="st-menu st-effect-1" id="menu-1">
            <form class="row form-horizontal" id="form_edit_user" name="form_edit_user" method="post">

                <div id="error_message" class="form-fonte alert alert-danger" role="alert" style="display: none">
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="false"></span>
                    <span class="sr-only">Error:</span>
                    <span class="message"></span>
                </div>

                <div class="col-lg-12">
                    <h4 style="padding-left: 4%;">Edit user </h4>
                </div>
                <div class="col-lg-3">
                    <div class="image-upload">
                        <label for="photo">
                            <img id="user_photo" src="" />
                        </label>

                        <input id="photo" name="photo" type="file" />
                        <input hidden="hidden" id="photo_nme" value="" />
                    </div>
                </div>
                <div class="col-lg-9 form-group">
                    <div class="col-lg-9 mt-2 col-md-12">
                        <label class="label" for="username">Username</label><br />
                        <input id="input_edit_username" maxlength="50" name="input_edit_username" user_id="0" required="" type="text" />
                    </div>
                    <div class="col-lg-3 mt-2 col-md-12">
                        <label class="label" for="select_edit_status">State</label><br />
                        <input id="toggle_edit_status" granted_id="21" blocked_id="11" name="select_edit_status" data-on="Active" data-off="Blocked" type="checkbox" data-toggle="toggle" data-onstyle="success" data-offstyle="danger" data-width="87" />
                    </div>

                    <div class="col-lg-9 mt-2 col-md-12">
                        <label class="label" for="input_edit_email">E-Mail</label><br />
                        <input id="input_edit_email" maxlength="100" name="input_edit_email" required="" type="email" />
                    </div>
                    <div class="col-lg-3 mt-2 col-md-12">
                        <label class="label" for="input_edit_newsletter">Newsletter</label><br />
                        <input id="toggle_edit_newsletter" name="input_edit_newsletter" data-on="Yes" data-off="No" type="checkbox" data-toggle="toggle" data-width="87" />
                    </div>

                    <div class="col-lg-12 mt-2 col-md-12">
                        <label class="label" for="old_description">Current state description</label><br />
                        <textarea disabled="disabled" style="resize: none;" rows="1" class="col-lg-6" id="old_description" name="old_description" placeholder=""></textarea>
                    </div>

                    <div class="col-lg-12 mt-2 col-md-12">
                        <label class="label" for="input_edit_description">Description:</label><br />
                        <textarea disabled="disabled" style="resize: none; height: 200px" class="col-lg-6" id="txt_edit_description" name="input_edit_description" placeholder=""></textarea>
                    </div>

                    <div class="col-lg-12 clearfix"></div>
                    <div class="col-lg-6 st-menu-buttons">
                        <button id="btn_can" class="btn btn-default" type="button">Cancel</button>
                    </div>
                    <div class="col-lg-6 st-menu-buttons">
                        <button id="btn_submit" class="btn btn-primary" type="button">Submit</button>
                    </div>
                </div>

            </form>
        </div>
        <!-- / lateral form edit -->


        <!-- Central content -->
        <div class="st-pusher">
            <div class="st-content">

                <div class="head-container">

                    <!-- title -->

                    <div class="row text-center">
                        <h3>Users</h3>
                    </div>
                </div>
                <br />
                <div class="body-container">
                    <div class="row">
                        <div class="col-lg-12">
                            <!-- list/table-->
                            <div class="content table-full-width" style="position: relative;">
                                <table id="users_table" class="table table-hover text-center">
                                    <thead class="text-center">
                                        <tr>
                                            <th style="width: 8%;" class="text-center">
                                                <input id="check-all" class="checkbox-change" type="checkbox" /></th>
                                            <th style="width: 10%;" class="text-center">Photo</th>
                                            <th style="width: 17%;" class="text-center"><a class="order-by-desc">Username<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 29%;" class="text-center"><a class="order-by-desc">E-mail<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 13%;" class="text-center"><a class="order-by-desc">Status<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 13%;" class="text-center"><a class="order-by-desc">Newsletter<i class="glyphicon glyphicon-chevron-down"></i></a></th>
                                            <th style="width: 10%;" class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="users_table_body" class="text-center">
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

    <!-- Custom toggle script -->
    <script src="/resources/js/plugins/toggle/bootstrap2-toggle.min.js"></script>

    <!-- Side bar effects scripts -->
    <script src="/resources/js/plugins/sidebar/classie.js"></script>
    <script src="/resources/js/plugins/sidebar/sidebar-effects.js"></script>

    <!-- Custom alert script -->
    <script src="/resources/js/plugins/sweetalert/sweetalert.min.js"></script>

    <!-- JQuery session script -->
    <script src="/resources/js/plugins/jquery/jquery.session.js"></script>

    <!-- Notifications script -->
    <script src="/resources/js/plugins/notification/bootstrap-notify.js"></script>

    <!-- General script -->
    <script src="/resources/js/general.js"></script>

    <!-- Users script -->
    <script src="/resources/js/users.js"></script>
</body>
</html>
