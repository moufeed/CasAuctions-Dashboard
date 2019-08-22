using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Enums;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Admin.Menus;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Settings.Utilities
{
    public interface ISettingsManager
    {        
        Task PrepareCashedSettingsAsync();
                                             
        Task<string> GetVersionAsync();          

        Task<string> GetURlAsync();       

        Task<bool> DisplayTokenInWebViewAsync();

        Task<bool> CheckCachedNavbarAsync();       

        Task<List<string>> GetMenuItemsTypesAsync();

        Task<List<string>> GetNumericalStatisticsNamesAsync();

        Task<List<StaticMenuItem>> GetStaticPagesAsync();

    }
}
