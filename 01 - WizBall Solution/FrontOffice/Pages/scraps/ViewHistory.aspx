<%@ Page 
    Title="" 
    Language="C#" 
    MasterPageFile="~/Pages/MasterView.Master" 
    AutoEventWireup="true" 
    CodeBehind="ViewHistory.aspx.cs" 
    Inherits="FrontOffice.Pages.ViewHome" %>



<asp:Content ID="viewHistoryContentHead" ContentPlaceHolderID="masterViewContentHead" runat="server">
   
    <link rel="stylesheet" href="../Public/Styling/MatchesTipsGrid.css" />

</asp:Content>



<asp:Content ID="viewHistoryContentBody" ContentPlaceHolderID="masterViewContentBody" runat="server">

    <asp:PlaceHolder ID="placeHolderHistoryTips" runat="server"></asp:PlaceHolder>

</asp:Content>
