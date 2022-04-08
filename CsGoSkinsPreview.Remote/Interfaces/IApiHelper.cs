using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Interfaces
{
    public interface IApiHelper
    {
        public string ApiUrl { get; }
        Task<HttpResponseMessage> Get(string url);
        T GetStringResponseAs<T>(HttpResponseMessage response);
        Task CheckHttpResult(Task<HttpResponseMessage> task);
        string QueryBuilder(Dictionary<string, string> queryParameters, string url);
    }
}
