using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class Price
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("average_price")]
        public double AveragePrice { get; set; }

        [JsonProperty("median_price")]
        public double MedianPrice { get; set; }

        [JsonProperty("amount_sold")]
        public int AmountSold { get; set; }

        [JsonProperty("standard_deviation")]
        public double StandardDeviation { get; set; }

        [JsonProperty("lowest_price")]
        public double LowestPrice { get; set; }

        [JsonProperty("highest_price")]
        public double HighestPrice { get; set; }

        [JsonProperty("first_sale_date")]
        public long FirstSaleDate { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
