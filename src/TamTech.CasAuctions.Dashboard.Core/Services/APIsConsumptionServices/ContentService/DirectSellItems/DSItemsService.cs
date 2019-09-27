using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.DirectSellItems.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.DirectSellItems;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.DirectSellItems.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.DirectSellItems
{
   public  class DSItemsService : BaseAPIService , IDsItemsService
    {
        #region prop                           
        private readonly IDsItemsApiSettings _apiSettings;

        public DSItemsService(IDsItemsApiSettings apiSettings, IRequestProvider requestProvider) : base(requestProvider)
        {
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<DsItemsList>> GetAllItemsListAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<DsItemsList, DTFilter>(_apiSettings.allItemsEndpoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetCatgoriesListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.CategoriesListEndpoint);
        }

        public async Task<IRequestProviderResult<DsItemDetails>> GetDsItemDetailsAsync(Guid id)
        {
            return await ReqProvider.GetAsync<DsItemDetails, List<object>>(_apiSettings.itemByIdEndpoint, new List<object> { id.ToString() }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetStatusListAsync()
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>>(_apiSettings.StatusListEndpoint);
        }

        public async Task<IRequestProviderResult<CasAuctionResponsModel<DsItemDetails>>> TakeActionAsync(TakeActionModel model)
        {
            return await ReqProvider.PostAsync<CasAuctionResponsModel<DsItemDetails>, TakeActionModel>(_apiSettings.TakeActionEndpoint, model);
        }
        #endregion




    }
}
