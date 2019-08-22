using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Settings
{
    public class SeriLogSettings
    {
        public string PathFormat { get; set; }
        public string MinimumLevel { get; set; }
        public long? FileSizeLimitBytes { get; set; }

    }
}
