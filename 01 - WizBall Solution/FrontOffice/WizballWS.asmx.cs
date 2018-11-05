using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Services;
using FrontOffice.Resources;
using System.Web.Script.Services;

namespace FrontOffice
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class WizballWS : System.Web.Services.WebService
    {
        private BLL bll = new Globals().CreateBll();


        // USER METHODS.
        [WebMethod]
        public List<User> GetAllUsers()
        {
            return bll.GetAllUsers();
        }
        [WebMethod]
        public User GetUserById(string Id)
        {
            return bll.GetUserById(Id);
        }
        [WebMethod]
        public bool InsertUser(User User)
        {
            if (User is null)
                return false;

            return bll.InsertUser(User);
        }
        [WebMethod]
        public bool UpdateUser(User User)
        {
            if (User is null)
                return false;

            return bll.UpdateUser(User);
        }
        [WebMethod]
        public bool UpdateUser(User User, UserHistory UserHistory)
        {
            if (User is null)
                return false;

            return bll.UpdateUser(User, UserHistory);
        }
        [WebMethod]
        public User UserLogin(string Username, string Password)
        {
            return bll.UserLogin(Username, Password);
        }
        [WebMethod]
        public bool RecoverUserPassword(string Email)
        {
            return bll.RecoverUserPassword(Email);
        }
        [WebMethod]
        public bool UserMailExists(string Email)
        {
            return bll.UserMailExists(Email);
        }
        [WebMethod]
        public bool UsernameExists(string Username)
        {
            return bll.UsernameExists(Username);
        }
        [WebMethod]
        public List<User> GetUsersByState(string UserStateId)
        {
            return bll.GetUsersByState(UserStateId);
        }

        // USER_STATE METHODS.
        [WebMethod]
        public List<UserState> GetAllUserStates()
        {
            return bll.GetAllUserStates();
        }
        [WebMethod]
        public UserState GetUserStateById(string Id)
        {
            return bll.GetUserStateById(Id);
        }

        // USER_HISTORY MOTHODS.
        [WebMethod]
        public UserHistory GetUserHistoryById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }

            return bll.GetUserHistoryById(Id);
        }
        [WebMethod]
        public List<UserHistory> GetUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }

            return bll.GetUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public UserHistory GetCurrentUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }

            return bll.GetCurrentUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public bool InsertUserHistory(UserHistory UserHistory)
        {
            if (UserHistory is null)
                return false;

            return bll.InsertUserHistory(UserHistory);
        }



        // ADMIN METHODS.
        [WebMethod]
        public List<Admin> GetAllAdmins()
        {
            return bll.GetAllAdmins();
        }
        [WebMethod]
        public Admin GetAdminById(string Id)
        {
            return bll.GetAdminById(Id);
        }
        [WebMethod]
        public bool InsertAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            bll.InsertAdmin(Admin);

            return true;
        }
        [WebMethod]
        public bool UpdatetAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            return bll.UpdateAdmin(Admin);
        }
        [WebMethod]
        public Admin AdminLogin(string Username, string Password)
        {
            return bll.AdminLogin(Username, Password);
        }
    }
}
