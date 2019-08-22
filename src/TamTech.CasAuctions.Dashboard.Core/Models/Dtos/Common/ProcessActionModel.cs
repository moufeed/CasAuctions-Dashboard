using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common
{
    public class ProcessActionModel
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notemandatory")]
        public bool NoteMandatory { get; set; }

    }
}
