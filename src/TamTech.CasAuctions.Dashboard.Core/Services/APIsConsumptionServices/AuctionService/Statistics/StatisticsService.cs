using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Statistics.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Statistics;    

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Statistics
{
   public class StatisticsService : BaseAPIService, IStatisticsService
    {

        #region Props        
        private readonly IStatisticsApiSettings _apiSettings;
        #endregion



        public StatisticsService(IRequestProvider requestProvider, IStatisticsApiSettings apiSettings) : base(requestProvider)
        {           
            _apiSettings = apiSettings;
        }

    
     




        public async Task<IRequestProviderResult<StatisticsDto>> GetUsersStatistics(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<ChartsStatistics>>(_apiSettings.GetUsersStatisticsEndpoint);
            return MapToChartsDTo(result);
        }


        public async Task<IRequestProviderResult<StatisticsDto>> GetAuctionsStatistics(DateTime fromDate, DateTime toDate , int? TimeZone)
        {
            var prms = $"fromDate={fromDate.ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss")}&toDate={toDate.ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss")}";
            var url = $"{_apiSettings.GetAuctionsStatisticsByDate}?{prms}";
            var result = await ReqProvider.GetAsync<IEnumerable<ChartsStatistics>>(url,false, TimeZone != null ? new Dictionary<string, string>() { { "device_time_zone", TimeZone.ToString() } } : null);
            return MapToChartsDTo(result);
        }



      
    }
}
