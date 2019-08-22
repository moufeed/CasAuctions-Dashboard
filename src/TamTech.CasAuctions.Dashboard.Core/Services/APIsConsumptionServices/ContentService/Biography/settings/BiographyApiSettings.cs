using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Biography.settings
{
    public class BiographyApiSettings : BaseAPISettings, IBiographyApiSettings
    {
        public BiographyApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetByGroupIdEndpoint => $"{_AdminPath}/GetByGroupIdAsync";

        public string EditEndpoint => $"{_AdminPath}/EditAsync";

        public string GetAllEndpoint => $"{_PortlPath}/GetAllAsync";
    }
}
