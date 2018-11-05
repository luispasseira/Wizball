using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALUsers : DAL
    {
        public DALUsers(string ConnectionString) : base(ConnectionString) { }


        // GETS.
        public List<User> GetAll()
        {
            return GetAll(new User()).Cast<User>().ToList();
        }
        public User GetById(string Id)
        {
            return GetById(new User(), Id) as User;
        }
        public User GetByEmail(string Email)
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                {"email", Email }
            };

            List<User> lstUsers = GetWhere(new User(), where).Cast<User>().ToList();
            return lstUsers.Count == 0 ? null : lstUsers[0];
        }
        public User GetByUsername(string Username)
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                {"username", Username }
            };

            List<User> lstUsers = GetWhere(new User(), where).Cast<User>().ToList();
            return lstUsers.Count == 0 ? null : lstUsers[0];
        }
        public List<User> GetByState(string UserStateId)
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                {"user_state", UserStateId }
            };

            List<User> lstUsers = GetWhere(new User(), where).Cast<User>().ToList();
            return lstUsers.Count == 0 ? null : lstUsers;
        }
        public int GetLastInsertedId()
        {
            return GetAll().OrderByDescending(x => x.Id).ToList()[0].Id;
        }
        public List<User> GetByNewsletter()
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                {"newsletter", "true" }
            };

            return GetWhere(new User(), where).Cast<User>().ToList();
        }

        // INSERTS.
        public int Insert(User User)
        {
            return InsertWithScopeIdentity(User);
        }
        public bool Insert(List<User> Users)
        {
            foreach (User user in Users)
            {
                Insert(user);
            }

            return true;
        }


        // UPDATE.
        public bool Update(User User)
        {         
            return base.Update(User);
        }
        public bool Update(List<User> Users)
        {
            foreach (User user in Users)
            {
                base.Update(user);
            }

            return true;
        }


        // DELETE.
        public bool Delete(List<User> Users)
        {
            foreach (User user in Users)
            {
                Delete(user);
            }

            return true;
        }


        // LOGIN
        public User Login(string Username, string Password)
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                { "username", Username },
                { "password", Password }
            };

            List<User> lstUsers = GetWhere(new User(), where).Cast<User>().ToList();

            return lstUsers.Count == 0 ? null : lstUsers[0];
        }
    }
}
