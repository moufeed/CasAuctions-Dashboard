using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Shared
{
    public class UserRole
    {
        public string userRole;
        public Guid userId;
    }


    public class Role
    {
        [JsonProperty("id")]
        public Guid Id;

        [JsonProperty("name")]
        public string Name;
    }
}
