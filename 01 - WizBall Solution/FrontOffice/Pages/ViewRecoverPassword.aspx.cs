using BusinessLogic.BLL;
using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Web.UI;

namespace FrontOffice.Pages
{
    public partial class ViewRecoverPassword2 : System.Web.UI.Page
    {
        BLL bll;

        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsUserLoggedIn())                                                            // If user is logged in then cant access this page.
            {           
                Page.Response.Redirect("/Pages/ViewHome.aspx");                             // Go home instead.
            }

            if(!IsPostBack)                                                                 // First call.
            {
                Session["antiXeats"] = true;                                                // Sets antiXeats true (Flag to prevent malicious user behavior).
            }   
            else if (IsPostBack && (bool)Session["antiXeats"])                              // Post back and antiXeats true.
            {
                bll = new Globals().CreateBll();

                bool isEmailInDB = bll.UserMailExists(txtEmail.Text);                       // Tries to get email from the database.

                if (isEmailInDB)                                                            // If success.
                {
                    bll.RecoverUserPassword(txtEmail.Text);                                 // Send email to user with account information.

                    emailStatus.InnerText = "";                                             // Reset possible notifications.                                 

                    Session["antiXeats"] = false;                                           // change flag antiXeats state.

                    Page.ClientScript.RegisterStartupScript(GetType(), "recoverPasswordConfirmation", "recoverPasswordConfirmation()", true);

                }
                else
                {
                    emailStatus.InnerText = "Email not found";                              // Alerts user.
                }
            }
            else
            {
                txtEmail.Text = string.Empty;
                Session["antiXeats"] = true;
            }

        }
    }
}