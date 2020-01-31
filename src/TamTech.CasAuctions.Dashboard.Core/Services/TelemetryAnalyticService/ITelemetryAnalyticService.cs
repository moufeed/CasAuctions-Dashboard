using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService
{
   public  interface ITelemetryAnalyticService
    {
        Task<IRequestProviderResult<int>> GetCountActiveUsersAsync(DateTime fromDate, DateTime toDate);
    }
}
