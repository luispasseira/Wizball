using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    class DALTeams : DAL
    {
        public DALTeams(string ConnectionString) : base(ConnectionString)
        { }


        // Gets.
        public List<Team> GetAll()
        {
            return GetAll(new Team()).Cast<Team>().ToList();
        }
        public Team GetById(string Id)
        {
            return GetById(new Team(), Id) as Team;
        }
        public List<Team> GetByAreaId(string AreaId)
        {
            return GetWhere(new Team(),
                            new Dictionary<string, string>()
                            { { "area_id", AreaId } })

                            .Cast<Team>().ToList();
        }


        // Insert.
        public bool Insert(List<Team> Teams)
        {
            foreach (Team team in Teams)
            {
                Insert(team);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Team> Teams)
        {
            foreach (Team team in Teams)
            {
                Delete(team);
            }

            return true;
        }

        // Update.
        public bool Update(List<Team> Teams)
        {
            foreach (Team team in Teams)
            {
                Update(team);
            }

            return true;
        }
    }
}
