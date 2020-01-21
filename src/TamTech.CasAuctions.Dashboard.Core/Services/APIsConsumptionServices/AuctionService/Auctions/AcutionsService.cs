using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.Auctions.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.Auctions
{
   public  class AcutionsService : BaseAPIService , IAuctionsService
    {
        #region prop                           
        private readonly IAuctionsApiSettings _apiSettings;
        #endregion


        public AcutionsService(IAuctionsApiSettings apiSettings , IRequestProvider requestProvider) : base(requestProvider)
        {
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<AuctionsList>> GetAllAuctionsListAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<AuctionsList, DTFilter>(_apiSettings.GetALlAuctionsEndpoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<AuctionDetails>> GetAuctionDetailsAsync(Guid id)
        {
            return await ReqProvider.GetAsync<AuctionDetails, List<object>>(_apiSettings.GetAuctionByIdEndpoint, new List<object> { id.ToString() }, PassParamsBy.Route);
        }

        public async  Task<IRequestProviderResult<List<SelectListItemModel>>> GetCatgoriesListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.GetCategoriesListEndpoint);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetStatusListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.GetStatusListEndpoint);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetTypesListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.GetTypesListEndpoint);
        }

        public  async Task<IRequestProviderResult<CasAuctionResponsModel<AuctionDetails>>> TakeActionAsync(TakeActionModel model)
        {
            return await ReqProvider.PostAsync<CasAuctionResponsModel<AuctionDetails>, TakeActionModel>(_apiSettings.TakeActionEndpoint, model);
        }

       
    }
}
