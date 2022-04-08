using CsGoSkinsPreview.Remote.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CsGoSkinsPreview.Remote.Remote
{
    public class ApiHelper : IApiHelper
    {
        public string ApiUrl => "http://csgobackpack.net/api";
        public async Task CheckHttpResult(Task<HttpResponseMessage> task)
        {
            await task;
            if (!task.Result.IsSuccessStatusCode)
            {
                string message = string.Empty;
                try
                {
                    message = task.Result.Content.ReadAsStringAsync().Result;
                    message = ": " + message;
                }
                catch { }
                throw new HttpRequestException($"Request failed: {(int)task.Result.StatusCode}/{task.Result.ReasonPhrase}{message}");
            }
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var task = client.GetAsync(url);
                await CheckHttpResult(task);
                return task.Result;
            }
        }

        public T GetStringResponseAs<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result.Result);
            }
            throw new HttpRequestException("Cannot read content from faulted response!");
        }

        public string QueryBuilder(Dictionary<string, string> queryParameters, string url)
        {
            var builder = new UriBuilder(url);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);

            foreach (KeyValuePair<string, string> keyValuePair in queryParameters)
            {
                query[keyValuePair.Key] = keyValuePair.Value;
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
