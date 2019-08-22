using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Sectors.Models
{
   public class CreateSectorModel : SectorModel
    {
        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }
    }
}
