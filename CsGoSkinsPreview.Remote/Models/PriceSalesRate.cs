using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class PriceSalesRate
    {
        [JsonPropertyName("24_hours")]
        public DaySalesRate _24Hours { get; set; }

        [JsonPropertyName("7_days")]
        public WeekSalesRate _7Days { get; set; }

        [JsonPropertyName("30_days")]
        public MonthSalesRate _30Days { get; set; }

        [JsonPropertyName("all_time")]
        public AllTimeSalesRate AllTime { get; set; }

        [JsonPropertyName("opskins_average")]
        public double OpskinsAverage { get; set; }
    }
}
