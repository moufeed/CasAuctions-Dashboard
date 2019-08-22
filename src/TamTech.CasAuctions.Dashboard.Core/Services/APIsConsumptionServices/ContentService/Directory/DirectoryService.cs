using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Slugs;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Directory;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Directory.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.POSs.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Directory
{
    public class DirectoryService : BaseAPIService, IDirectoryServices
    {

        #region prop                    
        private readonly IDirectoryApiSettings  _apiSettings;
        #endregion

        #region ctor
        public DirectoryService(IRequestProvider requestProvider, IDirectoryApiSettings apiSettings) : base(requestProvider)
        {             
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<PosDto>>, PosFilters>(_apiSettings.FindEndPoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SlugModel>>> GetAllPublishedSlugsAsync()
        {
            return await ReqProvider.GetAsync<List<SlugModel>>(_apiSettings.GetAllPublishedSlugsEndPoint);
        }

        public async Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang)
        {
            return await ReqProvider.GetAsync<int, List<object>>(_apiSettings.GetCountOfPublishedEndPoint, new List<object> {  lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug)
        {
            return await ReqProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetPublishedBySlugEndPoint, new List<object> { slug }, PassParamsBy.Route);
        }
    }
}
