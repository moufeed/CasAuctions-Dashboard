using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions.settings
{
    public class AuctionApiSettings : IAuctionsApiSettings
    {
        private string _AuctionUrl;

        public AuctionApiSettings(BackendAPIsSettings settings) 
        {
            _AuctionUrl = settings.AuctionApiUrl;
        }

        public string GetALlAuctionsEndpoint => $"{_AuctionUrl}/api/Admin/Auction";

        public string GetAuctionByIdEndpoint => $"{_AuctionUrl}/api/Admin/Auction/Detailed";

        public string GetStatusListEndpoint => $"{_AuctionUrl}/api/Admin/Auction/Status";
        public string GetCategoriesListEndpoint => $"{_AuctionUrl}/api/Admin/Auction/Categories";
        public string GetTypesListEndpoint => $"{_AuctionUrl}/api/Admin/Auction/Types";
        public string TakeActionEndpoint => $"{_AuctionUrl}/api/Admin/Auction/TakeAction";
    }
}
