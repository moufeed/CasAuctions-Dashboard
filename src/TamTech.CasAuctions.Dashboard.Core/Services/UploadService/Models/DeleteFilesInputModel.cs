using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.Upload.Models
{
    public class DeleteFilesInputModel
    {
        public List<DeleteFileInputModel> DeletedFiles { get; set; }
    }

    public class DeleteFileInputModel
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string FilePath { get; set; }
    }
}
