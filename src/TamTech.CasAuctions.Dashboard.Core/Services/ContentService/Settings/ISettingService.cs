using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Settings.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Settings
{
    public interface ISettingService
    {

        Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdsAsync(List<int> groupIds);

        Task<IRequestProviderResult<List<SettingDto>>> GetListByKeysAsync(List<string> keys);

        Task<IRequestProviderResult<List<SettingDto>>> GetListByIdsAsync(List<int> ids);

        Task<IRequestProviderResult<List<SettingDto>>> GetListBySharedKeyAsync(string sharedkey);

        Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdAsync(int groupId);

        Task<IRequestProviderResult<SettingDto>> GetByIdAsync(int id);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdsAsync(List<int> groupIds);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByKeysAsync(List<string> keys);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByIdsAsync(List<int> ids);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeyAsync(string sharedkey);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeysAsync(List<string> sharedkeys);

        Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdAsync(int groupId);

        Task<IRequestProviderResult<SettingDto>> GetEnabledByIdAsync(int id);

    }
}
