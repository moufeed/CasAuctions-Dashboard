using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Common;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions.Models
{
    public class AuctionDetails : Auction
    {
        public List<AuctionParticipant> Participants { get; set; }

      //  public List<AuctionOutbid> Outbids { get; set; }
        
           private List<AuctionOutbid> outbids;
         public List<AuctionOutbid> Outbids
         {
             get
             {
                 return outbids;
             }
             set
             {
                 outbids = value?.OrderByDescending(o => o.Price).ThenBy(o => o.CreatedDate).ToList();
             }
         }
       
        public List<StatusHistoryDto> StepsHistory { get; set; }


        public List<ProcessActionModel> ProcessActions { get; set; }
    }
}
