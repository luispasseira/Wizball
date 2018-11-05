using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Tip : Entity
    {
        public int Id { get; set; }
        public Match Match { get; set; }
        public Market Market { get; set; }
        public bool BetNoBet { get; set; }
        public bool Forecast { get; set; }
        public bool? Result { get; set; }

        Entity Entity.Assembler(List<object> Row)
        {
            Tip tip = new Tip();

            tip.Id          = (int)Row[0];
            tip.Match       = new Match() { Id = (int)Row[1] };
            tip.Market      = new Market() { Id = (int)Row[2] };
            tip.BetNoBet    = (bool)Row[3];
            tip.Forecast    = (bool)Row[4];
            if (Row[5] != DBNull.Value)
            {
                tip.Result = (bool)Row[5];
            }

            return tip;
        }


        string Entity.GetId()
        {
            return Id.ToString();
        }
        string Entity.GetTableName()
        {
            return "tips";
        }

        string[] Entity.GetInsertableFields()
        {
            return new string[] { "match_id",
                                  "market_id",
                                  "bet_no_bet",
                                  "forecast",
                                  "result" };
        }
        object[] Entity.GetInsertableValues()
        {
            return new string[] { Match.Id.ToString(),
                                  Market.Id.ToString(),
                                  BetNoBet == false ? "false" : "true",
                                  Forecast == false ? "false" : "true",
                                  Result == null ? null : Result == false ? "false" : "true" };
        }

       
        string[] Entity.GetUpdatableFields()
        {
            return new string[] { "match_id",
                                  "market_id",
                                  "bet_no_bet",
                                  "forecast",
                                  "result" };
        }
        object[] Entity.GetUpdatableValues()
        {
            return new string[] { Match.Id.ToString(),
                                  Market.Id.ToString(),
                                  BetNoBet == false ? "false" : "true",
                                  Forecast == false ? "false" : "true",
                                  Result == null ? null : Result == false ? "false" : "true" };
        }
    }
}
