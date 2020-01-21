using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos
{
    public class StatisticsDto
    {
        
        [JsonProperty("statistics")]
        public List<NumericalStatisticsItemDto> Statistics { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        
        [JsonProperty("data")]
        public List<int> Data { get; set; }
    }
}
