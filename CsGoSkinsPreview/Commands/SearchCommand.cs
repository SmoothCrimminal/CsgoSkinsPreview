using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsGoSkinsPreview.Models;
using CsGoSkinsPreview.Remote.Models;
using CsGoSkinsPreview.ViewModels;

namespace CsGoSkinsPreview.Commands
{
    public class SearchCommand : AsyncCommandBase<SearchCommandArguments, IEnumerable<Skin>>
    {
        private readonly MainPageVM _mainPageVM;

        public SearchCommand(MainPageVM mainPageVM)
        {
            _mainPageVM = mainPageVM;
        }
        public async override Task<IEnumerable<Skin>> ExecuteAsync(SearchCommandArguments parameter)
        {
            var resultPriceFrom = decimal.TryParse(parameter.PriceFrom, out var priceFrom) ? priceFrom : 0;
            var resultPriceTo = decimal.TryParse(parameter.PriceTo, out var priceTo) ? priceTo : decimal.MaxValue;
            var resultWeaponType = !string.IsNullOrEmpty(parameter.WeaponType);
            var resultSkinName = !string.IsNullOrEmpty(parameter.SkinName);
            var skins = new ObservableCollection<Skin>();
            
            if (resultWeaponType && resultSkinName)
                skins = new ObservableCollection<Skin>(_mainPageVM.CsGoWeapons.Where(x => x.Price?._7Days?.Average >= resultPriceFrom && x.Price?._7Days?.Average <= resultPriceTo && x.WeaponType == parameter.WeaponType && x.Name.Contains(parameter.SkinName, StringComparison.OrdinalIgnoreCase)));
            else if (resultWeaponType && !resultSkinName)
                skins = new ObservableCollection<Skin>(_mainPageVM.CsGoWeapons.Where(x => x.Price?._7Days?.Average >= resultPriceFrom && x.Price?._7Days?.Average <= resultPriceTo && x.WeaponType == parameter.WeaponType));
            else if (resultSkinName && !resultWeaponType)
                skins = new ObservableCollection<Skin>(_mainPageVM.CsGoWeapons.Where(x => x.Price?._7Days?.Average >= resultPriceFrom && x.Price?._7Days?.Average <= resultPriceTo && x.Name.Contains(parameter.SkinName, StringComparison.OrdinalIgnoreCase)));
            else
                skins = new ObservableCollection<Skin>(_mainPageVM.CsGoWeapons.Where(x => x.Price?._7Days?.Average >= resultPriceFrom && x.Price?._7Days?.Average <= resultPriceTo));

            _mainPageVM.FilteredCsGoWeapons = skins;

            return null;
        }
    }
}
