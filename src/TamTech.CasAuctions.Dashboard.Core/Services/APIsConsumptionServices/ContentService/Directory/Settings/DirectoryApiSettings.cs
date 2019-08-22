using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Directory.Settings
{
    public class DirectoryApiSettings : BaseAPISettings, IDirectoryApiSettings
    {
        public DirectoryApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetPublishedBySlugEndPoint => $"{_PortlPath}/GetPublishedBySlugAsync";

        public string FindEndPoint =>  $"{_PortlPath}/FindAsync";

        public string GetCountOfPublishedEndPoint =>  $"{_PortlPath}/GetCountOfPublishedAsync";

        public string GetAllPublishedSlugsEndPoint => $"{_PortlPath}/GetAllPublishedSlugsAsync";
    }
}
