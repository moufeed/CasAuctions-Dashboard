using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Settings;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService.settings
{
    public interface ITelemetryApiSettings
    {
        string QueryEndpoint { get; }
         ApplicationInsightsSettings Settings { get; }
       
    }
}
