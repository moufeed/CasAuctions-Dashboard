using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pos.Settings
{
    public class PosApiSettings : BaseAPISettings, IPosApiSettings
    {
        public PosApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string CreateEndpoint => $"{_PortlPath}/CreateAsync";

        public string VerifySlugUniqueEndpoint => $"{_PortlPath}/VerifySlugUniqueAsync";

        public string VerifySlugUniqueByNameEndpoint => $"{_PortlPath}/VerifySlugUniqueByNameAsync";

        public string GetPOSsForCurrentUserEndpoint => $"{_PortlPath}/GetPOSsForCurrentUserAsync";

        public string GetByIdAndCurrentUserExceptSoftDeletedEndpoint => $"{_PortlPath}/GetByIdAndCurrentUserExceptSoftDeletedAsync";

        public string EditEndpoint => $"{_PortlPath}/EditAsync";

        public string SoftDeleteByCurrentUserEndpoint => $"{_PortlPath}/SoftDeleteByCurrentUserAsync";
    }
}
