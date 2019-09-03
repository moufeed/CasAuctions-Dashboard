using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common
{
    public class ProcessActionModel
    {
        [JsonProperty("action_id")]
        public int ActionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notification_msg")]
        public string NotificationMsg { get; set; }

        [JsonProperty("mandatory_notes")]
        public bool NoteMandatory { get; set; }

    }
}
