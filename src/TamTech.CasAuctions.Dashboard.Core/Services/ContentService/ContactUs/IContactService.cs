using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContactUs.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContactUs
{
    public interface IContactService
    {

        Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model);

        Task<IRequestProviderResult<ContactDto>> GetByIdAndSetStatusAsync(Guid id, string lang);
        Task<IRequestProviderResult<ContactDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang);

        Task<IRequestProviderResult<PagedResultModel<List<ContactDto>>>> GetExceptSoftDeletedAsync(DTFilter model);
        
        Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model);

        Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id);
    }
}
