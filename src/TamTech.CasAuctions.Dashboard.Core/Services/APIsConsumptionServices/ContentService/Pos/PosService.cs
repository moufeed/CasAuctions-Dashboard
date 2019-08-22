using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Slugs;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Directory.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pos
{
    public class PosService : BaseAPIService , IPOSService
    {
        #region prop      
        private readonly IPosApiSettings _apiSettings;
        #endregion

        #region ctor
        public PosService(IRequestProvider requestProvider, IPosApiSettings apiSettings) : base(requestProvider)
        {            
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePosModel model)
        {
            return await ReqProvider.PostAsync<Guid, CreatePosModel>(_apiSettings.CreateEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePosModel model)
        {
            return await ReqProvider.PostAsync<bool, UpdatePosModel>(_apiSettings.EditEndpoint, model);
        }

        public async Task<IRequestProviderResult<PosDto>> GetByIdAndCurrentUserExceptSoftDeletedAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetByIdAndCurrentUserExceptSoftDeletedEndpoint, new List<object> { id , lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> GetPOSsForCurrentUserAsync(PosFilters model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<PosDto>>, PosFilters>(_apiSettings.GetPOSsForCurrentUserEndpoint, model , PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteByCurrentUserAsync(Guid id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.SoftDeleteByCurrentUserEndpoint, new DeleteModel<Guid>(id));
        }

        public async Task<IRequestProviderResult<bool>> VerifySlugUniqueAsync(string slug, Guid? id = null)
        {
            return await ReqProvider.GetAsync<bool, List<object>>(_apiSettings.VerifySlugUniqueEndpoint, new List<object> { slug, id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<GeneratedSlugModel>> VerifySlugUniqueByNameAsync(string name, Guid? id = null)
        {
            return await ReqProvider.GetAsync<GeneratedSlugModel, VerifyNameModel<Guid?>>(_apiSettings.VerifySlugUniqueByNameEndpoint, new VerifyNameModel<Guid?>(){ Name= name, Id = id }, PassParamsBy.Body);
        }
    }
}
