using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination
{
    public class PaginationMetadataModel
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("pageNumber")]
        public string PageNumber { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("previousPage")]
        public bool PreviousPage { get; set; } = false;

        [JsonProperty("nextPage")]
        public bool NextPage { get; set; } = false;

         
    }
}