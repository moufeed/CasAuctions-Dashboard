using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Attributes.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Attributes
{
    public  interface IAttributeService
    {

        #region Public  Attributes

        Task<IRequestProviderResult<AttributeDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(bool sortManually = true);

        Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion

        #region Attributes Manager

        #region Get

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang);

        Task<IRequestProviderResult<AttributeDto>> GetByIdAsync(int id, string lang);

        Task<IRequestProviderResult<List<AttributeDto>>> GetAllAsync(string lang);

        Task<IRequestProviderResult<PagedResultModel<List<AttributeDto>>>> GetAsync(DTFilter model);

        #endregion

        #region  Publish / Create / Edit / Delete 



        Task<IRequestProviderResult<int>> CreateAsync(CreateAttributeModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateAttributeModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishLookupModel model);


        #endregion





        #endregion
    }
}
