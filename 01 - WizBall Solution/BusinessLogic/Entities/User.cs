using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class User :Entity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Newsletter { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserHistory CurrentUserHistory { get; set; }


        private string GetDateTime()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string min = DateTime.Now.Minute.ToString();
            string sec = DateTime.Now.Second.ToString();

            return year + "-" + month + "-" + day + " " + hour + ":" +  min + ":" +  sec;
        }


        Entity Entity.Assembler(List<object> Row)
        {
            User user = new User();

            user.Id             = (int)Row[0];
            user.Username       = Row[1].ToString();
            user.Email          = Row[2].ToString();
            user.Password       = Row[3].ToString();
            user.Newsletter     = (bool)Row[4];
            user.Picture        = Row[5].ToString();
            user.CreatedAt      = (DateTime)Row[6];
            user.UpdatedAt      = (DateTime)Row[7];

            return user;
        }

     

        string Entity.GetId()
        {
            return Id.ToString();
        }
        string Entity.GetTableName()
        {
            return "users";
        }


        string[] Entity.GetInsertableFields()
        {
            return new string[] { "username",
                                  "email",
                                  "password",
                                  "newsletter",
                                  "pic",
                                  "created_at",
                                  "updated_at" };
        }
        object[] Entity.GetInsertableValues()
        {
            return new string[] { Username,
                                  Email,
                                  Password,
                                  "0",
                                  "user.png",
                                  GetDateTime(),
                                  GetDateTime() };
        }


        string[] Entity.GetUpdatableFields()
        {
            return new string[] { "username",
                                  "email",
                                  "password",
                                  "newsletter",
                                  "pic",
                                  "updated_at" };
        }
        object[] Entity.GetUpdatableValues()
        {
            return new string[] { Username,
                                  Email,
                                  Password,
                                  Newsletter == true ? "1" : "0",
                                  Picture,
                                  GetDateTime() };
        }
    }
}
