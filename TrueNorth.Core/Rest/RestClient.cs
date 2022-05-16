using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TrueNorth.Core.Rest
{
    public static class RestClient<T>
    { 
        public static string GetValue(HttpClient client, string path, HttpMethod methodType)
        { 
            var requestMessage = new HttpRequestMessage
            {
                Method = methodType, 
                RequestUri = new Uri(path),
            }; 

            var response = client.SendAsync(requestMessage);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;

            var resultObj = "";
            
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultObj = ((Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(responseContent)).First().ToString();
            }

            return resultObj;
        }
         
    }
}
