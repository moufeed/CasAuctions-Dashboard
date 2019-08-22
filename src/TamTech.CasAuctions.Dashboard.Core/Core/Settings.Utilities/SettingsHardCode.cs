using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;          
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Settings;    
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Admin.Menus;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Settings.Utilities
{
    public class SettingsHelper 
    {
        public static string AppVersion;
    }
        public class SettingsHardCode : ISettingsManager
    {


        #region Props  
        private readonly ISettingService _settingService;
                              
        #endregion


        #region Ctors
        public SettingsHardCode(ISettingService settingService)
        {
            _settingService = settingService;

        }
        #endregion




        #region Utilities
        public async Task PrepareCashedSettingsAsync()
        {
            if (string.IsNullOrWhiteSpace(SettingsHelper.AppVersion)  )
            {
                SettingsHelper.AppVersion = "0.1"; 
                
            }
        }



        public async Task<string> GetVersionAsync()
        {      
            return "0.1";
        }

      

        public async Task<string> GetURlAsync()
        {
            return "https://localhost:44377";
        }


        public async Task<bool> DisplayTokenInWebViewAsync()
        {
             return false;
        }

        public async Task<bool> CheckCachedNavbarAsync()
        {
            return false;
        }

      
        public async Task<List<string>> GetMenuItemsTypesAsync()
        {
            return null;
        }
        public async Task<List<string>> GetNumericalStatisticsNamesAsync()
        {
            return null;
        }
        public async Task<List<StaticMenuItem>> GetStaticPagesAsync()
        {
            return null;
        }

        #endregion
    }
}
