using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;
using FrontOffice.Resources;

namespace FrontOffice.Pages
{
    public partial class ViewHistory : System.Web.UI.Page
    {
        private static BLL bll;
        private static string apiToken;
        private static string connString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;


            apiToken    = WebConfigurationManager.AppSettings["ApiToken"];
            connString  = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;
            bll         = new BLL(connString, apiToken);


            MatchesTipsGrid matchesTipsGrid = new MatchesTipsGrid(bll.GetNextMatchesByTierOneCompetitions());


            placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());
        }
    }
}