using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;     
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService.settings;   
using TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService;
using TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService
{
   public  class AnalyticService : BaseAPIService , ITelemetryAnalyticService
    {
        #region prop                           
        private readonly ITelemetryApiSettings _apiSettings;  
        private const string _hederKeyAPIKey = "x-api-key";    
        #endregion


        public AnalyticService(ITelemetryApiSettings apiSettings, IRequestProvider requestProvider) : base(requestProvider)
        {
            _apiSettings = apiSettings;
        }

      
          
        public async Task<IRequestProviderResult<int>> GetCountActiveUsersAsync(DateTime fromDate, DateTime toDate)
        {       
            var url = $"{_apiSettings.QueryEndpoint}?{AnalyticQueryHelper.GetCountActiveUsersQuery(fromDate, toDate)}";
            var result = await ReqProvider.GetAsync<TelemetryReultModel>(url, false,   new Dictionary<string, string>() { { _hederKeyAPIKey, _apiSettings.Settings.APIKey } } );
            int conut = 0;
            if (result.Success)
            {    
                foreach (var table in result.Data.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        foreach (var item in row)
                        {
                            conut = Convert.ToInt32(item);
                        }
                    }
                }
            }
            return new RequestProviderResult<int>
            {
                Data = conut ,
                Header = result.Header,
                JsonHeader = result.JsonHeader,
                Messages = result.Messages,
                StatusCode = result.StatusCode,
                Success = result.Success,
            };
        }


    }
}
