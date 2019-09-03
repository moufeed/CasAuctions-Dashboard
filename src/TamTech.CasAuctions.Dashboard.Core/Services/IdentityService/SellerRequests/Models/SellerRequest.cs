using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models
{
    public class SellerRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("status_id")]
        public int StatusId { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty("modifier_user_id")]
        public string ModifierUserId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("status_name")]
        public string StatusName { get; set; }
        [JsonProperty("status_options")]
        public string StatusOptions { get; set; }
        [JsonProperty("histories")]
        public List<SellerRequestHistory> Histories { get; set; }
    }
}
