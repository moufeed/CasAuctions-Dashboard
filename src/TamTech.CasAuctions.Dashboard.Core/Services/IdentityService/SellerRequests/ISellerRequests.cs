using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests
{
    public interface ISellerRequests
    {
            Task<IRequestProviderResult<SellerRequestsList>> GetAllRequestsListAsync(DTFilter model);
            Task<IRequestProviderResult<SellerRequest>> GetRequestDetailsAsync(Guid id);
            Task<IRequestProviderResult<List<ProcessActionModel>>> GetRequestActionsAsync(Guid id);
            Task<IRequestProviderResult<CasAuctionResponsModel<SellerRequest>>> TakeActionAsync(TakeActionModel model);
            Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync();     
            Task<IRequestProviderResult<CasAuctionResponsModel<bool>>> AddPrivatePermission(Guid id);

        Task<IRequestProviderResult<List<Role>>> GetUserRoles(string userName);
    }
}
 