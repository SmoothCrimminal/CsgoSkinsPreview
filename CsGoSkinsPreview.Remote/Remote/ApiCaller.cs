using CsGoSkinsPreview.Remote.Interfaces;
using CsGoSkinsPreview.Remote.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Remote
{
    public class ApiCaller : IApiCaller
    {
        private readonly IApiHelper _apiHelper;

        public ApiCaller(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public Task<bool> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetInventoryValue()
        {
            throw new NotImplementedException();
        }

        public async Task<Price> GetItemPrice(string itemID)
        {
            var queryDict = Tools.ObjectToDictionary(new QueryParameters
            {
                Currency = "PLN",
                Id = itemID,
                Time = "7",
                Icon = "1"
            });
            var query = _apiHelper.QueryBuilder(queryDict, _apiHelper.ApiUrl);
            var dto = await _apiHelper.Get(query);
            var res = _apiHelper.GetStringResponseAs<Price>(dto);
            return res;
        }
    }
}
