using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload.Models;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Upload
{
    public interface IUploadService
    {
        Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel Files );

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model);

    }
}
