using CsGoSkinsPreview.Remote.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.ViewModels
{
    public class MainPageVM
    {
        private readonly IApiCaller _apiCaller;

        public MainPageVM(IApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task Initialize()
        {
            var allCsItems = await _apiCaller.GetAllItems();
            var allCsWeapons = allCsItems.ItemsList?.Where(x => x.Type == "Weapon" && !string.IsNullOrEmpty(x.Type));
        }
    }
}
