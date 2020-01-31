using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Settings
{
    public class ApplicationInsightsSettings
    {
        public string InstrumentationKey { get; set; }
        public string APIKey { get; set; }
        public string AppId { get; set; }    
        public string APIUrl { get; set; }
    }
}
