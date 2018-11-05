using FrontOffice.Resources;
using System;


namespace FrontOffice.Pages
{
    public partial class ViewHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //new Globals().CreateBll().FullDatabaseSync();
            //new Globals().CreateBll().RunNextMatchesTips();
            //new Globals().CreateBll().RunHistoryMatchesTips();

            MatchesTipsGrid matchesTipsGrid = new MatchesTipsGrid();

            placeHolderMatchesTipsGrid.Controls.Add(matchesTipsGrid.FiltersAndGrid());
        }
    }
}