using BusinessLogic.BLL;
using System;
using System.Net.Mail;
using System.Web.Configuration;

namespace FrontOffice.Resources
{
    public class Globals
    {
        public const string TEAM_FLAGS = "/Public/Imgs/Teams/";
        public const string COMP_FLAGS = "/Public/Imgs/Competitions/";
        public const string MARKETS    = "/Public/Imgs/Markets/";
        public const string WIZBALL    = "/Public/Imgs/Wizball/";
        public const string USERS      = "/Public/Imgs/Users/";


        public DateTime? NormalizeApiDateTime(string Datetime)
        {
            if (string.IsNullOrEmpty(Datetime))
                return null;

            DateTime dateTimeNormalized;

            DateTime.TryParse(Datetime,
                              null,
                              System.Globalization.DateTimeStyles.AdjustToUniversal,
                              out dateTimeNormalized);

            return dateTimeNormalized;
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BLL CreateBll()
        {     
            string apiToken     = WebConfigurationManager.AppSettings["ApiToken"];
            string connString   = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;

            return new BLL(connString, apiToken);
        }
    }
}