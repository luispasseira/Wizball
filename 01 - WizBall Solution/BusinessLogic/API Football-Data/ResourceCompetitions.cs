using System.Collections.Generic;
using System.Web.Script.Serialization;

using BusinessLogic.Entities;


namespace BusinessLogic.Resources
{
    public class ResourceCompetitions : Resource
    {
        // Constructor.
        public ResourceCompetitions(string Token) : base(Token)
        {
            
        }



        // List all available competitions.
        public List<Competition> GetAll()
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS);                                                        // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                                 // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                                   // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));                  // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonCompetitions = serializer.Serialize(((Dictionary<string, object>)objResponse)["competitions"]);      // Serializes only the competitions node into a json string.
            object lstCompetitions = serializer.Deserialize(jsonCompetitions, typeof(List<Competition>));                   // Deserializes the jsonCompetitions into a List<Competition>

            return lstCompetitions as List<Competition>;
        }

        // List one particular competition by its Id.
        public Competition GetById(string Competiton_Id)
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS, Competiton_Id);                                         // Generate the end point..

            string jsonResponse = DownloadString(endPoint);                                                                 // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                                   // Serializer object to manipulate jsons.
            object competition = serializer.Deserialize(jsonResponse, typeof(Competition));                                 // Deserialize the jsonResponse into an Competition object.

            return competition as Competition;
        }

        // List competitions by area.
        public List<Competition> GetByArea(string Area_Id)
        {
            string endPoint = GetEndPoint(URL_COMPETITIONS,                                                     
                                          new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("areas", Area_Id) });


            string jsonResponse = DownloadString(endPoint);                                                                 // Executes the request.                                                    
           
            JavaScriptSerializer serializer = new JavaScriptSerializer();                                                   // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));                  // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonCompetitions = serializer.Serialize(((Dictionary<string, object>)objResponse)["competitions"]);      // Serializes only the competitions node into a json string.
            object lstCompetitions = serializer.Deserialize(jsonCompetitions, typeof(List<Competition>));                   // Deserializes the jsonCompetitions into a List<Competition>

            return lstCompetitions as List<Competition>;
        }
    
    }
}
