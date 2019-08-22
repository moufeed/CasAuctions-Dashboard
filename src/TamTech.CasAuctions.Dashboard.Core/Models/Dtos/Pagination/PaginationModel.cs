using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination
{
   public class PaginationModel
    {
        [JsonProperty("pagenumber")]
        public string PageNumber { get; set; } = "1";

        [JsonProperty("pagesize")]
        public int PageSize { get; set; } = 10 ;
    }
}
