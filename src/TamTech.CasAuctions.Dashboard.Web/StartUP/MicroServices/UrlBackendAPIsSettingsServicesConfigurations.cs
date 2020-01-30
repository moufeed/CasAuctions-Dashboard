using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Attributes.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Biography.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Contact.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.Auctions.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.DirectSellItems.settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService.SellerRequests.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Menus.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pages.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Regions.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Sectors.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Settings.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Sliders.Settings;    
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Status.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Types.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Values.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Vendor.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.TelemetryAnalyticService.settings;
using TamTech.CasAuctions.Dashboard.SDK.Models.Settings;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP.MicroServices
{
    public static class BackendAPIsSettingsConfigurations
    {
        public static void MicroServices_AddBackendAPIsSettingsConfigurations(this IServiceCollection services, IConfiguration configuration)
        {



          
            services.AddSingleton((serviceExtension) =>
            {
                return configuration.GetSection(AppSettings.BackendAPIsSettings)
                                                                  .Get<BackendAPIsSettings>();
            });

            services.AddSingleton<ITelemetryApiSettings>((serviceExtension) =>
            {
                ApplicationInsightsSettings settings = configuration.GetSection(AppSettings.ApplicationInsights)
                                                                  .Get<ApplicationInsightsSettings>(); ;
                return new  TelemetryApiSettings(settings );
            });


            #region CAS Auctions

            services.AddScoped<IRequestApiEndpoints, RequestApiEndpoints>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new RequestApiEndpoints(settings);
            });

            services.AddScoped<IAuctionsApiSettings, AuctionApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new AuctionApiSettings(settings);
            });


            services.AddScoped<IDsItemsApiSettings, DsItemsApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new DsItemsApiSettings(settings);
            });

            services.AddScoped<TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Statistics.Settings.IStatisticsApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Statistics.Settings.StatisticsApiSettings(settings, BaseAPISettings.StatisticsController);
            });

            #endregion





         

      

            services.AddScoped<IContactUsTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new TypeApiSettings(settings, BaseAPISettings.CUTypesController);
            });

            services.AddScoped<IPOSTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new TypeApiSettings(settings, BaseAPISettings.POSTypesController);
            });

            services.AddScoped<IPOSSectorApiSettings, SectorApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new SectorApiSettings(settings, BaseAPISettings.POSSectorsController);
            });

            services.AddScoped<IPOSAttributeApiSettings, AttributeApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new AttributeApiSettings(settings, BaseAPISettings.POSAttributesController);
            });

            services.AddScoped<IPOSValueApiSettings, ValueApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new ValueApiSettings(settings, BaseAPISettings.POSValuesController);
           });

            services.AddScoped<IContactUsRegionApiSettings, RegionApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new RegionApiSettings(settings, BaseAPISettings.CURegionsController);
           });


            services.AddScoped<IPosAdminApiSettings, PosAdminApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new PosAdminApiSettings(settings, BaseAPISettings.POSController);
            });


            services.AddScoped<IPosApiSettings, PosApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new PosApiSettings(settings, BaseAPISettings.POSofVendorController);
            });


            services.AddScoped<IDirectoryApiSettings, DirectoryApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new DirectoryApiSettings(settings, BaseAPISettings.DirectoryController);
            });


            services.AddScoped<IContactUsApiSettings, ContactUsApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new ContactUsApiSettings(settings, BaseAPISettings.ContactUsController);
            });


            services.AddScoped<IVendorAdminApiSettings, VendorAdminApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new VendorAdminApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IVendorApiSettings, VendorApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new VendorApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IStatisticsApiSettings, StatisticsApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new StatisticsApiSettings(settings, BaseAPISettings.StatisticsController);
            });


            services.AddScoped<ICCUApiSettings, CCUServiceSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new CCUServiceSettings(settings, BaseAPISettings.COmmonContentUtilitiesController);
            });


            services.AddScoped<IPosStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.POSStatus);
            });

            services.AddScoped<IVendorStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.VendorStatus);
            });

            services.AddScoped<IContactUsStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.CSStatus);
            });

            services.AddScoped<IBiographyApiSettings, BiographyApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new BiographyApiSettings(settings, BaseAPISettings.BiographiesController);
            });

            services.AddScoped<ISettingsApiSettings, SettingsApiSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                return new SettingsApiSettings(settings, BaseAPISettings.SettingsController);
            });

            services.AddScoped<IMenuApiSettings, MenuApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new MenuApiSettings(settings, BaseAPISettings.MenusController);
           });

            services.AddScoped<IMenuItemApiSettings, MenuItemApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new MenuItemApiSettings(settings, BaseAPISettings.MenuItemsController);
           });


            services.AddScoped<ISliderApiSettings, SliderApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new SliderApiSettings(settings, BaseAPISettings.SlidersController);
           });

            services.AddScoped<ISliderItemApiSettings, SliderItemApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new SliderItemApiSettings(settings, BaseAPISettings.SliderItemsController);
           });

            services.AddScoped<IPagesApiSettings, PagesApiSettings>((serviceExtension) =>
           {
               BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
               return new PagesApiSettings(settings, BaseAPISettings.PagesController);
           });

            services.AddScoped<IIdentityBackendSettings>((serviceExtension) =>
            {
                BackendAPIsSettings settings = serviceExtension.GetRequiredService<BackendAPIsSettings>();
                //BackendApiSettingsModel settings = new BackendApiSettingsModel
                //{
                //    Url = settingsService.IDS4Url, 
                //    ClientId = settingsService.ClientId, 
                //    ClientSecret = settingsService.ClientSecret, 
                //    ClientScope = settingsService.ClientScope, 
                //};      
                return new IdentityBackendSettings(settings);
            });     
        }
    }
}
