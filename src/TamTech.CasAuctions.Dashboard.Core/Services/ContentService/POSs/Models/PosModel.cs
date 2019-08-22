using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Attachments;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Models
{
    public class PosModel : BasePosModel
    {
        [JsonProperty("specifications")]
        public List<SpecificationModel> Specifications { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentModel> Attachments { get; set; }

    }
}
