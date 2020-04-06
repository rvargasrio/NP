using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace Base
{
    public class BaseApi
    {

        //public string IdFilme;
        //public string ApiKey;
        public string endPoint;
        //
        public string urlBaseApi = "http://www.omdbapi.com/";
        //
        public RestClient client;
        public IRestRequest request;
        public IRestResponse response;
        string jsonResult;

        public RestClient GetClient()
        {
            client = new RestClient(urlBaseApi);
            return client;
        }

        public void GetRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET) { RequestFormat = DataFormat.Json };
        }

        public IRestResponse GetResponse()
        {
            response = client.Execute(request);
            return response;
        }

        public string DeserializeResponse(string propertie)
        {
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            jsonResult = output[propertie];
            return jsonResult;
        }
    }
}
