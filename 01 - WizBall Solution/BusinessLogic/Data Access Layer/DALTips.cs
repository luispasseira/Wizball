using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public class DALTips : DAL
    {
        public DALTips(string ConnectionString) : base(ConnectionString)
        { }

        // GETS.
        public List<Tip> GetAll()
        {
            return GetAll(new Tip()).Cast<Tip>().ToList();
        }
        public Tip GetById(string Id)
        {
            return GetById(new Tip(), Id) as Tip;
        }
        public Tip GetByMatch(string MatchId)
        {
            List<Tip> lstTips = GetWhere(new Tip(),
                                    new Dictionary<string, string>()
                                    { { "match_id", MatchId } })

                                    .Cast<Tip>().ToList();

            return lstTips.Count > 0 ? lstTips[0] : null;
        }
        public List<Tip> GetByCompetition(string CompetitionId)
        {
            return GetWhere(new Tip(),
                            new Dictionary<string, string>()
                            { { "competition_id", CompetitionId } })

                            .Cast<Tip>().ToList();
        }
        public List<Tip> GetWhereResultNotSet()
        {
            return GetRaw(new Tip(), "SELECT * FROM tips WHERE result is null").Cast<Tip>().ToList();
        }
        public List<Tip> GetByCompetitionAndSeason(string CompetitionId, string SeasonId)
        {
            return GetWhere(new Tip(),
                            new Dictionary<string, string>()
                            { { "competition_id", CompetitionId },
                              { "season_id", SeasonId } })

                            .Cast<Tip>().ToList();
        }



        // Insert.
        public bool Insert(List<Tip> Tips)
        {
            foreach (Tip tip in Tips)
            {
                Insert(tip);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Tip> Tips)
        {
            foreach (Tip tip in Tips)
            {
                Delete(tip);
            }

            return true;
        }

        // Update.
        public bool Update(Tip Tip)
        {
            return base.Update(Tip);
        }
        public bool Update(List<Tip> Tips)
        {
            foreach (Tip tip in Tips)
            {
                Update(tip);
            }

            return true;
        }

    }
}
