using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Types.Models
{
    public class CreateTypeModel :TypeModel
    {
        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }

        
    }
}
