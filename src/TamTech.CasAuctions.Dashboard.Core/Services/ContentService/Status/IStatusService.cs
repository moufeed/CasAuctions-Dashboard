using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Status.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Status
{
    public interface IStatusService
    {
        #region Public  Services 

        #endregion


        #region Services Manager

        #region Get

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang);


        Task<IRequestProviderResult<List<StatusDto>>> GetAllAsync(string lang); 
        #endregion


        #region   Create / Edit / Delete


        #endregion



        #endregion
    }
}
