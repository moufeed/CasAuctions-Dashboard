using Microsoft.Extensions.DependencyInjection;
using FluentValidation;  
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Portal.Pos;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class FluentValidationConfigurations
    {
        public static void AddFluentValidationConfigurations(this IServiceCollection services)
        {

            services.AddTransient<IValidator<PosFormVm>, PosFormVmValidator>();
        }

    }
}
