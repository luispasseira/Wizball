using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALUserHistory : DAL
    {
        public DALUserHistory(string ConnectionString) : base(ConnectionString)
        { }


        // GETs
        public UserHistory GetById(string Id)
        {
            return GetById(new UserHistory(), Id) as UserHistory;
        }
        public List<UserHistory> GetByUserId(string UserId)
        {
            return GetWhere(new UserHistory(),
                            new Dictionary<string, string>() { { "user_id", UserId } })

                            .Cast<UserHistory>().ToList();
        }
        public UserHistory GetCurrentByUserId(string UserId)
        {
            List<UserHistory> history = GetWhere(new UserHistory(), new List<DbWhere>()
                                               {
                                                    new DbWhere()
                                                    {
                                                        Field    = "user_id",
                                                        Alias    = "user_id",
                                                        Value    = UserId,
                                                        Operator = DbOperator.EqualsTo                                                    
                                                    }
                                               })

                            .Cast<UserHistory>().ToList()
                            .OrderByDescending(x => x.CreatedAt).ToList();

            return history.Count > 0 ? history[0] : null;
        }

        // INSERTS.
        public bool Insert(List<UserHistory> UserHistory)
        {
            foreach (UserHistory userHistory in UserHistory)
            {
                Insert(userHistory);
            }

            return true;
        }
        public bool Insert(UserHistory UserHistory)
        {
            return base.Insert(UserHistory);
        }


        // UPDATE. (Not implemented in bll because its not suposed this table to allow updates)
        public bool Update(List<UserHistory> UserHistories)
        {
            foreach (UserHistory userHistory in UserHistories)
            {
                Update(userHistory);
            }

            return true;
        }
        public bool Update(UserHistory UserHistory)
        {
            return Update(UserHistory);
        }


        // DELETE. (Not implemented in bll because its not suposed this table to allow deletes)
        public bool Delete(List<UserHistory> UserHistories)
        {
            foreach (UserHistory userHistory in UserHistories)
            {
                Delete(userHistory);
            }

            return true;
        }
    }
}
