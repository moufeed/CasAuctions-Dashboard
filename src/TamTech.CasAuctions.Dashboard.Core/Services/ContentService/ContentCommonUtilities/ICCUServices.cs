using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContentCommonUtilities.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContentCommonUtilities
{
   public interface ICCUServices
    {
         

        Task< IRequestProviderResult<Dictionary<string, NumericalStatisticsDto>>> GetNumericalStatisticsAsync(List<string> types, string lang);


        Task<IRequestProviderResult<Dictionary<string, Dictionary<string, string>>>> GetListsModulesForMenuItemsTypesAsync(List<string> model, string lang);

    }
}
