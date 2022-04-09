using CsGoSkinsPreview.Remote.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote
{
    public static class Tools
    {
        public static Dictionary<string, string> ObjectToDictionary<T>(T source)
        {
            var dict = new Dictionary<string, string>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (value is string)
                {
                    dict.Add(property.Name.ToLower(), (string)value);
                }
            }
            return dict;
        }

        public static Skin ConvertJTokenToSkinObject(JToken j)
        {
            if (j is not null)
            {
                return new Skin()
                {
                    FirstSaleDate = j["first_sale_date"].Value<string>() ?? null,
                    Rarity = j["rarity"].Value<string>() ?? null,
                    RarityColor = j["rarity_color"].Value<string>() ?? null,
                    Exterior = j["exterior"].Value<string>() ?? null,
                    GunType = j["gun_type"].Value<string>() ?? null,
                    WeaponType = j["weapon_type"].Value<string>() ?? null,
                    IconUrl = j["icon_url"].Value<string>() ?? null,
                    IconUrlLarge = j["icon_url_large"].Value<string>() ?? null,
                    Classid = j["classid"].Value<string>() ?? null,
                    Marketable = j["marketable"].Value<int>(),
                    Tradable = j["tradable"].Value<int>(),
                    Name = j["name"].Value<string>() ?? null,
                };
            }

            return null;
        } 
    }
}
