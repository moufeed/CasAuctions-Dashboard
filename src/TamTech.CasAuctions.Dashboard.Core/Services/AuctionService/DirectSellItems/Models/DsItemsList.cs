using Newtonsoft.Json;
using System.Collections.Generic;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.DirectSellItems.Models
{
    public class DsItemsList
    {
        [JsonProperty("data")]
        public List<DsItem> Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationMetadataModel Pagination { get; set; }
    }
}