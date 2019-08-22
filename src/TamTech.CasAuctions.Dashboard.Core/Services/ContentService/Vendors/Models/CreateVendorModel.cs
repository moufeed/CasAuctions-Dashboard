using System.Collections.Generic;
using Newtonsoft.Json;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Attachments;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Vendors.Models
{
    public class CreateVendorModel : VendorModel
    {
        [JsonProperty("attachments")]
        public List<AttachmentModel> Attachments { get; set; }
    }
}