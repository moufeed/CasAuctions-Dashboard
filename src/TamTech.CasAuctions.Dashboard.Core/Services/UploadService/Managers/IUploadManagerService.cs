using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload.FileTypes;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload.Models; 

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Upload
{
    public interface IUploadManagerService 
    {
        Task<IRequestProviderResult<UploadModelResult>> UploadListFilesAsync(List<UploadFileModel> files);

        Task<IRequestProviderResult<UploadedFileURL>> UploadFileAsync(UploadFileInfo file, FileTypesEnum type, object id =  null);

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(Dictionary<string, FileTypesEnum> urlImgs);

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model);
    }
}
