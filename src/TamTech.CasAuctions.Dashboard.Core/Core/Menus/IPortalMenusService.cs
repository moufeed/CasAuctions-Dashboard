using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Menus.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Menus
{
    public interface IPortalMenusService
    {
        Task<IRequestProviderResult<MenuDto>> GetNavbarMenuAsync();
    }
}
