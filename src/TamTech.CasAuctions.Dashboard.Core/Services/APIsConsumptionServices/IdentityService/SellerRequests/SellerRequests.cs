using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService.SellerRequests.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests;
using TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService.SellerRequests
{
    public class SellerRequests : BaseAPIService, ISellerRequests
    {
        #region prop        
        private readonly IRequestApiEndpoints _apiSettings;
        #endregion

        public SellerRequests(IRequestApiEndpoints apiSettings, IRequestProvider requestProvider) : base(requestProvider)
        {
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<SellerRequestsList>> GetAllRequestsListAsync(DTFilter model)
        {
           return await ReqProvider.GetAsync<SellerRequestsList, DTFilter>(_apiSettings.RequestsListEndpoint, model, PassParamsBy.Body);
            //return await ReqProvider.GetAsync<SellerRequestsList>(_apiSettings.RequestsListEndpoint);
        }
       

        public async Task<IRequestProviderResult<SellerRequest>> GetRequestDetailsAsync(Guid id)
        {
            return await ReqProvider.GetAsync<SellerRequest, List<object>>(_apiSettings.RequestDetialsEndpoint, new List<object> { id.ToString() }, PassParamsBy.Route);
        }



        public async Task<IRequestProviderResult<List<ProcessActionModel>>> GetRequestActionsAsync(Guid id)
        {
            return await ReqProvider.GetAsync<List<ProcessActionModel>, List<object>>(_apiSettings.ProcessActionsEndpoint, new List<object> { id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<CasAuctionResponsModel<SellerRequest>>> TakeActionAsync(TakeActionModel model)
        {
            return await ReqProvider.PostAsync<CasAuctionResponsModel<SellerRequest>, TakeActionModel>(_apiSettings.TakeActionEndpoint, model);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.StatusListEndpoint);
        }
    }
}

