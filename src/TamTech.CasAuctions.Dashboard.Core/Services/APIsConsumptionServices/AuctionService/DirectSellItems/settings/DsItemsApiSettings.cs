using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.DirectSellItems.settings
{
    public class DsItemsApiSettings : IDsItemsApiSettings
    {
        private string _AuctionUrl;

        public DsItemsApiSettings(BackendAPIsSettings settings) 
        {
            _AuctionUrl = settings.AuctionApiUrl;
        }


        public string allItemsEndpoint => $"{_AuctionUrl}/api/Admin/DsItem";

        public string itemByIdEndpoint => $"{_AuctionUrl}/api/Admin/DsItem/Detailed";

        public string StatusListEndpoint => $"{_AuctionUrl}/api/Admin/DsItem/Status";

        public string CategoriesListEndpoint => $"{_AuctionUrl}/api/Admin/DsItem/Categories";

        public string TakeActionEndpoint => $"{_AuctionUrl}/api/Admin/DsItem/TakeAction";
    }
}
