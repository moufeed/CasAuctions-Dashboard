using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Values.Models
{
   public class ValueDto : BaseLookupDto
    {
        [JsonProperty("attid")]
        public int AttId { get; set; }
        [JsonProperty("attributename")]
        public string AttributeName { get; set; }
    }
}
