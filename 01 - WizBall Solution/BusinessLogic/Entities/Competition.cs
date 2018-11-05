using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Competition : Entity
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public int? NumberOfAvailableSeasons { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }



        public Entity Assembler(List<object> Row)
        {
            Competition comp = new Competition();

            comp.Id = (int)Row[0];
            comp.Area = new Area() { Id = (int)Row[1] };
            comp.Name = Row[2].ToString();
            comp.Code = Row[3].ToString();
            comp.Plan = Row[4].ToString();
            comp.Flag = Row[5].ToString();
            comp.LastUpdated = Row[6].ToString();

            return comp;
        }



        private string GetMyDateTime(DateTime Date)
        {
            string year = Date.Year.ToString();
            string month = Date.Month < 10 ? "0" + Date.Month.ToString() : Date.Month.ToString();
            string day = Date.Day < 10 ? "0" + Date.Day.ToString() : Date.Day.ToString();
            string hour = Date.Hour < 10 ? "0" + Date.Hour.ToString() : Date.Hour.ToString();
            string minute = Date.Minute < 10 ? "0" + Date.Minute.ToString() : Date.Minute.ToString();
            string second = Date.Second < 10 ? "0" + Date.Second.ToString() : Date.Second.ToString();


            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", year, month, day, hour, minute, second);
        }



        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "competitions";
        }


        public string[] GetInsertableFields()
        {
            return new string[] { "id",
                                  "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "flag",
                                  "last_updated"};
        }
        public object[] GetInsertableValues()
        {
            DateTime lastUpdate = new DateTime();
            DateTime.TryParse(LastUpdated, out lastUpdate);

            return new string[] { Id.ToString(),
                                  Area.Id.ToString(),
                                  Name,
                                  Code is null ? null : Code.ToString(),
                                  Plan,
                                  Flag,
                                  LastUpdated};
        }

       
        public string[] GetUpdatableFields()
        {
            return new string[] { "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "last_updated"};
        }
        public object[] GetUpdatableValues()
        {

            return new string[] { Area.Id is null ? null : Area.Id.ToString(),
                                  Name,
                                  Code is null ? null : Code.ToString(),                                
                                  Plan,
                                  LastUpdated};
        }
    }
}
