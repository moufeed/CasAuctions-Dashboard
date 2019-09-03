using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models
{
    public class CasAuctionResponsModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("success")]
        public string Success { get; set; }
    }

}

