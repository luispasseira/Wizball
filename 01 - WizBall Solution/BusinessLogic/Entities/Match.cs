using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Match : Entity
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public Competition Competition { get; set; }
        public string UtcDate { get; set; }
        public int? Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public int? Attendance { get; set; }
        public int? Minute { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }
        public string LastUpdated { get; set; }
        

        public Entity Assembler(List<object> Row)
        {
            Match match = new Match();

            match.Id = (int)Row[0];
            match.Season = new Season() { Id = (int)Row[1] };
            match.Competition = new Competition() { Id = (int)Row[2]};
            match.UtcDate = Row[3].ToString();
            if(Row[4] != DBNull.Value)
            {
                match.Matchday = (int)Row[4];
            }         
            match.Stage = Row[5].ToString();
            match.Group = Row[6].ToString();
            if(Row[7] !=  DBNull.Value)
            {
                match.Attendance = (int)Row[7];
            }
            match.HomeTeam = new Team() { Id = (int)Row[10] };
            match.AwayTeam = new Team() { Id = (int)Row[11] };
            match.Score = new Score()
            {
                Duration = Row[8].ToString(),
                Winner = Row[9].ToString(),
                HalfTime = new Result()
                {
                    HomeTeam = (int)Row[12],
                    AwayTeam = (int)Row[13]
                },
                FullTime = new Result()
                {
                    HomeTeam = (int)Row[14],
                    AwayTeam = (int)Row[15]
                },
                ExtraTime = new Result()
                {
                    HomeTeam = (int)Row[16],
                    AwayTeam = (int)Row[17]
                },
                Penalties = new Result()
                {
                    HomeTeam = (int)Row[18],
                    AwayTeam = (int)Row[19]
                }
            };
            match.LastUpdated = Row[20].ToString();

            return match;
        }


        public string[] GetInsertableFields()
        {
            return new string[] { "id",
                                  "season_id",
                                  "competition_id",
                                  "utc_date",
                                  "matchday",
                                  "stage",
                                  "group",
                                  "attendance",
                                  "duration",
                                  "winner",
                                  "home_team_id",
                                  "away_team_id",
                                  "ht_home_team",
                                  "ht_away_team",
                                  "ft_home_team",
                                  "ft_away_team",
                                  "et_home_team",
                                  "et_away_team",
                                  "pt_home_team",
                                  "pt_away_team",
                                  "last_updated"};
        }
        public object[] GetInsertableValues()
        {
            return new string[] { Id.ToString(),
                                  Season is null ? null : Season.Id.ToString(),
                                  Competition is null ? null : Competition.Id.ToString(),
                                  UtcDate,
                                  Matchday is null ? null : Matchday.ToString(),
                                  Stage,
                                  Group,
                                  Attendance is null ? null : Attendance.ToString(),
                                  Score is null ? null : Score.Duration,
                                  Score is null ? null : Score.Winner,
                                  HomeTeam is null ? null : HomeTeam.Id.ToString(),
                                  AwayTeam is null ? null : AwayTeam.Id.ToString(),
                                  Score is null ? null : Score.HalfTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.HalfTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.FullTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.FullTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.ExtraTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.ExtraTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.Penalties.HomeTeam.ToString(),
                                  Score is null ? null : Score.Penalties.AwayTeam.ToString(),
                                  LastUpdated};
        }

        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "matches";
        }

        public string[] GetUpdatableFields()
        {
            return new string[] { "season_id",
                                  "competition_id",
                                  "utc_date",
                                  "matchday",
                                  "stage",
                                  "group",
                                  "attendance",
                                  "duration",
                                  "winner",
                                  "home_team_id",
                                  "away_team_id",
                                  "ht_home_team",
                                  "ht_away_team",
                                  "ft_home_team",
                                  "ft_away_team",
                                  "et_home_team",
                                  "et_away_team",
                                  "pt_home_team",
                                  "pt_away_team",
                                  "last_updated"};
        }
        public object[] GetUpdatableValues()
        {
            return new string[] { 
                                  Season is null ? null : Season.Id.ToString(),
                                  Competition is null ? null : Competition.Id.ToString(),
                                  UtcDate,
                                  Matchday is null ? null : Matchday.ToString(),
                                  Stage,
                                  Group,
                                  Attendance is null ? null : Attendance.ToString(),
                                  Score is null ? null : Score.Duration,
                                  Score is null ? null : Score.Winner,
                                  HomeTeam is null ? null : HomeTeam.Id.ToString(),
                                  AwayTeam is null ? null : AwayTeam.Id.ToString(),
                                  Score is null ? null : Score.HalfTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.HalfTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.FullTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.FullTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.ExtraTime.HomeTeam.ToString(),
                                  Score is null ? null : Score.ExtraTime.AwayTeam.ToString(),
                                  Score is null ? null : Score.Penalties.HomeTeam.ToString(),
                                  Score is null ? null : Score.Penalties.AwayTeam.ToString(),
                                  LastUpdated};
        }

    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Result HalfTime { get; set; }
        public Result FullTime { get; set; }
        public Result ExtraTime { get; set; }
        public Result Penalties { get; set; }
    }

    public class Result
    {
        public int? HomeTeam { get; set; }
        public int? AwayTeam { get; set; }
    }
}
