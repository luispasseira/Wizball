using System.Collections.Generic;
using System.Web.Script.Serialization;

using BusinessLogic.Entities;


namespace BusinessLogic.Resources
{
    public class ResourceAreas : Resource
    {
        public ResourceAreas(string Token) : base(Token)
        {
        }

        // List one particular area.
        public Area GetById(string AreaID)
        {
            return null;
        }

        // List all available areas.
        public List<Area> GetAll()
        {
            string endPoint = GetEndPoint(URL_AREAS);                                                               // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                                 // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                                   // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));                  // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonAreas = serializer.Serialize(((Dictionary<string, object>)objResponse)["areas"]);                    // Serializes only the areas node into a json string.
            object lstAreas = serializer.Deserialize(jsonAreas, typeof(List<Area>));                                        // Deserializes the jsonAreas into a List<Area>

            return lstAreas as List<Area>;

        }
    }
}
