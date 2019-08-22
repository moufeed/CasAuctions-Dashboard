using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Biographies.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Biographies
{
    public interface IBiographyService
    {
        Task<IRequestProviderResult<List<BiographyDto>>> GetByGroupIdAsync(int groupId, string lang);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model);

        Task<IRequestProviderResult<List<BiographyDto>>> GetAllAsync();
    }
}

