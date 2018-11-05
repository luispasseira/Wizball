using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public class DALCompetitions : DAL
    {
        public DALCompetitions(string ConnectionString) : base(ConnectionString)
        { }

        // Gets.
        public List<Competition> GetAll()
        {
            return base.GetAll(new Competition()).Cast<Competition>().ToList();
        }
        public Competition GetById(string Id)
        {
            return GetById(new Competition(), Id) as Competition;
        }
        public List<Competition> GetByAreaId(string AreaId)
        {
            return GetWhere(new Competition(),
                            new Dictionary<string, string>()
                            { { "area_id", AreaId } })

                            .Cast<Competition>().ToList();
        }
        public List<Competition> GetByPlan(string Plan)
        {
            return GetWhere(new Competition(),
                            new Dictionary<string, string>()
                            { { "plan", Plan } })

                            .Cast<Competition>().ToList();
        }

        // Insert.
        public bool Insert(List<Competition> Competitions)
        {
            foreach (Competition competition in Competitions)
            {
                Insert(competition);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Competition> Competitions)
        {
            foreach (Competition competition in Competitions)
            {
                Delete(competition);
            }

            return true;
        }

        // Update.
        public bool Update(List<Competition> Competitions)
        {
            foreach (Competition competition in Competitions)
            {
                Update(competition);
            }

            return true;
        }
    }
}
