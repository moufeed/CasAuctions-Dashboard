using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.DirectSellItems.Models
{
    public class DsItem : BaseItem
    {
        public DateTime PurchaseDate { get; set; }

        public string CategoryName { get; set; }

        public string StatusName { get; set; }
    }
}
