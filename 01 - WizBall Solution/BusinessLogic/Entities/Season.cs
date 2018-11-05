using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Season : Entity
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public List<string> AvailableStages { get; set; }


        private string GetMyDate(DateTime Date)
        {
            string year = Date.Year.ToString();
            string month = Date.Month < 10 ? "0" + Date.Month.ToString() : Date.Month.ToString();
            string day = Date.Day < 10 ? "0" + Date.Day.ToString() : Date.Day.ToString();

            return string.Format("{0}-{1}-{2}", year, month, day);
        }


        public Entity Assembler(List<object> Row)
        {
            Season season = new Season();

            season.Id           = (int)Row[0];
            if(Row[1] != DBNull.Value)
            {
                season.StartDate = GetMyDate((DateTime)Row[1]);
            }
            if (Row[2] != DBNull.Value)
            {
                season.EndDate = GetMyDate((DateTime)Row[2]);
            }

            return season;
        }


        public string GetId()
        {
            return Id.ToString();
        }


        public string GetTableName()
        {
            return "seasons";
        }

        public string[] GetInsertableFields()
        {
            return new string[] { "id",
                                  "start_date",
                                  "end_date" };
        }
        public object[] GetInsertableValues()
        {
            return new string[] { Id.ToString(),
                                  StartDate,
                                  EndDate };
        }
       
        public string[] GetUpdatableFields()
        {
            return new string[] { "start_date",
                                  "end_date" };
        }
        public object[] GetUpdatableValues()
        {
            return new string[] { StartDate,
                                  EndDate };
        }
    }
}
