using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Settings.Settings
{
    public class SettingsApiSettings : BaseAPISettings, ISettingsApiSettings
    {
        public SettingsApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetByIdEndpoint => $"{_PortlPath}/GetByIdAsync";

        public string GetByKeyEndpoint => $"{_PortlPath}/GetByKeyAsync";

        public string GetByGroupIdEndpoint => $"{_PortlPath}/GetByGroupIdAsync";

        public string GetListBySharedKeyEndpoint => $"{_PortlPath}/GetListBySharedKeyAsync";

        public string GetListBySharedKeysEndpoint => $"{_PortlPath}/GetListBySharedKeysAsync";

        public string GetAllEndpoint => $"{_PortlPath}/GetAllAsync";

        public string GetByGroupIdsEndpoint => $"{_PortlPath}/GetByGroupIdsAsync";

        public string GetListByKeysEndpoint => $"{_PortlPath}/GetListByKeysAsync";

        public string GetListByIdsEndpoint => $"{_PortlPath}/GetListByIdsAsync";
    }
}
