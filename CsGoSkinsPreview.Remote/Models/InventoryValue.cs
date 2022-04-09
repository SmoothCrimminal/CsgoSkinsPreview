using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Models
{
    public class InventoryValue
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
