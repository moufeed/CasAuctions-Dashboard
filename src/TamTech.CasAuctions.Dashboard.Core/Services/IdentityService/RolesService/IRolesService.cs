using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models.Params;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Identity
{
    public interface IRolesService
    {
         

        Task<IEnumerable<RoleModel>> GetAllAsync();


        Task<IEnumerable<RoleModel>> GetUserRolesAsync(string name);

    }
}
