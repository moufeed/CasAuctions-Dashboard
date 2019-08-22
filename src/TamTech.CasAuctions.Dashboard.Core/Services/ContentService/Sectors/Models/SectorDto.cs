using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Sectors.Models
{
    public class SectorDto : BaseLookupDto
    {
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }
    }
}
