using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Slugs;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Directory.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Directory
{
   public interface IDirectoryServices
    {

        Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model);

        Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang);
        Task<IRequestProviderResult<List<SlugModel>>> GetAllPublishedSlugsAsync();
    }
}
