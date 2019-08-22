using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{
    public class SectionsPage : PageDto
    {
        [JsonProperty("content")]
        public Dictionary<string, string> Content { get; set; } = new Dictionary<string, string>();
    } 
}
