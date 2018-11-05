using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

using BusinessLogic.Entities;


namespace BusinessLogic.Resources
{
    public class ResourceTeams : Resource
    {
        public ResourceTeams(string Token) : base(Token)
        {
        }



        // List one particular team.
        public Team GetById(string TeamId)
        {
            string endPoint = GetEndPoint(URL_TEAMS, TeamId);                                           // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                     // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                       // Serializer object to manipulate jsons.
            object team = serializer.Deserialize(jsonResponse, typeof(Team));                                   // Deserializes the json response into an object of type Team.

            return team as Team;
        }

        // List all teams for a particular competition.
        public List<Team> GetByCompetition(string CompetitionId)
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS, CompetitionId, "teams");                    // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                     // Executes the request agains the end point. 

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                       // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));      // Deserializes the json response into an object of type Dictionary<string, object>.
            string jsonTeams = serializer.Serialize(((Dictionary<string, object>)objResponse)["teams"]);        // Serializes only the teams node into a json string.
            object lstTeams = serializer.Deserialize(jsonTeams, typeof(List<Team>));                            // Deserializes the jsonTeams into a List<Team>

            return lstTeams as List<Team>;
        }

        // List all teams for a particular competition.
        public List<Team> GetByCompetitionAndStage(string CompetitionId, string Stage)                             
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS,                                             // Generate the end point.
                                          CompetitionId, 
                                          "teams", 
                                          new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("stage", Stage) });

            string jsonResponse = DownloadString(endPoint);                                                     // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                       // Serializer object to manipulate jsons.
            object jsonObject = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));       // Deserializes the json response into an object of type Dictionary<string, object>.
            string jsonTeams = serializer.Serialize(((Dictionary<string, object>)jsonObject)["teams"]);         // Serializes only the teams node into a json string.
            object lstTeams = serializer.Deserialize(jsonTeams, typeof(List<Team>));                            // Deserializes the jsonTeams into a List<Team>

            return lstTeams as List<Team>;
        }

    }
}
