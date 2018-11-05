using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.pages
{
    public partial class DataManagement : System.Web.UI.Page
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