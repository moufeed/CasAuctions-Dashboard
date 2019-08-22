using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq; 
using TamTech.CasAuctions.Dashboard.SDK.Core.Telemetry; 

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class TelemetryConfigurations
    {
        public static void AddTelemetryConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            if (!services.Any(s => s.ServiceType == typeof(ITelemetryService)))
            { 
                services.AddTransient<ITelemetryService, TelemetryService> ();
            }
        }

    }
}
