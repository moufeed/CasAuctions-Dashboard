using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.SEO
{
    public class Person
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Person";

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
