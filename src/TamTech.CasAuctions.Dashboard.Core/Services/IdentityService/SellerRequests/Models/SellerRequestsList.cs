using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models
{
   public class SellerRequestsList
    {
        [JsonProperty("data")]
        public List<SellerRequest> Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationMetadataModel Pagination { get; set; }
    }
}
