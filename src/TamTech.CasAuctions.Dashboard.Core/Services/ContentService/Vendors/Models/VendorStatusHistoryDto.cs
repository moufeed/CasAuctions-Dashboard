using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Vendors.Models
{
    public class VendorStatusHistoryDto : StatusHistoryDto
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("actionname")]
        public string ActionName { get; set; }
    }
}
