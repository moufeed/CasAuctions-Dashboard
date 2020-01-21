using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Statistics
{
    public interface IStatisticsService
    {          
        Task<IRequestProviderResult<StatisticsDto>> GetUsersStatistics(string lang);
        Task<IRequestProviderResult<StatisticsDto>> GetAuctionsStatistics(DateTime fromDate, DateTime toDate , int? TimeZone);

    }
}
