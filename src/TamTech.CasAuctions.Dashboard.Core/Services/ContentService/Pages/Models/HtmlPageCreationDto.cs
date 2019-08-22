using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{
    public class CreateHtmlPageDto : PageModel
    {

        [Required]
        [JsonProperty("htmlcontent")]
        public string Content { get; set; }
    }
}
