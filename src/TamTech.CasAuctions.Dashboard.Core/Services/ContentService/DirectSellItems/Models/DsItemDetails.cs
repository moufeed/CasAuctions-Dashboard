using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.DirectSellItems.Models
{
    public class DsItemDetails : DsItem
    {
        public List<StatusHistoryDto> StepsHistory { get; set; }

        public List<ProcessActionModel> ProcessActions { get; set; }
    }
}
