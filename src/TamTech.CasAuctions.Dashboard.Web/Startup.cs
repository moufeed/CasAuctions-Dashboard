using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;      
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;         
using TamTech.CasAuctions.Dashboard.SDK.Core.Cultures;
using TamTech.CasAuctions.Dashboard.Web.StartUP;                      
using TamTech.CasAuctions.Dashboard.Web.StartUP.MicroServices;                      

namespace TamTech.CasAuctions.Dashboard.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;   
        private readonly IHostingEnvironment _env;   

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {

             _configuration = configuration;
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

          //  int durationOfLogin = _configuration.Get( )  

            services.AddHealthChecksConfigurations(_configuration);

            services.AddLocalizationConfigurations();

            services.AddMVCConfigurations();

            services.AddCompressionConfigurations();

            services.AddFiltersConfigurations();

           services.AddAuthenticationConfigurations(_configuration);   
           services.AddAuthorizationConfigurations(_configuration, _env);   

            services.AddCommonServicesConfigurations(_configuration);           

        //    services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(_configuration);

            services.AddBusinessLogicDirectBackendServicesConfigurations();

            services.MicroServices_AddProvidersServicesConfigurations();

            services.MicroServices_AddBackendAPIsSettingsConfigurations(_configuration);

            services.AddBLLAPIsServicesConfigurations();

          //  services.AddEFileIdentityProviderConfigurations(_configuration);

            services.AddFluentValidationConfigurations();

         //   services.AddMCIServicesConfigurations(_configuration);

         //   services.AddMCIAPISimulatorConfigurations(_configuration);
          

            //services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {    
            app.UseLogsConfigurations(_configuration, loggerFactory);    
            app.UseHealthChecksConfigurations(_configuration);    
            string cachePeriod;
            if (env.IsDevelopment() || env.EnvironmentName.Equals("local"))
            {
                // app.UseBrowserLink(); from web admin panel
                app.UseDeveloperExceptionPage();
                cachePeriod = "600";

            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseHsts();
                cachePeriod = "86400";
            }
                
            app.UseXSSProtection(env, _configuration);    
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
            app.UseResponseCompression();
        //    app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.InitializeMapper();    
            app.UseSettings(env, _configuration);
            app.UseAuthentication();  
            app.UseResponseCompression();    
            app.UseMvcAndRoute(_configuration, new CultureManager().LocalizationOptions);
            app.UseCookiePolicy();

        }
    }
}    