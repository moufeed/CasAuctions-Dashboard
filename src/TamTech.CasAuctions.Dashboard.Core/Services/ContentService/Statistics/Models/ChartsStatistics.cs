using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Statistics.Models
{
   public class ChartsStatistics
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("key")]
        public string key { get; set; }
    }
}
