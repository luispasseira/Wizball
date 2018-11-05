using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Area : Entity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public int? ParentAreaId { get; set; }
        public string ParentArea { get; set; }


        public  Entity Assembler(List<object> Row)
        {
            Area area = new Area();

            area.Id             = (int)Row[0];
            area.Name           = Row[1].ToString();
            area.CountryCode    = Row[2].ToString();
            if(Row[3] != DBNull.Value)
            {
                area.ParentAreaId = (int)Row[3];
            }        

            return area;
        }

        

        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "areas";
        }


        public string[] GetInsertableFields()
        {
            return new string[] { "id",
                                  "name",
                                  "country_code",
                                  "parent_area_id" };
        }
        public object[] GetInsertableValues()
        {
            return new string[] { Id is null ? null : Id.ToString(),
                                  Name,
                                  CountryCode,
                                  ParentAreaId is null ? null : ParentAreaId.ToString() };
        }


        public string[] GetUpdatableFields()
        {
            return new string[] { "name",
                                  "country_code",
                                  "parent_area_id" };
        }
        public object[] GetUpdatableValues()
        {
            return new string[] { Id is null ? null : Id.ToString(),
                                  CountryCode,
                                  ParentAreaId is null ? null : ParentAreaId.ToString() };
        }
    }
}
