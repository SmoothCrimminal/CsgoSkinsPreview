using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class WeekSalesRate
    {
        [JsonPropertyName("average")]
        public decimal Average { get; set; }

        [JsonPropertyName("median")]
        public decimal Median { get; set; }

        [JsonPropertyName("sold")]
        public string Sold { get; set; }

        [JsonPropertyName("standard_deviation")]
        public string StandardDeviation { get; set; }

        [JsonPropertyName("lowest_price")]
        public decimal LowestPrice { get; set; }

        [JsonPropertyName("highest_price")]
        public decimal HighestPrice { get; set; }
    }
}
