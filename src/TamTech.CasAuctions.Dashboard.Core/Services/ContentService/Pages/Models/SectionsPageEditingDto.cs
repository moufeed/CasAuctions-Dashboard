using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{
    public class EditSectionsPageDto :PageModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        
        [Required]
        [JsonProperty("sectionscontent")]
        public Dictionary<string, string> Content { get; set; }

    }
}
