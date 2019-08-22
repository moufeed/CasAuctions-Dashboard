using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.SEO
{
    public class Service : SeoSchema
    {

        [JsonProperty("provider")]
        public Organization Provider { get; set; } = new Organization();

    }
}
