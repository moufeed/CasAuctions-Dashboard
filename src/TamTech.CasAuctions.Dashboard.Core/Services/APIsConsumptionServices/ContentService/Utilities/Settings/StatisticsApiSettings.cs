using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings
{
    public class StatisticsApiSettings : BaseAPISettings, IStatisticsApiSettings
    {
        public StatisticsApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetPOSNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByStatusAsync";

        public string GetPOSNumericalStatisticsBySectorEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsBySectorAsync";

        public string GetPOSNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByTypeAsync";

        public string GetVendorNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetVendorNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByTypeAsync";
    }
}
