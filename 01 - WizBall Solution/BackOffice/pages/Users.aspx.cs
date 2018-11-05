using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;

namespace BackOffice.pages
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Logout()
        {
            Session.Clear();
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("Login.aspx");
        }
    }
}