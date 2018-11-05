using System.Collections.Generic;
using System.Web.Script.Serialization;

using BusinessLogic.Entities;


namespace BusinessLogic.Resources
{
    public class ResourceMatches : Resource
    {
        public ResourceMatches(string Token) : base(Token)
        {            
        }


        // List all matches for a particular competition.
        public List<Match> GetByCompetition(string CompetitionId)
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS, CompetitionId, "matches");                          // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));              // Deserializes the jsonResponse into an object of type Dictionary<string, object>.

            string jsonCompetition = serializer.Serialize(((Dictionary<string, object>)objResponse)["competition"]);            // Serializes only the matches node into a json string.
            string jsonMatches = serializer.Serialize(((Dictionary<string, object>)objResponse)["matches"]);            // Serializes only the matches node into a json string.

            object competition = serializer.Deserialize(jsonCompetition, typeof(Competition));
            object lstMatches = serializer.Deserialize(jsonMatches, typeof(List<Match>));                               // Deserializes the jsonMatches into a List<Match>.

            foreach(Match match in (List<Match>)lstMatches)
            {
                match.Competition = (Competition)competition;
            }
            return lstMatches as List<Match>;
        }

        // List one particular match.
        public Match GetById(string MatchId)
        {
            string endPoint = GetEndPoint(URL_MATCHES, MatchId);                                                // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object match = serializer.Deserialize(jsonResponse, typeof(Match));                                         // Deserializes the jsonResponse into a match.

            return match as Match;
        }

        // List matchs by competition and status.
        public List<Match> GetByCompetitionAndStatus(string CompetitionId, string Status)
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS,                                                      // Generate the end point.
                                          CompetitionId, 
                                          "matches",
                                          new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("status", Status) });

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));              // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonMatches = serializer.Serialize(((Dictionary<string, object>)objResponse)["matches"]);            // Serializes only the matches node into a json string.
            object lstMatches = serializer.Deserialize(jsonMatches, typeof(List<Match>));                               // Deserializes the jsonMatches into a List<Match>.

            return lstMatches as List<Match>;

        }

    }
}
