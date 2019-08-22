using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pos.Settings
{
    public class PosAdminApiSettings : BaseAPISettings, IPosAdminApiSettings
    {
        public PosAdminApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string SoftDeleteEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        public string GetPOSActionsEndpoint => $"{_AdminPath}/GetPOSActionsAsync";

        public string SetActionEndpoint => $"{_AdminPath}/SetActionAsync";

        public string PublishEndpoint => $"{_AdminPath}/PublishAsync";

        public string GetStatusHistoriesListEndpoint => $"{_AdminPath}/GetStatusHistoriesListAsync";
    }
}
