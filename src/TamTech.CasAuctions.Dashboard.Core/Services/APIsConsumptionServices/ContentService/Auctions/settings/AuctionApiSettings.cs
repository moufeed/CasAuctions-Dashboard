using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions.settings
{
    public class AuctionApiSettings : BaseAPISettings, IAuctionsApiSettings
    {
        public AuctionApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetALlAuctionsEndpoint => $"{_AdminPath}/";

        public string GetAuctionByIdEndpoint => $"{_AdminPath}/";

        public string GetStatusListEndpoint => $"{_AdminPath}/";
    }
}
