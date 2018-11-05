using System.Collections.Generic;
using System.Linq;

using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public class DALSeasons : DAL
    {
        public DALSeasons(string ConnectionString) : base(ConnectionString)
        { }


        // Gets.
        public List<Season> GetAll()
        {
            return GetAll(new Season()).Cast<Season>().ToList();
        }
        public Season GetById(string Id)
        {
            return GetById(new Season(), Id) as Season;
        }
       

        // Insert.
        public bool Insert(List<Season> Seasons)
        {
            foreach (Season season in Seasons)
            {
                Insert(season);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Season> Seasons)
        {
            foreach (Season season in Seasons)
            {
                Delete(season);
            }

            return true;
        }

        // Update.
        public bool Update(List<Season> Seasons)
        {
            foreach (Season season in Seasons)
            {
                Update(season);
            }

            return true;
        }
    }
}
