using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Statistics;     

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities
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
             



        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
        return MapToStatisticsDto(result);


        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByTypeAsync(string lang)
        {
            var result =  await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsBySectorAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsBySectorEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetVendorNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetVendorNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

       

         
    }
}
