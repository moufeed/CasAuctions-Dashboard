using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Text;         
using TamTech.CasAuctions.Dashboard.SDK.Core.Health;       
using TamTech.CasAuctions.Dashboard.SDK.Models.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;   

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class HealthChecksConfigurations
    {
     
        public static void AddHealthChecksConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var healthChecksUISettings = configuration.GetSection(AppSettings.HealthChecksUI)
                                                 .Get<HealthChecksUISettings>();
            if (healthChecksUISettings != null)
            {   
                services.AddHealthChecks()

                    .AddCheck<BackendHealthCheck>("POS-Backend-API",
                       failureStatus: HealthStatus.Degraded,
                        tags: new[] { "POS-Backend-API" })

                     .AddCheck<BackendDBHealthCheck>("POS-Backend-DB",
                       failureStatus: HealthStatus.Degraded,
                        tags: new[] { "POS-Backend-DB" })  ;
            

                void GetHealthChecksSettings(HealthChecks.UI.Configuration.Settings hcSettings)
                {
                    string rootUrl = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                     .GetSection(AppSettings.App_Url)
                                                                   .Get<string>();
                    hcSettings.SetEvaluationTimeInSeconds(healthChecksUISettings.EvaluationTimeOnSeconds);
                    hcSettings.SetMinimumSecondsBetweenFailureNotifications(healthChecksUISettings.MinimumSecondsBetweenFailureNotifications);
                    foreach (var item in healthChecksUISettings.HealthChecks)
                    {
                        if (!item.Uri.Contains("http"))
                        {
                            item.Uri = $"{rootUrl}/{item.Uri}";
                        }
                        hcSettings.AddHealthCheckEndpoint(item.Name, item.Uri);
                    }   
                }

                System.Action<HealthChecks.UI.Configuration.Settings> settings = GetHealthChecksSettings;
                services.AddHealthChecksUI("healthchecksdb", settings);
            }
        }
      

        public static void UseHealthChecksConfigurations(this IApplicationBuilder app, IConfiguration configuration)
        {
            var healthChecksUISettings =  configuration.GetSection(AppSettings.HealthChecksUI)
                                                   .Get<HealthChecksUISettings>() ;
            if (healthChecksUISettings != null)
            {

                app.UseHealthChecks(healthChecksUISettings.GeTUriForApp(), new HealthCheckOptions()
                {
                    ResultStatusCodes =
                  {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                  },

                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json; charset=utf-8";
                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(report));
                        await context.Response.Body.WriteAsync(bytes);
                    }
                });

                app.UseHealthChecksUI();
            }
        }
    }
}
