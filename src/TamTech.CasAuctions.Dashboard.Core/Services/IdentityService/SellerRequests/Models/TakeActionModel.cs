using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models
{
    public class TakeActionModel
    {
        [JsonProperty("req_id")]
        public Guid ReqId { get; set; }
        [JsonProperty("action_id")]
        public int ActionId { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
