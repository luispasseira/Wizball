using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALAdmins : DAL 
    {
        public DALAdmins(string ConnectionString) : base(ConnectionString) { }



        // GETS.
        public List<Admin> GetAll()
        {
            return GetAll(new Admin()).Cast<Admin>().ToList();
        }
        public Admin GetById(string Id)
        {
            return GetById(new Admin(), Id) as Admin;
        }


        // INSERTS.
        public bool Insert(List<Admin> Admins)
        {
            foreach (Admin admin in Admins)
            {
                Insert(admin);
            }

            return true;
        }


        // UPDATE.
        public bool Update(List<Admin> Admins)
        {
            foreach (Admin admin in Admins)
            {
                Update(admin);
            }

            return true;
        }


        // LOGIN
        public Admin Login(string Username, string Password)
        {
            Dictionary<string, string> where = new Dictionary<string, string>()
            {
                { "username", Username },
                { "password", Password }
            };

            List<Admin> lstAdmins = GetWhere(new Admin(), where).Cast<Admin>().ToList();

            return lstAdmins.Count == 0 ? null : lstAdmins[0];
        }
    } 
}
