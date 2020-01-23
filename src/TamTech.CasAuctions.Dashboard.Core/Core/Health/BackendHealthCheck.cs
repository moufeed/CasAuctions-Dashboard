using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;   
using System.Threading;
using System.Threading.Tasks;              
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Health
{
    public class BackendHealthCheck : BaseHealthCheck, IHealthCheck
    {

        #region Props  

        #endregion

        #region Ctors  
        public BackendHealthCheck(BackendAPIsSettings backendApiSettings, ILogger<BackendHealthCheck> logger)
            : base(backendApiSettings, logger)
        {
        }
        #endregion


        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {

            //var healthCheckResultHealthy = SendAsync($"{_backendApiSettings.IdentityApiUrl}/api/Ping").GetAwaiter().GetResult().Status;

            //if (healthCheckResultHealthy)
            //{
            //    return Task.FromResult(
            //        HealthCheckResult.Healthy("The check ping backend api indicates a healthy result."));
            //}

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The check ping backend api an unhealthy result."));
        }


    }
}
