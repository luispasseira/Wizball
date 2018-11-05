<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEditProfile.aspx.cs" Inherits="FrontOffice.Pages.ViewEditProfile" %>

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
    <link href="/Public/Styling/ViewEditProfile.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        
        <!-- Background Img -->
        <div id="background">
        </div>

        <!-- Registration form -->
        <div class="form-wrapper">

            <div class="form-header">
                
                <a title="Home" href="/Pages/ViewHome.aspx"><img src="../Public/Imgs/Wizball/logo_dark.png" /></a>
              
            </div>
           
            <div class="form-body">

                <h5  runat="server">Edit profile</h5>
                <hr />

                <div class="form-user-picture">
                     
                    <asp:Image ID="imgUserPic" runat="server" />
                    <input type="file" id="fileuploadUserPicture" name="userPicture"  runat="server"/>
                    
                    <div class="customFileUpload">
                        <button type="button" id="btnCustomFileUpload"><i class="fas fa-upload" ></i> Upload your avatar</button>
                        <p id="upload-status"></p>
                    </div>
                    
                </div>
                
               

                <div class="form-groups">
                    <div class="sub-groups">
                         <asp:Label ID="lblUsername" CssClass="form-imputs-labels" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                        <asp:TextBox ID="txtUsername" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Username"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="usernameStatus"></small></span>
                    </div>
                    <div class="sub-groups">
                        <asp:Label ID="lblEmail" CssClass="form-imputs-labels" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail"  CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                    </div>
                   
                </div>

                <div class="form-groups">
                    <div class="sub-groups">
                        <asp:Label ID="lblPassword" CssClass="form-imputs-labels" runat="server" Text="New password" AssociatedControlID="txtPassword"></asp:Label>
                        <asp:TextBox ID="txtPassword" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="passwordStatus"></small></span>
                    </div>
                    <div class="sub-groups">
                       <asp:Label ID="lblPasswordTwo" CssClass="form-imputs-labels" runat="server" Text="Retype password" AssociatedControlID="txtPasswordTwo"></asp:Label>
                        <asp:TextBox ID="txtPasswordTwo" CssClass="form-inputs form-control form-control-sm"  runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="passwordStatusTwo"></small></span>
                    </div>
                </div>
              
        

                 <div class="form-checkbox">
                     <div class="form-check">
                        <label class="form-check-label">
                            <input id="cbNewsLetter"  class="form-check-input" type="checkbox" runat="server" />
                                Subscribe newsletter
                        </label>
                    </div>

                </div>


               <button type="button" id="btnSubmit" class="btn btn-success form-submit" onclick="IsFormValid();" >Submit</button>
                            
            </div>
            
        </div>

         
        
        <!-- Modal update profile confirmation -->
        <div id="outter-modal" class="outter-modal">

            <div id="inner-modal">

                <div id="modal-header">
                    <a href="/Pages/ViewHome.aspx">
                        <img id="modal-logo" src="/Public/Imgs/Wizball/logo_dark.png" />
                    </a>
                </div>


                <div id="modal-message">
                    <p id="modal-primary-message">Update confirmation</p>
                    <input type="password" id="currentPassword" placeholder="Current password" class="form-control form-control-sm" />
                    <span class="currentPasswordStatus" style="color: orange"><small id="currentPasswordStatus"></small></span>
                </div>

                
                <div id="modal-footer">
     
                    <button type="button" id="btnModalCancel" class="btn btn-danger btn-sm modal-btn"><i class="fas fa-undo"></i> Cancel</button>        
                    <button type="submit" id="btnModalConfirm" class="btn btn-success btn-sm modal-btn" onclick="return passwordValitation();"><i class="fas fa-check"></i> Confirm</button>
               
                </div>
                
            </div>

        </div>



         <div id="outterModalx" class="outter-modalx" runat="server">

            <div id="inner-modalx">

                <div id="modal-headerx">
                    <a href="/Pages/ViewHome.aspx"><img id="modal-logox" src="/Public/Imgs/Wizball/logo_dark.png" /></a>
                    <i   id="modal-closex" class="fas fa-times-circle fa-lg"></i>
                </div>
              
                <div id="modal-messagex">
                    <p id="modal-primary-messagex">Profile successfully updated</p>  
                </div>
               
                <div id="modal-footerx">
                    <h6 id="modal-counter-messagex">back to home... <span id="modal-counterx">20</span></h6>
                </div>
                
            </div>

        </div>



        <!-- Javascript -->
        <script src="/Public/Javascript/ViewEditProfile.js"></script>

    </form>
</body>
</html>