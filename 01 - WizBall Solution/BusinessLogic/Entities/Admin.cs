using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Admin : Entity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }


       
        Entity Entity.Assembler(List<object> Row)
        {
            Admin admin = new Admin();

            admin.Id = (int)Row[0];
            admin.Username = Row[1].ToString();
            admin.Email = Row[2].ToString();
            admin.Password = Row[3].ToString();
            admin.Picture = Row[4].ToString();

            return admin;
        }
    

        string Entity.GetId()
        {
            return Id.ToString();
        }
        string Entity.GetTableName()
        {
            return "admins";
        }


        string[] Entity.GetInsertableFields()
        {
            return new string[] { "username",
                                  "email",
                                  "password",
                                  "pic" };
        }
        object[] Entity.GetInsertableValues()
        {
            return new string[] { Username,
                                  Email,
                                  Password,
                                  "admin.png" };
        }


        string[] Entity.GetUpdatableFields()
        {
            return new string[] { "username",
                                  "email",
                                  "password",
                                  "pic" };
        }
        object[] Entity.GetUpdatableValues()
        {
            return new string[] { Username,
                                  Email,
                                  Password,
                                  Picture };
        }
    }
}
