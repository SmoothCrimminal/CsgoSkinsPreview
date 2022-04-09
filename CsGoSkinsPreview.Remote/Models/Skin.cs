using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class Skin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("marketable")]
        public int Marketable { get; set; }

        [JsonPropertyName("tradable")]
        public int Tradable { get; set; }

        [JsonPropertyName("classid")]
        public string Classid { get; set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("icon_url_large")]
        public string IconUrlLarge { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("weapon_type")]
        public string WeaponType { get; set; }

        [JsonPropertyName("gun_type")]
        public string GunType { get; set; }

        [JsonPropertyName("exterior")]
        public string Exterior { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("rarity_color")]
        public string RarityColor { get; set; }

        [JsonPropertyName("price")]
        public PriceSalesRate Price { get; set; }

        [JsonPropertyName("first_sale_date")]
        public string FirstSaleDate { get; set; }
    }
}
