using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Sectors.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Sectors
{
    public interface ISectorServices
    {
        #region Public  Sectors // ----------------------------------------------------- 

        Task<IRequestProviderResult<SectorDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<List<SectorDto>>> GetPublishedListAsync(bool sortManually = true);

        Task<IRequestProviderResult<List<SectorDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion  // ------------------------------------------------------------


        #region Admin Services // ------------------------------------------------------------

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetSelectListAsync(string lang, bool isOfficial =true);

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang);

        Task<IRequestProviderResult<SectorDto>> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<IRequestProviderResult<List<SectorDto>>> GetAllExceptSoftDeletedAsync(string lang);

        Task<IRequestProviderResult<PagedResultModel<List<SectorDto>>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<IRequestProviderResult<int>> CreateAsync(CreateSectorModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateSectorModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishLookupModel model);

        #endregion  // ------------------------------------------------------------



    }
}
