using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
   public class Auction : BaseAuction
    {
        public string CategoryName { get; set; }

        public string TypeName { get; set; }

        public string StatusName { get; set; }
    }
}
