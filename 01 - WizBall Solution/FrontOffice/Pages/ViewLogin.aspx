<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ViewLogin.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Wizball</title>

    <link rel="shortcut icon" type="image/x-icon" href="../Public/Imgs/Wizball/logo_dark_ico.ico" />

    <!-- Bootstrap 4 -->
    <link href="../Public/Bootstrap/Bootstrap4.css" rel="stylesheet" />

    <!-- ViewLogin CSS Styling -->
    <link href="/Public/Styling/ViewLogin.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

         <!-- Background Img -->
        <div id="background">
        </div>

         <!-- Login form -->
        <div class="form-wrapper">

            <div class="form-header">
                
                <a title="Home" href="/Pages/ViewHome.aspx"><img src="../Public/Imgs/Wizball/logo_dark.png" /></a>
           
            </div>
           
            <div class="form-body">

                <h5 ID="txtHeader" runat="server">User login</h5>
                <hr />
                
                <div class="form-groups">
                    <asp:Label ID="lblUsername" CssClass="form-imputs-labels" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                    <asp:TextBox ID="txtUsername" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Username"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="usernameStatus"></small></span>
                </div>

                <div class="form-groups">
                    <asp:Label ID="lblPassword" CssClass="form-imputs-labels" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>               
                    <asp:TextBox ID="txtPassword" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="passwordStatus"></small></span>
                </div>
                
               <asp:Button ID="btnSubmit" CssClass="btn btn-success form-submit" runat="server" Text="Submit" OnClientClick="return IsFormValid();" OnClick="btnLogin_Click" />
                            
            </div>
            
        </div>

         
      
        <!-- Javascript -->
        <script src="/Public/Javascript/ViewLogin.js"></script>

    </form>
</body>
</html>
