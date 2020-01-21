using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions.Models
{
    public class AuctionParticipant
    {
        public Guid ParticipantId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Photo { get; set; }

        public string FullName { get; set; }
        

    }
}
