using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Values.Models
{
    public class ValueModel : BaseLookupModel
    {
        [JsonProperty("attid")]
        public int AttId { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }


    }
}
