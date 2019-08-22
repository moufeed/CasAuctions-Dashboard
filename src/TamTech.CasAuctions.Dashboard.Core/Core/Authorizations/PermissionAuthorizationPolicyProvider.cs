using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Core.Extensions;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Authorizations
{
    public class PermissionAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider defaultPolicyProvider { get; }
        public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            defaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return defaultPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            string[] subStringPolicy = policyName.Split('.');
            if (subStringPolicy.Length > 1 && subStringPolicy[0].Equals("_Permission", StringComparison.OrdinalIgnoreCase))
            {
                string[] permissions  = subStringPolicy[1].Split('.');
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PermissionAuthorizationRequirement(permissions));
                return Task.FromResult(policy.Build());
            }

            return defaultPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
