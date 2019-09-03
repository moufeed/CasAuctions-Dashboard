using System;
using Newtonsoft.Json;


namespace TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models
{
    public class SellerRequestHistory
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("action_id")]
        public int ActionId { get; set; }
        [JsonProperty("current_status_id")]
        public int CurrentStatusId { get; set; }
        [JsonProperty("previous_status_id")]
        public int PreviousStatusId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("date")]
        public DateTime ProcessDate { get; set; }
        [JsonProperty("current_status_name")]
        public string CurrentStatusName { get; set; }
        [JsonProperty("previous_status_name")]
        public string PreviousStatusName { get; set; }

        [JsonProperty("action_name")]
        public string ActionName { get; set; }

}
}
