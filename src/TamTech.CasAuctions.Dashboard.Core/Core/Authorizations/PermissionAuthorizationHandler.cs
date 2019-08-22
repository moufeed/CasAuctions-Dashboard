using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Core.Extensions;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Authorizations
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
           
            if (!context.User.Identity.IsAuthenticated || !context.User.HasClaim(c => c.Type == CommonConstants.RoleClaimName))
            {
                return Task.FromResult(0);
            }

            string userPermission = context.User.Identity.GetPermission();
            if (requirement.Permissions.Contains(userPermission, StringComparer.InvariantCultureIgnoreCase))
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
