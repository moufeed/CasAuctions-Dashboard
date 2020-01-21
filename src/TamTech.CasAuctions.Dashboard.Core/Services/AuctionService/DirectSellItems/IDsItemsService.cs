using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.DirectSellItems.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.DirectSellItems
{
    public interface IDsItemsService
    {

        Task<IRequestProviderResult<DsItemsList>> GetAllItemsListAsync(DTFilter model);

        Task<IRequestProviderResult<DsItemDetails>> GetDsItemDetailsAsync(Guid id);

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetStatusListAsync();
        Task<IRequestProviderResult<List<SelectListItemModel>>> GetCatgoriesListAsync();
        
        Task<IRequestProviderResult<CasAuctionResponsModel<DsItemDetails>>> TakeActionAsync(TakeActionModel model);
    }
}
