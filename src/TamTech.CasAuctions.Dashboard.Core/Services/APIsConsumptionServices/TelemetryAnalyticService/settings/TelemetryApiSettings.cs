using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService.settings
{
    public class  TelemetryApiSettings : ITelemetryApiSettings
    {
        private readonly string _apiUrl;
        private readonly ApplicationInsightsSettings _settings;

        public TelemetryApiSettings(ApplicationInsightsSettings settings) 
        {
            _settings = settings ;
            _apiUrl = settings.APIUrl.TrimEnd('/');
        }

        public string QueryEndpoint => $"{string.Format(_apiUrl, _settings.AppId)}/query";
        public ApplicationInsightsSettings Settings => _settings;
     

    }
}
