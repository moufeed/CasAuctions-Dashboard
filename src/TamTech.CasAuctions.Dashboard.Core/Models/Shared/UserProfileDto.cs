using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Shared
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
    }
}
