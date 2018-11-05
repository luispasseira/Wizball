using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Web.UI.HtmlControls;

namespace FrontOffice.Pages
{
    public partial class ViewHistoryTips : System.Web.UI.Page
    {
        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn() &&  (Session["User"] as User).CurrentUserHistory.AfterState.Id == 21)
            {
                MatchesTipsHistoryGrid matchesTipsHistoryGrid = new MatchesTipsHistoryGrid();
                placeHolderTipsHistoryGrid.Controls.Add(matchesTipsHistoryGrid.FiltersAndGrid());
            }
            else
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes["style"] = 
                    "display:flex; " +
                    "justify-content:center; " +
                    "align-items:center; " +
                    "flex-direction:column; " + 
                    "color:#9acd32; " +
                    "width:100%; " +
                    "height:100vh;" +
                    "padding:30px;" +
                    "background-color: rgba(0,0,0, 0.6)";

                HtmlGenericControl message = new HtmlGenericControl("label");
                message.InnerText = "This page's available only for registered users.";
                message.Attributes["style"] = "font-size: 24px; display:block; position:relative; top:-50px;";
                div.Controls.Add(message);

                HtmlGenericControl invite = new HtmlGenericControl("a");
                invite.InnerText = "Sing in here for free and get full access!";
                invite.Attributes["style"] = "font-size: 16px; display:block; position:relative; top:-50px; color:white;";
                invite.Attributes["href"] = "/Pages/ViewRegistration.aspx";
                div.Controls.Add(invite);

                placeHolderTipsHistoryGrid.Controls.Add(div);
            }
            
        }
    }
}