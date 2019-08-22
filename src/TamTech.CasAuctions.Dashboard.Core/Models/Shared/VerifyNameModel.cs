using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Shared
{
    public class VerifyNameModel<T>
    {
        [JsonProperty("id")]
        public T Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
