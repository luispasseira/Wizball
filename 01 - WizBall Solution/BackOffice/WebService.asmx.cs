using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;

namespace BackOffice
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        private string connString = WebConfigurationManager.ConnectionStrings["Passeira"].ConnectionString;
        private string apiToken = WebConfigurationManager.AppSettings["ApiToken"];


        // USER METHODS.
        [WebMethod]
        public List<User> GetAllUsers()
        {
            return new BLL(connString, apiToken).GetAllUsers();
        }
        [WebMethod]
        public User GetUserById(string Id)
        {
            return new BLL(connString, apiToken).GetUserById(Id);
        }
        [WebMethod]
        public bool InsertUser(User User)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.InsertUser(User);
        }
        [WebMethod]
        public bool UpdateUser(User User)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.UpdateUser(User);
        }
        [WebMethod]
        public bool UpdateUserAndUserHistory(User User, UserHistory UserHistory)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.UpdateUser(User, UserHistory);
        }
        [WebMethod]
        public User UserLogin(string Username, string Password)
        {
            return new BLL(connString, apiToken).UserLogin(Username, Password);
        }
        [WebMethod]
        public bool RecoverUserPassword(string Email)
        {
            return new BLL(connString, apiToken).RecoverUserPassword(Email);
        }
        [WebMethod]
        public bool UserMailExists(string Email)
        {
            return new BLL(connString, apiToken).UserMailExists(Email);
        }
        [WebMethod]
        public bool UsernameExists(string Username)
        {
            return new BLL(connString, apiToken).UsernameExists(Username);
        }
        [WebMethod]
        public List<User> GetUsersByState(string UserStateId)
        {
            return new BLL(connString, apiToken).GetUsersByState(UserStateId);
        }

        // USER_STATE METHODS.
        [WebMethod]
        public List<UserState> GetAllUserStates()
        {
            return new BLL(connString, apiToken).GetAllUserStates();
        }
        [WebMethod]
        public UserState GetUserStateById(string Id)
        {
            return new BLL(connString, apiToken).GetUserStateById(Id);
        }

        // USER_HISTORY MOTHODS.
        [WebMethod]
        public UserHistory GetUserHistoryById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }

            BLL bll = new BLL(connString, apiToken);

            return bll.GetUserHistoryById(Id);
        }
        [WebMethod]
        public List<UserHistory> GetUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }

            BLL bll = new BLL(connString, apiToken);

            return bll.GetUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public UserHistory GetCurrentUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }


            BLL bll = new BLL(connString, apiToken);

            return bll.GetCurrentUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public bool InsertUserHistory(UserHistory UserHistory)
        {
            if (UserHistory is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.InsertUserHistory(UserHistory);
        }



        // ADMIN METHODS.
        [WebMethod]
        public List<Admin> GetAllAdmins()
        {
            return new BLL(connString, apiToken).GetAllAdmins();
        }
        [WebMethod]
        public Admin GetAdminById(string Id)
        {
            return new BLL(connString, apiToken).GetAdminById(Id);
        }
        [WebMethod]
        public bool InsertAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            BLL bll = new BLL(connString, apiToken);
            bll.InsertAdmin(Admin);

            return true;
        }
        [WebMethod]
        public bool UpdatetAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            BLL bll = new BLL(connString, apiToken);
            return bll.UpdateAdmin(Admin);
        }
        [WebMethod(EnableSession = true)]
        public Admin AdminLogin(string Username, string Password)
        {
            BLL bll = new BLL(connString, apiToken);
            Admin ad = bll.AdminLogin(Username, Password);
            if (ad != null)
            {
                Session["Admin"] = ad;
                return ad;
            }
            else
            {
                Session["Admin"] = null;
                return null;
            }
        }



        // SYNC METHODS
        [WebMethod]
        public bool FullDatabaseSync()
        {
            return new BLL(connString, apiToken).FullDatabaseSync();
        }
        [WebMethod]
        public bool SyncMatchesTierOne()
        {
            return new BLL(connString, apiToken).SyncMatchesTierOne();
        }
        [WebMethod]
        public bool SyncTeams()
        {
            return new BLL(connString, apiToken).SyncTeams();
        }


        // NEWSLETTER METHODS
        [WebMethod]
        public bool SendNewsletter(string subject, string body)
        {
            return new BLL(connString, apiToken).SendNewsletter(subject, body);
        }


        // TEAMS METHODS
        [WebMethod]
        public List<Team> GetAllTeams()
        {
            return new BLL(connString, apiToken).GetAllTeams();
        }



        // AREAS METHODS
        [WebMethod]
        public List<Area> GetAllAreas()
        {
            return new BLL(connString, apiToken).GetAllAreas();
        }



        // MATCHES METHODS
        [WebMethod]
        public List<Match> GetNextMatchesByTierOneCompetitions()
        {
            return new BLL(connString, apiToken).GetNextMatchesByTierOneCompetitions();
        }
        [WebMethod]
        public List<Match> GetNextMatchesByTierOneCompetitionsWithLocalDate()
        {
           return new BLL(connString, apiToken).GetNextMatchesByTierOneCompetitionsWithLocalDate();
        }
        [WebMethod]
        public bool MatchesHasRows()
        {
            return new BLL(connString, apiToken).MatchesHasRows();
        }
        [WebMethod]
        public List<Match> GetPastMatches()
        {
            return new BLL(connString, apiToken).GetPastMatches();
        }



        // TIPS METHODS
        [WebMethod]
        public List<Tip> GetAllTips()
        {
            return new BLL(connString, apiToken).GetAllTips();
        }
        [WebMethod]
        public void SetNextMatchesTipsAndResults()
        {
            new BLL(connString, apiToken).RunNextMatchesTipsWithoutSyncMatches();
        }
        [WebMethod]
        public void SetHistoryMatchesTips()
        {
            new BLL(connString, apiToken).RunHistoryMatchesTipsWithoutSyncMatches();
        }
        [WebMethod]
        public Tip GetTipByMatchId(string Id)
        {
            return new BLL(connString, apiToken).GetTipByMatchId(Id);
        }

        public void RunHistoryMatchesTipsWithoutSyncMatches()
        {
            new BLL(connString, apiToken).RunHistoryMatchesTipsWithoutSyncMatches();
        }
    }
}
