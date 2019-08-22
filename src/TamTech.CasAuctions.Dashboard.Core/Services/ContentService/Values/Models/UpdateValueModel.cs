using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Values.Models
{
    public class UpdateValueModel : ValueModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
    }
}
