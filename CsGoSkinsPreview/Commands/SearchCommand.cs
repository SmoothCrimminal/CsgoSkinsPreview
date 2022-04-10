using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsGoSkinsPreview.Models;
using CsGoSkinsPreview.Remote.Models;

namespace CsGoSkinsPreview.Commands
{
    public class SearchCommand : AsyncCommandBase<SearchCommandArguments, IEnumerable<Skin>>
    {
        public async override Task<IEnumerable<Skin>> ExecuteAsync(SearchCommandArguments parameter)
        {
            var resultPriceFrom = decimal.TryParse(parameter.PriceFrom, out var priceFrom) ? priceFrom : 0;
            var resultPriceTo = decimal.TryParse(parameter.PriceTo, out var priceTo) ? priceTo : decimal.MaxValue;
            var resultWeaponType = !string.IsNullOrEmpty(parameter.WeaponType);
            
            if (resultWeaponType)
            {
                return parameter.AllSkins.Where(x => x.Price?._7Days?.Average >= priceFrom && x.Price?._7Days?.Average <= priceTo && x.WeaponType == parameter.WeaponType);
            }

            return parameter.AllSkins.Where(x => x.Price?._7Days?.Average >= priceFrom && x.Price?._7Days?.Average <= priceTo);

        }
    }
}
