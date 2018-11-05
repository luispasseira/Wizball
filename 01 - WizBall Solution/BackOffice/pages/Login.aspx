<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BackOffice.pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>WizBall - BackOffice</title>

    <!-- Favicon img -->
    <link rel="shortcut icon" type="image/x-icon" href="/resources/imgs/icon.ico" />

    <!-- Bootstrap and font-awesome stylesheets -->
    <link href="/resources/css/plugins/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    
    <!-- Custom toggle stylesheet -->
    <link href="/resources/css/plugins/toggle/bootstrap2-toggle.min.css" rel="stylesheet" />

    <!-- Global BackOffice stylesheet -->
    <link href="/resources/css/style.css" rel="stylesheet" />
    <link href="/resources/css/estilos.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="animated fadeInDown loginpanel">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="col-md-6 formpanel" style="display: flex; align-items: center;">
                        <div class="middle-box text-center loginscreen animated fadeInDown">
                            <div style="margin: auto;width: 100%;height: 100%;border-radius: 3px;">
                                <h2>WizBall BackOffice</h2>
                                <%--<p>Aqui é feita toda a gestão do <a href="https://google.pt">nosso site</a> para que tenhas os melhores resultados nas tuas apostas!<br /></p>--%>
                                <p>Here we work on <a href="https://google.pt">Wizball website</a> maintenance so you can obtain the best results in your bets!</p>
                                <div class="clearfix"></div>
                                <form name="login" id="form_login" method="post" class="m-t" role="form">
                                    <div id="error_message" class="alert alert-danger" role="alert" style="display: none">
                                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="false"></span>
                                        <span class="sr-only">Error:</span>
                                        <span class="message"></span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" hidden="hidden" class="col-sm-2 control-label">Username</label>
                                        <input id="input_username" name="username" class="form-control" placeholder="Username" value="" required="" />
                                    </div>
                                    <div class="form-group">
                                        <input id="input_password" name="password" type="password" class="form-control" value="" placeholder="Password" required="" />
                                        <i id="eye" class="fa fa-eye showpassword"></i>
                                    </div>
                                    <span id="login" class="btn btn-primary block full-width m-b">Login</span>
                                </form>
                                <p class="m-t"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 wizballpanel">
                    </div>
                </div>
            </div>
        </div>
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
    
    <!-- Login script -->
    <script src="/resources/js/login.js"></script>
</body>

</html>
