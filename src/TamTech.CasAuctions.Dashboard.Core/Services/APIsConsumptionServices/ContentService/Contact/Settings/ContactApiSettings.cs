using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Contact.Settings
{
    public class ContactUsApiSettings : BaseAPISettings, IContactUsApiSettings
    {
        public ContactUsApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string CreateEndpoint => $"{_PortlPath}/CreateAsync";

        public string ReplayEndpoint => $"{_AdminPath}/ReplayAsync";

        public string RemoveReplayEndpoint => $"{_AdminPath}/RemoveReplayAsync";

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string GetByIdAndSetStatusEndpoint => $"{_AdminPath}/GetByIdAndSetStatusAsync";
    }
}

 