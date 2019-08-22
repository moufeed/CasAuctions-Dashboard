using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Regions.Models
{
    public class UpdateRegionModel : RegionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
