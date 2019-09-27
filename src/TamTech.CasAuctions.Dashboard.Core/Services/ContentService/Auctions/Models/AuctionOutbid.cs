using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
    public class AuctionOutbid
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("pid")]
        public Guid ParticipantId { get; set; }

        [JsonProperty("profile")]
        public UserProfileDto Profile { get; set; }

        [JsonProperty("pr")]
        public double Price { get; set; }

        [JsonProperty("d")]
        public DateTime CreatedDate { get; set; }
    }
}
