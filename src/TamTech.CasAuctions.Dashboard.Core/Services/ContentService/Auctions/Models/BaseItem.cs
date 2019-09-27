using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Core.Helpers;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions.Models
{
   

    public class ItemImageDto
    {
        public Guid Id { get; set; }

        public string Original { get; set; }

        public string Thumb { get; set; }
    }

    public class BaseItem
    {
        public Guid SellerId { get; set; }

        public Guid? BuyerId { get; set; }

        public int StatusId { get; set; }

        public double StartPrice { get; set; }

        public double PurchasePrice { get; set; }

        public UserProfileDto SellerProfile { get; set; }
        public UserProfileDto BuyerProfile { get; set; }

        [JsonConverter(typeof(CustomJDateTimeConverter))]
        public DateTime EndDate { get; set; }

        #region Item

        public int ItemCategoryId { get; set; }

        public string ItemTitle { get; set; }

        public string ItemDescription { get; set; }

        public List<ItemImageDto> ItemImages { get; set; }

        #endregion 


        #region Currency 

        public string CurrencyGrade { get; set; }

        public bool CurrencyEPQ { get; set; }

        public string CurrencyDenomination { get; set; }

        public string CurrencyCountry { get; set; }

        public string CurrencyYear { get; set; }

        public string CurrencyPickNumber { get; set; }
        #endregion

        [JsonProperty("id")]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifierId { get; set; }

        public int DisplayOrder { get; set; }
    }


    
}
