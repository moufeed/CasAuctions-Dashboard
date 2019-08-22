using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Core.Helpers;
using Microsoft.Extensions.Localization;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Menus.Models
{
    public class CreateMenuDto
    {
        [Required]
        [JsonProperty("key")]
        [RegularExpression(Constants.SlugRegx)]
        public string Key { get; set; }


        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("Lang")]
        public string Lang { get; set; }

    }
}
