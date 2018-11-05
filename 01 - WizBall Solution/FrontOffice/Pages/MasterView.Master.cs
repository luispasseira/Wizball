using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Web;
using System.Web.UI;

namespace FrontOffice
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetActiveMenu();

            SetupUserPanel();


            if (IsPostBack)
            {
                return;
            }
        }



        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;

            Page.Response.Redirect("/Pages/ViewHome.aspx");
        }



        private void SetupUserPanel()
        {
            if (IsUserLoggedIn())
            {
                GenerateUserPanelDesktop();
                GenerateUserPanelResponsive();
            }
            else
            {
                GenerateGuestPanelDesktop();
                GenerateGuestPanelResponsive();
            }
        }

        private void GenerateUserPanelDesktop()
        {
            // Gets user picture.
            User user = Session["User"] as User;
            // And sets.
            imgUserPic.Src = Globals.USERS + user.Picture;

            // Creates Edit Profile menu.
            string editLink = "<a href='/Pages/ViewEditProfile.aspx'><i class='fas fa-user-edit'></i> Edit Profile</a>";

            // Creates Logout menu.
            string logoutLink = "<a href='#' id='logout'><i class='fas fa-sign-out-alt'></i> Log Out</a>";

            divDesktopMenuUserOptions.InnerHtml = editLink + logoutLink;
        }
        private void GenerateUserPanelResponsive()
        {
            // Gets user picture.
            User user = Session["User"] as User;
            // And sets.
            imgUserPicResp.Src = Globals.USERS + user.Picture;


            // Creates Edit Profile menu.
            string editLink = "<a href='/Pages/ViewEditProfile.aspx'><i class='fas fa-user-edit'></i> Edit Profile</a>";

            // Creates Logout menu.
            string logoutLink = "<a href='#' id='logoutt'><i class='fas fa-sign-out-alt'></i> Log Out</a>";


            divDesktopMenuUserOptionsResp.InnerHtml = editLink + logoutLink;
        }
     
        private void GenerateGuestPanelDesktop()
        {
            // Loads default guest user picuture.
            imgUserPicResp.Src = Globals.USERS + "user.png";


            // Creates  Login | Resgristration | Recover Password menus.
            string loginLink = "<a href='/Pages/ViewLogin.aspx'><i class='fas fa-sign-in-alt'></i> Login</a>";
            string registrationLink = "<a href='/Pages/ViewRegistration.aspx'><i class='fas fa-plus-circle'></i> Registration</a>";
            string recoverPasswordLink = "<a href ='/Pages/ViewRecoverPassword.aspx'><i class='fas fa-unlock-alt'></i> Recover Password</a>";


            divDesktopMenuUserOptions.InnerHtml = loginLink + registrationLink + recoverPasswordLink;
        }
        private void GenerateGuestPanelResponsive()
        {
            // Loads default guest user picuture.
            imgUserPic.Src = Globals.USERS + "user.png";


            // Creates  Login | Resgristration | Recover Password menus.
            string loginLink = "<a href='/Pages/ViewLogin.aspx'><i class='fas fa-sign-in-alt'></i> Login</a>";
            string registrationLink = "<a href='/Pages/ViewRegistration.aspx'><i class='fas fa-plus-circle'></i> Registration</a>";
            string recoverPasswordLink = "<a href ='/Pages/ViewRecoverPassword.aspx'><i class='fas fa-unlock-alt'></i> Recover Password</a>";


            divDesktopMenuUserOptionsResp.InnerHtml = loginLink + registrationLink + recoverPasswordLink;
        }




        private void SetActiveMenu()
        {
            switch (HttpContext.Current.Request.Url.AbsolutePath)
            {
                case "/Pages/ViewHome.aspx":
                    linkHome.Attributes.Add("class", "active-menu");
                    break;

                case "/Pages/ViewHistoryTips.aspx":
                    linkTipsHistory.Attributes.Add("class", "active-menu");
                    break;

                case "/Pages/ViewContactUs.aspx":
                    linkContactUs.Attributes.Add("class", "active-menu");
                    break;

                case "/Pages/ViewAboutUs.aspx":
                    linkAboutUs.Attributes.Add("class", "active-menu");              
                    break;

                default:
                    break;
            }
      
        }
    }
}