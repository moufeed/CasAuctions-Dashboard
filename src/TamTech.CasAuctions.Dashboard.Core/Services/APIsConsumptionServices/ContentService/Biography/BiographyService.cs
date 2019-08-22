using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Biography.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Biographies;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Biographies.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Biography
{
    public class BiographyService : BaseAPIService, IBiographyService
    {
        #region prop                           
        private readonly IBiographyApiSettings _apiSettings;
        #endregion

        #region ctor
        public BiographyService(IRequestProvider requestProvider, IBiographyApiSettings apiSettings) : base(requestProvider)
        {                  
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model)
        {
            return await ReqProvider.PostAsync<bool, UpdateBiographyModel>(_apiSettings.EditEndpoint, model);
        }

        public async Task<IRequestProviderResult<List<BiographyDto>>> GetAllAsync()
        {
            return await ReqProvider.GetAsync<List<BiographyDto>> (_apiSettings.GetAllEndpoint);
        }

        public async Task<IRequestProviderResult<List<BiographyDto>>> GetByGroupIdAsync(int groupId, string lang)
        {
            return await ReqProvider.GetAsync<List<BiographyDto>, List<object>> (_apiSettings.GetByGroupIdEndpoint, new List<object> { groupId , lang }, PassParamsBy.Route);
        }
        #endregion
    }
}
