using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models; 
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Vendors.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Vendors
{
    public interface IVendorAdminServices
    {
        #region Get

        Task<IRequestProviderResult<List<ProcessActionModel>>> GetVendorActions(string lang);

        Task<IRequestProviderResult<PagedResultModel<List<PersonDto>>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<IRequestProviderResult<PersonDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang);
        #endregion

        #region

        Task<IRequestProviderResult<PersonDto>> SetActionAsync(SetActionModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> ActivateAsync(ActiveModel model);

        Task<IRequestProviderResult<List<VendorStatusHistoryDto>>> GetStatusHistoriesListAsync(Guid VId, string lang);
        #endregion
    }
}
