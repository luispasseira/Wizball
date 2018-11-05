<%@ Page
    Title=""
    Language="C#"
    MasterPageFile="~/Pages/MasterView.Master"
    AutoEventWireup="true"
    CodeBehind="ViewContactUs.aspx.cs"
    Inherits="FrontOffice.Pages.ViewContactUs" %>

<asp:Content ID="ViewContactUsContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">
    <!-- ViewContactUs CSS Styling -->
    <link href="/Public/Styling/ViewContactUs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="viewContactUsContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <!-- Registration form -->
    <div class="form-wrapper">

        <div class="form-body">

            <h5 id="FormTitle" runat="server">Contact Us</h5>
            <hr />

            <div class="form-user-picture">

                <asp:Image ID="imgUserPic" runat="server" />
                <asp:FileUpload ID="attachmentInp" ClientIDMode="Static" AllowMultiple="true" name="AttachmentInp" runat="server" />

            </div>

            <div class="form-groups">
             
                    <div class="sub-groups-50">
                        <asp:Label ID="lblName" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="Name <span class='ast'>*</span>" AssociatedControlID="txtName"></asp:Label>
                        <asp:TextBox ID="txtName" required="" name="txtName" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Name"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="nameStatus"></small></span>
                    </div>

                    <div class="spacer"></div>

                    <div class="sub-groups-50">
                        <asp:Label ID="lblEmail" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="Email <span class='ast'>*</span>" AssociatedControlID="txtEmail"></asp:Label>
                        <asp:TextBox ID="txtEmail" required="" name="txtEmail" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <span class="status" style="color: orange"><small id="emailStatus"></small></span>
                    </div>

                
                    <div class="sub-groups-50">
                        <asp:Label ID="lblSubject" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="What is the subject you wish to discuss? <span class='ast'>*</span>" AssociatedControlID="txtSubject"></asp:Label>
                        <asp:TextBox ID="txtSubject" required="" multiline="true" CssClass="form-inputs form-control form-control-sm" runat="server" placeholder="Write the subject here..."></asp:TextBox>
                        <span class="status" style="color: orange"><small id="subjectStatus"></small></span>
                    </div>

                    <div class="spacer"></div>

                  
          
                <div class="sub-groups">
                    <asp:Label ID="lblMessage" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="What do you want to tell us? <span class='ast'>*</span>" AssociatedControlID="txtMessage"></asp:Label>
                    <asp:TextBox ID="txtMessage" required="" Style="height: 120px;" multiline="true" CssClass="form-inputs form-control form-textarea form-control-sm" runat="server" TextMode="MultiLine" placeholder="Write your message here..."></asp:TextBox>
                    <span class="status" style="color: orange"><small id="messageStatus"></small></span>


                </div>

                <div class="sub-groups-att">
                    <button type="button" id="btnCustomFileUpload"><i class="fas fa-upload"></i>Upload attachments</button>
                    <span id="upload-status"></span>
                </div>
                <br />
                <asp:Label ID="ReqLabel" style="color: white" ClientIDMode="Static" CssClass="form-imputs-labels" runat="server" Text="Items marked with <span class='ast'>*</span> are <span class='ast'>required</span>." AssociatedControlID="txtMessage"></asp:Label>
            </div>

            <div class="form-attachment">

                <asp:Button Text="Send Message" CssClass="btn btn-success form-submit" ID="Send" ClientIDMode="Static" OnClick="Send_Click" runat="server" />

            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="ViewContactUsContentJavascript" ContentPlaceHolderID="masterViewContentJavascript" runat="server">
    <script src="../Public/Javascript/ViewContactUs.js"></script>
</asp:Content>
