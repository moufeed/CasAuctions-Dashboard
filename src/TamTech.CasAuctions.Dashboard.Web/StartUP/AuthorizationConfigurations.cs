using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;    
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Policies;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static partial class AuthorizationConfigurations
    {

        public static void AddAuthorizationConfigurations(this IServiceCollection services, IConfiguration Configuration, IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath).AddJsonFile("Identity.Policies.json", optional: true, reloadOnChange: true);

            var settings = configBuilder.Build().Get<IdentityServiceSettings>();
            PolicyConstants.Policies = settings.Policies;

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
                
                options.AddPolicy(PolicyConstants.ConfigurationsAdmin, adminClaimPolicy);
                options.AddPolicy(PolicyConstants.BiographiesAdmin, adminClaimPolicy);

                // CAS Auctions Policies        
                options.AddPolicy(PolicyConstants.AdminAccess, new AuthorizationPolicyBuilder().RequireClaim("role", settings.GetRolesByPolicy(PolicyConstants.AdminAccess)).Build());
                options.AddPolicy(PolicyConstants.DashboardAdmin, new AuthorizationPolicyBuilder().RequireClaim("role", settings.GetRolesByPolicy(PolicyConstants.DashboardAdmin)).Build());
                options.AddPolicy(PolicyConstants.AuctionsAdmin, new AuthorizationPolicyBuilder().RequireClaim("role", settings.GetRolesByPolicy(PolicyConstants.AuctionsAdmin)).Build());
                options.AddPolicy(PolicyConstants.DsItemsAdmin, new AuthorizationPolicyBuilder().RequireClaim("role", settings.GetRolesByPolicy(PolicyConstants.DsItemsAdmin)).Build());
                options.AddPolicy(PolicyConstants.SellerRequestsAdmin, new AuthorizationPolicyBuilder().RequireClaim("role", settings.GetRolesByPolicy(PolicyConstants.SellerRequestsAdmin)).Build());



            });

        }
    }
}
