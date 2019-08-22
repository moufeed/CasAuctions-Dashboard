using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Extensions;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests; 

namespace TamTech.CasAuctions.Dashboard.Web.StartUP.MicroServices
{ 
     public static class ProvidersServicesConfigurations
    {
        public static void MicroServices_AddProvidersServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IRequestProvider>((serviceExtension) =>  
            {        
                IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();        
                string token = GetToken(httpContextAccessor.HttpContext).Result;
               // string token = GetToken(httpContextAccessor.HttpContext);// / httpContextAccessor.HttpContext.User.Identity.GetAccessToken();
                return new RequestProvider(token);
            });

            //  string  GetToken(HttpContext httpContext)
            //  {
            //      if (httpContext == null) return null;
            //   var token =  httpContext.User.Identity.GetAccessToken();
            //    return token;
            //}
            async Task<string> GetToken(HttpContext httpContext)
            {
                return await httpContext.GetTokenAsync("access_token");
            }
        }
    }
}
