<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewRecoverPassword.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewRecoverPassword2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

    <!-- jQuery -->
    <script src="../Public/jQuery/jQuery.min.js"></script>

    <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- Fontawesome -->
    <link href="../Public/Fontawesome/css/all.min.css" rel="stylesheet" />

    <!-- ViewRegistration CSS Styling -->
    <link href="../Public/Styling/ViewRecoverPassword.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <!-- Background Img -->
        <div id="background">
        </div>

        <!-- Recover password form -->
        <div class="form-wrapper">

            <div class="form-header">
                
                <a title="Home" href="/Pages/ViewHome.aspx"><img src="../Public/Imgs/Wizball/logo_dark.png" /></a>
           
            </div>
           
            <div class="form-body">

                <h5 runat="server" id="title">Recover password</h5>
                <hr />
                
                <div class="form-groups">
                    <asp:Label ID="lblEmail" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Email"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="emailStatus" runat="server"></small></span>
                </div>               

                <asp:Button ID="btnSubmit" CssClass="btn btn-success form-submit" runat="server" Text="Submit" OnClientClick="return isFormValid()" />

            </div>
            
        </div>

         
        
        <div id="outterModal" class="outter-modal" runat="server">

            <div id="inner-modal">

                <div id="modal-header">
                    <a href="/Pages/ViewHome.aspx"><img id="modal-logo" src="/Public/Imgs/Wizball/logo_dark.png" /></a>
                    <i   id="modal-close" class="fas fa-times-circle fa-lg"></i>
                </div>
              
                <div id="modal-message">
                    <p id="modal-primary-message">Please check your email for more informations</p>  
                </div>
               
                <div id="modal-footer">
                    <h6 id="modal-counter-message">back to home... <span id="modal-counter">20</span></h6>
                </div>
                
            </div>

        </div>



        <!-- Javascript -->
        <script src="/Public/Javascript/ViewRecoverPassword.js"></script>

    </form>
</body>
</html>
