using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Biography;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Biographies
{
    public interface IBiographiesManager
    {
        Task<BiographyInfoVm> GetInfoAsync();

        Task ReloadInfoAsync();
    }
}
