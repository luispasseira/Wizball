<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="BackOffice.pages.Newsletter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Wizball - Newsletter</title>

    <!-- Stylesheets section -->

    <!-- Favicon img -->
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />

    <!-- Bootstrap and font-awesome stylesheets -->
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link href="/resources/css/plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/resources/css/plugins/animations/animate.css" rel="stylesheet" />

    <!-- Global BackOffice stylesheet -->
    <link href="/resources/css/style_all.css" rel="stylesheet" />
</head>
<body>
    <div hidden="hidden" class="se-pre-con"></div>
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
                    <li><a href="Users.aspx">USERS</a></li>
                    <li><a href="UserRequests.aspx">USER REQUESTS</a></li>
                    <li class="active"><a>NEWSLETTER</a></li>
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
                        <h3>Newsletter</h3>
                        <div class="col-12 col-xs-12">
                            <button id="reset_newsletter" style="width: 120px" class="btn btn-primary">Reset</button>
                            &nbsp;
                            <button id="send_newsletter" style="width: 120px" class="btn btn-primary">Send&nbsp;&nbsp;<span class="glyphicon glyphicon-share-alt"></span></button>

                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12">
                                <!-- list/table-->
                                <div class="content table-full-width" style="position: relative;">
                                    <div>
                                        <br />
                                        <div id="error_message" class="form-fonte alert alert-danger" role="alert" style="display: none">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="false"></span>
                                            <span class="sr-only">Error:</span>
                                            <span class="message"></span>
                                        </div>
                                        <div class="form-group">
                                            <label class="label">Subject</label>
                                            <input type="text" id="input_newsletter_subject" class="form-control" placeholder="Write something flashy" />
                                        </div>
                                        <div class="form-group">
                                            <label class="label">Body</label>
                                            <textarea id="txt_newsletter_body" rows="15" cols="50" class="form-control" placeholder="Please don't include greetings"></textarea>
                                        </div>
                                    </div>
                                </div>
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

    <!-- Newsletter script -->
    <script src="/resources/js/newsletter.js"></script>
</body>

</html>
