using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tiorem.agentMongoDB
{
    public enum MongoDbCollections
    {
        CatalogueSource = 1,Article=2
    }
    public class MongoRepo<T>
    {
       

        const string ApiUrlPattern = "https://api.mlab.com/api/1/databases/{0}/collections/{2}?apiKey={1}";    
        MongoDbCollections Collection { get; set; }        
        string ApiUrl { get; }
        string ApiKey = "SmUMfyNUqrOpSvfko7pFiKWoRqxhk0eT";
        string Database = "tiorem";
       

        public MongoRepo(MongoDbCollections collection)
        {            
            Collection = collection;
            ApiUrl  = string.Format(ApiUrlPattern, Database, ApiKey, collection.ToString()); ;
        }


        public Tuple<HttpWebResponse,string> Insert(List<T> data)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(data);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return new Tuple<HttpWebResponse, string>(httpResponse, streamReader.ReadToEnd());
            }

              
        }

        public Tuple<HttpWebResponse, string> Put(List<T> data)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(data);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return new Tuple<HttpWebResponse, string>(httpResponse, streamReader.ReadToEnd());
            }


        }

        public Tuple<HttpWebResponse, List<T>> GetAll(string filter="")
        {
            string url = ApiUrl + (string.IsNullOrEmpty(filter) ? "" : "&" + filter);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                List<T> data = JsonConvert.DeserializeObject<List<T>>(result);

                return new Tuple<HttpWebResponse, List<T>>(httpResponse, data);
            }


        }
    }
}
