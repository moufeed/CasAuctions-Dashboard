using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;  
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Auth.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Identity
{
    public  interface IAuthService
    {
        Task<IRequestProviderResult<bool>> ValidateVendorCredentialAsync(SignupByName model, string secretKey, string secretValue);

        Task<IRequestProviderResult<bool>> ValidatePOSAdminCredentialAsync(SignupByName model, string secretKey, string secretValue);
     
        Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email);

        Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword model);

        Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model);
                                                                                        
    }
}
