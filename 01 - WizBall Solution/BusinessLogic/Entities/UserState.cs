using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class UserState : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }


        Entity Entity.Assembler(List<object> Row)
        {
            UserState userState = new UserState();

            userState.Id = (int)Row[0];
            userState.Description = Row[1].ToString();  

            return userState;
        }

       

        string Entity.GetId()
        {
            return Id.ToString();
        }
        string Entity.GetTableName()
        {
            return "user_states";
        }


        string[] Entity.GetInsertableFields()
        {
            return new string[] { "descripion" };
        }
        object[] Entity.GetInsertableValues()
        {
            return new string[] { Description };
        }


        string[] Entity.GetUpdatableFields()
        {
            return new string[] { "id",
                                  "descripion" };
        }
        object[] Entity.GetUpdatableValues()
        {
            return new string[] { Id.ToString(),
                                  Description };
        }
    }
}
