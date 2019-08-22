using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContentCommonUtilities;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContentCommonUtilities.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities
{
    public class CCUServices : BaseAPIService, ICCUServices
    {

        #region Props          
        private readonly ICCUApiSettings _apiSettings;
        #endregion


        public CCUServices(IRequestProvider requestProvider, ICCUApiSettings apiSettings) : base(requestProvider)
        {      
            _apiSettings = apiSettings;

        }

        public async Task<IRequestProviderResult<Dictionary<string, Dictionary<string, string>>>> GetListsModulesForMenuItemsTypesAsync(List<string> model, string lang)
        {
            CCUModel<List<string>> Data = new CCUModel<List<string>>()
            {
                Lang = lang,
                Types = model
            };
            return await ReqProvider.GetAsync<Dictionary<string, Dictionary<string, string>>, CCUModel<List<string>>>(_apiSettings.GetListsModulesForMenuItemsTypesEndpoint , Data, PassParamsBy.Body);
        }

        public async  Task<IRequestProviderResult<Dictionary<string, NumericalStatisticsDto>>> GetNumericalStatisticsAsync(List<string> types, string lang)
        {
            CCUModel<List<string>> Data = new CCUModel<List<string>>()
            {
                Lang = lang,
                Types = types
            };
            return await ReqProvider.GetAsync<Dictionary<string, NumericalStatisticsDto>, CCUModel<List<string>>>(_apiSettings.GetNumericalStatisticsEndpoint, Data, PassParamsBy.Body);
        }



    }
}
