using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class UserHistory : Entity
    {
        public int Id { get; set; }
        public Admin Admin { get; set; }
        public User User { get; set; }
        public UserState BeforeState { get; set; }
        public UserState AfterState { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }


        private string GetDateTime()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string min = DateTime.Now.Minute.ToString();
            string sec = DateTime.Now.Second.ToString();

            return year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec;
        }


        Entity Entity.Assembler(List<object> Row)
        {
            UserHistory userHistory = new UserHistory();

            userHistory.Id              = (int)Row[0];
            userHistory.Admin           = new Admin()       { Id = (int)Row[1] };
            userHistory.User            = new User()        { Id = (int)Row[2] };
            userHistory.BeforeState     = new UserState()   { Id = (int)Row[3] };
            userHistory.AfterState      = new UserState()   { Id = (int)Row[4] };
            userHistory.Description     = Row[5].ToString();
            userHistory.CreatedAt       = (DateTime)Row[6];

            return userHistory;
        }


        string Entity.GetId()
        {
            return Id.ToString();
        }
        string Entity.GetTableName()
        {
            return "user_history";
        }


        string[] Entity.GetInsertableFields()
        {
            return new string[] { "admin_id",
                                  "user_id",
                                  "before_state_id",
                                  "after_state_id",
                                  "description",
                                  "created_at" };
        }
        object[] Entity.GetInsertableValues()
        {
            return new string[] { Admin.Id.ToString(),
                                  User.Id.ToString(),
                                  BeforeState.Id.ToString(),
                                  AfterState.Id.ToString(),
                                  Description,
                                  GetDateTime() };
        }
    

        string[] Entity.GetUpdatableFields()
        {
            return new string[] { "id",
                                  "admin_id",
                                  "user_id",
                                  "before_state_id",
                                  "after_state_id",
                                  "description" };
        }
        object[] Entity.GetUpdatableValues()
        {
            return new string[] { Id.ToString(),
                                  Admin.Id.ToString(),
                                  User.Id.ToString(),
                                  BeforeState.Id.ToString(),
                                  AfterState.Id.ToString(),
                                  Description };
        }
    }
}
