using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{
    public class HtmlPage : PageDto
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

     
}
