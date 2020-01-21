using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Core.Helpers;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Auctions.Models
{
    public class BaseAuction : BaseItem
    {
        #region Custom

        public int OutbidsCount { get; set; }

        public int ParticipantsCount { get; set; }

        #endregion

        public Guid? BuyerOutbidId { get; set; }

        [JsonConverter(typeof(CustomJDateTimeConverter))]
        public DateTime StartDate { get; set; }


        [JsonConverter(typeof(CustomJDateTimeConverter))]
        public DateTime ActualEndDate { get; set; }

        public int ExtendedTime { get; set; }

        public int TypeId { get; set; }

        public double? LimitPrice { get; set; }

        public int IncrementTypeId { get; set; }

        public ICollection<AuctionIncrementAmountModel> IncrementAmounts { get; set; }

        public int? MaximumParticipants { get; set; }

        public bool DisplayBuyer { get; set; }
    }
}
