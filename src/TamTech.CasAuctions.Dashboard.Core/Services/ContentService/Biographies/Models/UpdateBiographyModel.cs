using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Biographies.Models
{
    public class UpdateBiographyModel
    {
        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("biographies")]
        public List<BiographyModel> Biographies { get; set; }
    }
}
