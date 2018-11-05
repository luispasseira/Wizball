using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Inserir nulls na base de dados.

namespace BusinessLogic.Entities
{
    public class Team : Entity
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string TLA { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public int? Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }
        public List<Player> Squad { get; set; }



        public Entity Assembler(List<object> Row)
        {
            Team team = new Team();

            team.Id = (int)Row[0];                                      // ID

            if(Row[1] != DBNull.Value)                                  // Area
            {
                team.Area = new Area { Id = (int)Row[1] };
            }else
            {
                team.Area = new Area();
            }

            team.Name            = Row[2].ToString();

            if (Row[3] != null)
            {
                team.ShortName = Row[3].ToString();
            }
            if (Row[4] != null)
            {
                team.TLA = Row[4].ToString();
            }
            if (Row[5] != null)
            {
                team.Address = Row[5].ToString();
            }
            if (Row[6] != null)
            {
                team.Phone = Row[6].ToString();
            }
            if (Row[7] != null)
            {
                team.WebSite = Row[7].ToString();
            }
            if (Row[8] != null)
            {
                team.Email = Row[8].ToString();
            }
            if (Row[9] != null)
            {
                team.Founded = (int)Row[9];
            }
            if (Row[10] != null)
            {
                team.ClubColors = Row[10].ToString();
            }
            if (Row[11] != null)
            {
                team.Venue = Row[11].ToString();
            }
            if (Row[12] != null)
            {
                team.Flag = Row[12].ToString();
            }
            if (Row[13] != null)
            {
                team.LastUpdated = Row[13].ToString();
            }

            return team;
        }


        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "teams";
        }


        public string[] GetInsertableFields()
        {
            return new string[] {   "id",
                                    "area_id",
                                    "name",
                                    "short_name",
                                    "tla",
                                    "address",
                                    "phone",
                                    "website",
                                    "email",
                                    "founded",
                                    "club_colors",
                                    "venue",
                                    "flag",
                                    "last_updated"};
        }
        public object[] GetInsertableValues()
        {
            return new string[] {   Id.ToString(),
                                    Area.Id is null ? null : Area.Id.ToString(),
                                    Name,
                                    ShortName,
                                    TLA,
                                    Address,
                                    Phone,
                                    WebSite,
                                    Email,
                                    Founded.ToString(),
                                    ClubColors,
                                    Venue,
                                    Flag,
                                    LastUpdated};
        }
     

        public string[] GetUpdatableFields()
        {
            return new string[] {   "area_id",
                                    "name",
                                    "short_name",
                                    "tla",
                                    "address",
                                    "phone",
                                    "website",
                                    "email",
                                    "founded",
                                    "club_colors",
                                    "venue",
                                    "last_updated"};
        }
        public object[] GetUpdatableValues()
        {
            return new string[] {   Area.Id is null ? null : Area.Id.ToString(),
                                    Name,
                                    ShortName,
                                    TLA,
                                    Address,
                                    Phone,
                                    WebSite,
                                    Email,
                                    Founded.ToString(),
                                    ClubColors,
                                    Venue,
                                    LastUpdated};
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? ShirtNumber { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }
    }
}
