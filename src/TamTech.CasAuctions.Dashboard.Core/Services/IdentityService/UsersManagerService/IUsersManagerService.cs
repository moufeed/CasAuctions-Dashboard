using System;
using System.Collections.Generic;
using System.Threading.Tasks;               
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models.Params;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Identity
{
    public interface IUsersManagerService
    {
        Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model);

        Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username);      

        Task<IRequestProviderResult<UserModel>> GetUserByIdAsync(string userId);      

        Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel data);  

        Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model);

        Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model);    

        Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model);
    
        Task<IRequestProviderResult<bool>> AddUserToRolesAsync(AddUserToRolesModel model);
    }
}
    