using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALMatches : DAL
    {
        public DALMatches(string ConnString) : base(ConnString)
        { }

        // Stored Procedure
        public List<Match> GetSpNextMatchesByCompetitionId(string CompetitionId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@competition", CompetitionId)
            };

            return base.ExecuteStoredProcedure(new Match(), "spGetNextMatches", parameters)
                .Cast<Match>().ToList();
        }

        // Gets
        public List<Match> GetAll()
        {
            return base.GetAll(new Match()).Cast<Match>().ToList();
        }
        public Match GetById(string Id)
        {
            return GetById(new Match(), Id) as Match;
        }
        public List<Match> GetByCompetitionId(string CompetitionId)
        {
            return GetWhere(new Match(),
                            new Dictionary<string, string>() { { "competition_id", CompetitionId } })

                            .Cast<Match>().ToList();
        }
        public List<Match> GetByCompetitionIdAndByRangeDates(string CompetitionId, DateTime DateInit, DateTime DateEnd)
        {
            List<DbWhere> lstDbWheres = new List<DbWhere>()
            {
                new DbWhere
                {
                    Field = "utc_date",
                    Value = DateInit.Year + "-" + DateInit.Month + "-" + DateInit.Day + " " + DateInit.Hour + ":" + DateInit.Minute + ":" + DateInit.Second,
                    Alias = "utc_date_init",
                    Operator = DbOperator.GreaterThanOrEqualsTo
                },

                new DbWhere
                {
                    Field = "utc_date",
                    Value = DateEnd.Year + "-" + DateEnd.Month + "-" + DateEnd.Day + " " + DateEnd.Hour + ":" + DateEnd.Minute + ":" + DateEnd.Second,
                    Alias = "utc_date_end",
                    Operator = DbOperator.LesserThanOrEqualsTo
                },

                new DbWhere
                {
                    Field = "competition_id",
                    Value = CompetitionId,
                    Alias = "competition",
                    Operator = DbOperator.EqualsTo
                }
            };

            return GetWhere(new Match(), lstDbWheres).Cast<Match>().ToList();
        }
        public bool HasRows()
        {
            string query = "SELECT TOP 1 * FROM matches";
            object result = ExecuteScalarRaw(query);

            return result is null ? false : (int)result == 0 ? false : true;
        }


        // Insert.
        public bool Insert(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Insert(match);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Delete(match);
            }

            return true;
        }

        // Update.
        public bool Update(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Update(match);
            }

            return true;
        }

    }
}
