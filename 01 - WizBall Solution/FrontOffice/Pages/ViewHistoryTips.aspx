<%@ Page 
    Title="" 
    Language="C#" 
    MasterPageFile="~/Pages/MasterView.Master" 
    AutoEventWireup="true" 
    CodeBehind="ViewHistoryTips.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewHistoryTips" %>


<asp:Content ID="viewHistoryTipsContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">
    
    <link rel="stylesheet" href="../Public/Styling/MatchesTipsHistoryGrid.css" />

</asp:Content>


<asp:Content ID="viewHistoryTipsContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">
    
    <asp:PlaceHolder ID="placeHolderTipsHistoryGrid" runat="server"></asp:PlaceHolder>

</asp:Content>


<asp:Content ID="viewHistoryTipsContentJavascript" ContentPlaceHolderID="masterViewContentJavascript" runat="server">

    <script src="../Public/Javascript/MatchesTipsHistoryGrid.js"></script>

</asp:Content>
