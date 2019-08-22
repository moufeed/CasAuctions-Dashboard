using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings
{
    public class CCUServiceSettings : BaseAPISettings , ICCUApiSettings
    {
        public CCUServiceSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetNumericalStatisticsEndpoint => $"{_AdminPath}/GetNumericalStatisticsAsync";
        public string GetListsModulesForMenuItemsTypesEndpoint => $"{_AdminPath}/GetListsModulesForMenuItemsTypesAsync";
    }
}
