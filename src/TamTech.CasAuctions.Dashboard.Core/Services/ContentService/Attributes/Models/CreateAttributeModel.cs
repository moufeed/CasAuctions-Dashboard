using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Attributes.Models
{
    public class CreateAttributeModel : AttributeModel
    {

        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }
        
    }
}
