using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Models
{
    public class POSStatusHistoryDto : StatusHistoryDto
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("actionname")]
        public string ActionName { get; set; }
    }
}
