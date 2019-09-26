using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
    public class StatusHistory
    {
        public int CurrentStatusId { get; set; }

        public int PreviousStatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? UserId { get; set; }

        public string Notes { get; set; }

        public string PreviousStatusName { get; set; }
        public string CurrentStatusName { get; set; }
    }
}
