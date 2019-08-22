using Microsoft.AspNetCore.Authorization;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Authorizations
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public PermissionAuthorizationRequirement(string[] permissions)
        {
            Permissions = permissions;
        }

        public string[] Permissions { get; private set; }
    }
}
