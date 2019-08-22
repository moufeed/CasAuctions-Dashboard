using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Auth.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Settings;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService
{
    public class AuthService : BaseAPIService, IAuthService
    {                                      
        private readonly IIdentityBackendSettings _backendSettings;

        public AuthService(IRequestProvider requestProvider,      IIdentityBackendSettings backendSettings  )    :base(requestProvider)   
        {              
            _backendSettings = backendSettings;
        }



        public async Task<IRequestProviderResult<bool>> ValidateVendorCredentialAsync(SignupByName model, string secretKey, string secretValue)
        {   
            return await ReqProvider.PostAsync<bool, SignupByName>(_backendSettings.ValidateVendorCredentialEndpoint, model,
                new Dictionary<string, string> { { secretKey, secretValue } });
        }    

        public async Task<IRequestProviderResult<bool>> ValidatePOSAdminCredentialAsync(SignupByName model, string secretKey, string secretValue)
        {   
            return await ReqProvider.PostAsync<bool, SignupByName>(_backendSettings.ValidatePOSAdminCredentialEndpoint, model,
                new Dictionary<string, string> { { secretKey, secretValue } });
        }   

        public Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model)
        {
            throw new NotImplementedException();
        }   
        
        public Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email)
        {
            throw new NotImplementedException();
        }  

        public Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword password)
        {
            throw new NotImplementedException();
        }

       
    }
}
