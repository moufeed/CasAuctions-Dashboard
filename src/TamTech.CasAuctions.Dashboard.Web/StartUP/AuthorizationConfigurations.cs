using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static partial class AuthorizationConfigurations
    {

        public static void AddAuthorizationConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {
            //IdentityServiceConsumeSettings settings = Configuration.GetSection(AppSettings.MicroServicesSettings)
            //                                  .GetSection(AppSettings.MicroServices_IdentityService)
            //                                  .Get<IdentityServiceConsumeSettings>();
              
            var adminClaimPolicy = new AuthorizationPolicyBuilder().RequireClaim("role", "AuctionsSuperAdmin").Build();   
            services.AddMvcCore().AddAuthorization(options =>
            {
                options.AddPolicy(PolicyConstants.AuthenticatedUser, new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

                // Identity SDK Policies
                options.AddPolicy(PolicyConstants.IdentityUserAccess, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.IdentityManager, adminClaimPolicy);

                // Content SDK Policies                                 

                options.AddPolicy(PolicyConstants.MenusContentAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.SlidersContentAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.PagesContentAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.UsersAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.DashboardAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.AdminAccess, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.ConfigurationsAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.BiographiesAdmin, adminClaimPolicy);


              


            });

        }
    }
}
