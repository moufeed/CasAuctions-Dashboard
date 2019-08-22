using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Pages.Models
{
    public class PagesList
    {
        public List<PageDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
