using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Sort

{
    public class SortingModel
    {
        [JsonProperty("sortby")]
        public string SortBy {get; set;}

        [JsonProperty("descending")]
        public bool Descending {get; set;}
    }
}
