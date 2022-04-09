using CsGoSkinsPreview.Remote.Interfaces;
using CsGoSkinsPreview.Remote.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<SkinsRealRoot> GetAllItems()
        {
            var queryDict = Tools.ObjectToDictionary(new SkinsQueryParameters
            {
                Currency = "PLN",
            });
            var query = _apiHelper.QueryBuilder(queryDict, $"{_apiHelper.ApiUrl}/GetItemsList/v2");
            var dto = await _apiHelper.Get(query);
            var skinsRoot = _apiHelper.GetStringResponseAs<SkinsRoot>(dto);
            return new SkinsRealRoot()
            {
                Currency = skinsRoot.Currency,
                Success = skinsRoot.Success,
                Timestamp = skinsRoot.Timestamp,
                ItemsList = (JsonConvert.DeserializeObject(skinsRoot.ItemsList.ToString()) as JObject).Children().Select(x => System.Text.Json.JsonSerializer.Deserialize<Skin>(x.First.ToString())).ToList()
            };
        }

        public async Task<InventoryValue> GetInventoryValue(string inventoryID)
        {
            var queryDict = Tools.ObjectToDictionary(new QueryParameters
            {
                Id = inventoryID,
                Currency = "PLN"
            });
            var query = _apiHelper.QueryBuilder(queryDict, $"{_apiHelper.ApiUrl}/GetInventoryValue");
            var dto = await _apiHelper.Get(query);
            var res = _apiHelper.GetStringResponseAs<InventoryValue>(dto);
            return res;
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
            var query = _apiHelper.QueryBuilder(queryDict, $"{_apiHelper.ApiUrl}/GetItemPrice");
            var dto = await _apiHelper.Get(query);
            var res = _apiHelper.GetStringResponseAs<Price>(dto);
            return res;
        }
    }
}
