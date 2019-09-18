using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
    public class AuctionsList
    {
        [JsonProperty("data")]
        public List<Auction> Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationMetadataModel Pagination { get; set; }
    }
}
