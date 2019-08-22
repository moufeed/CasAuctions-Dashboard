using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Attributes.Models
{
    public class AttributeDto  : BaseLookupDto
    {
        [JsonProperty("values")]
        public List<ValueDto> Values { get; set; }

        [JsonProperty("choicetype")]
        public int ChoiceType { get; set; }

        [JsonProperty("inputtype")]
        public int InputType { get; set; }

        [JsonProperty("ismandatory")]
        public bool IsMandatory { get; set; }


    }
}
