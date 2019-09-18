using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions
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

        public async Task<IRequestProviderResult<Auction>> GetAuctionDetailsAsync(Guid id)
        {
            return await ReqProvider.GetAsync<Auction, List<object>>(_apiSettings.GetAuctionByIdEndpoint, new List<object> { id.ToString() }, PassParamsBy.Route);
        }
    }
}
