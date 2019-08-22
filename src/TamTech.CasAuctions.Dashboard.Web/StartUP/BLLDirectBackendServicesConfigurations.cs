using Microsoft.Extensions.DependencyInjection; 
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class BLLDirectBackendServicesConfigurations
    {
        public static void AddBusinessLogicDirectBackendServicesConfigurations(this IServiceCollection services)
        {  
            #region Upload Service 

         //   services.AddTransient<IUploadService, TamTech.CasAuctions.Dashboard.Web.DirectBackendServices.UploadService.DirectFileStorageService>();

            #endregion
          


        }
    }
}
