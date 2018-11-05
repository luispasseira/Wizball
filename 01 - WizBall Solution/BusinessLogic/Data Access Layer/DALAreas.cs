using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public class DALAreas : DAL
    {
        // Construtor.
        public DALAreas(string ConnectionString) : base(ConnectionString)
        {
        }

      

        // Gets.
        public List<Area> GetAll()
        {
            return GetAll(new Area()).Cast<Area>().ToList();
        }
        public Area GetById(string Id)
        {
            return GetById(new Area(), Id) as Area;
        }
        public List<Area> GetByParentAreaId(string ParentAreaId)
        {
            return GetWhere(new Area(), 
                            new Dictionary<string, string>()
                            { { "parent_area_id", ParentAreaId } })
                            
                            .Cast<Area>().ToList();
        }

        // Insert.
        public bool Insert(List<Area> Areas)
        {
            foreach (Area area in Areas)
            {
                Insert(area);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Area> Areas)
        {
            foreach (Area area in Areas)
            {
                Delete(area);
            }

            return true;
        }

        // Update.
        public bool Update(List<Area> Areas)
        {
            foreach (Area area in Areas)
            {
                Update(area);
            }

            return true;
        }
    }
}
