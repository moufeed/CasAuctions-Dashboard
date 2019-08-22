using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TamTech.CasAuctions.Dashboard.SDK.Core.Biographies;
using TamTech.CasAuctions.Dashboard.SDK.Core.Settings.Utilities;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Core.Helpers.Converters;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Menus; 
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload.FileTypes;
using TamTech.CasAuctions.Dashboard.Web.Services.ContentService.Menus.PublicService;
using TamTech.CasAuctions.Dashboard.SDK.Core.Validations;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class CommonServicesConfigurations
    {
        public static void AddCommonServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTelemetryConfigurations(configuration);    
            services.AddScoped<IStringConverters, StringConverters>();
            services.AddScoped<IExpressionValidation, ExpressionValidation>();    
      
            //services.AddScoped<IUploadManagerService, UploadManagerService>((serviceExtension) =>
            //{
            //    List<FileTypesSettingsModel> Settings = configuration.GetSection(AppSettings.WebApplicationSettings)
            //        .GetSection(AppSettings.App_FilesTypesSettings)
            //        .GetSection(AppSettings.FilesTypes)
            //        .Get<List<FileTypesSettingsModel>>();
            //    var uploadService = serviceExtension.GetRequiredService<IUploadService>();
            //    return new UploadManagerService(Settings, uploadService);
            //});



            //bool CacheMenus = configuration.GetSection(AppSettings.WebApplicationSettings)
            //    .GetSection(AppSettings.App_CacheMenus)
            //    .Get<bool>();
            //if (CacheMenus)
            //{
            //    services.AddScoped<IPortalMenusService, CashedMenusService>();
            //}
            //else
            //{
            //    services.AddScoped<IPortalMenusService, WebPublicMenusService>();
            //}

            services.AddScoped<IBiographiesManager, StatisCashedBiographies>();
            services.AddScoped<ISettingsManager, SettingsHardCode>();

        }
    }
}
