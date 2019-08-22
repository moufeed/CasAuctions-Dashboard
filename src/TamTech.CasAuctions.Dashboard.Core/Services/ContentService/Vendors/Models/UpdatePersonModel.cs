using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Vendors.Models
{
    public class UpdatePersonModel : PersonModel
    {
        [JsonProperty("vendor")]
        public UpdateVendorModel Vendor { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
