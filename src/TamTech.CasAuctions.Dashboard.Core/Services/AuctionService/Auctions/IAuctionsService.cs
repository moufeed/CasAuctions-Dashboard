using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions.Models;   

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions
{
    public interface IAuctionsService
    {

        Task<IRequestProviderResult<AuctionsList>> GetAllAuctionsListAsync(DTFilter model);
        
        Task<IRequestProviderResult<AuctionDetails>> GetAuctionDetailsAsync(Guid id);
         
        Task<IRequestProviderResult<List<SelectListItemModel>>> GetStatusListAsync();
        Task<IRequestProviderResult<List<SelectListItemModel>>> GetCatgoriesListAsync();
        Task<IRequestProviderResult<List<SelectListItemModel>>> GetTypesListAsync();

        Task<IRequestProviderResult<CasAuctionResponsModel<AuctionDetails>>> TakeActionAsync(TakeActionModel model);
    }
}
