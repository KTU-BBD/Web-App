using CodeChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Reflection;
using System.Net.Http.Headers;
using System.Text;
using System.IO;

namespace CodeChecker.Controllers.api
{
    public static class Extensions
    {
        public static string FromDictionaryToJson(this Dictionary<string, string> dictionary)
        {
            var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Concat(",", kvp.Value)));
            return string.Concat("{", string.Join(",", kvs), "}");
        }

        public static Dictionary<string, string> FromJsonToDictionary(this string json)
        {
            string[] keyValueArray = json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
            return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
        }
    }
    // Controller for returning contests. Need repo first...
    [System.Web.Http.Route("api/contest")]
    [System.Web.Http.Authorize]
    public class ApiContestController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        [System.Web.Mvc.HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody]TaskCodeViewModel task)
        {
            System.Diagnostics.Debug.WriteLine("======================================================================================================");
            System.Diagnostics.Debug.WriteLine(task.code.ToString());
            System.Diagnostics.Debug.WriteLine("======================================================================================================");

            Dictionary<string, string> dix = new Dictionary<string, string>();

            dix.Add("code", task.code);
            dix.Add("language", task.language);
            dix.Add("input_text", "1,1,1,1");

            var content = new FormUrlEncodedContent(dix);

            System.Diagnostics.Debug.WriteLine("======================================================================================================");
            System.Diagnostics.Debug.WriteLine(dix);
            System.Diagnostics.Debug.WriteLine("======================================================================================================");
            
            string jsonString = dix.FromDictionaryToJson();

            System.Diagnostics.Debug.WriteLine("======================================================================================================");
            System.Diagnostics.Debug.WriteLine(jsonString);
            System.Diagnostics.Debug.WriteLine("======================================================================================================");

            var response = await client.PostAsync("http://158.129.25.53:8080/test/", content);

            var responseString = await response.Content.ReadAsStringAsync();

            //ctrl+alt+object iskviecia outputa kur spausdina. requestai kaip ir eina visur, angularas stovi, perduoda viska
            // bet pitonui padavus neiseina nuskaityt responso normaliai.
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
