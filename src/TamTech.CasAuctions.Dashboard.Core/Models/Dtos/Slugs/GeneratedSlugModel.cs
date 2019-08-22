using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Slugs
{
    public class GeneratedSlugModel
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("unique")]
        public bool Unique { get; set; }
    }
}
