using Microsoft.Extensions.DependencyInjection;
using TamTech.CasAuctions.Dashboard.SDK.Core.Filters;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class FiltersConfigurations
    {
        public static void AddFiltersConfigurations(this IServiceCollection services)
        {

            services.AddScoped<UserContextUpdated>();     
            services.AddTransient<AdminFilter>();
            //  services.AddTransient<MenuFilter>(); 
        }
    }
}
