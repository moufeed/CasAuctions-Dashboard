using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
    public class AuctionDetails : Auction
    {
        public List<AuctionParticipant> Participants { get; set; }

        public List<AuctionOutbid> Outbids { get; set; }

        public List<StatusHistory> StepsHistory { get; set; }


        public List<ProcessActionModel> ProcessActions { get; set; }
    }
}
