using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class AllTimeSalesRate
    {
        [JsonPropertyName("average")]
        public double Average { get; set; }

        [JsonPropertyName("median")]
        public double Median { get; set; }

        [JsonPropertyName("sold")]
        public string Sold { get; set; }

        [JsonPropertyName("standard_deviation")]
        public string StandardDeviation { get; set; }

        [JsonPropertyName("lowest_price")]
        public double LowestPrice { get; set; }

        [JsonPropertyName("highest_price")]
        public double HighestPrice { get; set; }
    }
}
