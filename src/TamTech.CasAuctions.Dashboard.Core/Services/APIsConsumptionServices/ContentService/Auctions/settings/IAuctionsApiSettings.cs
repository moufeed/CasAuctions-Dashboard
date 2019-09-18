using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.Auctions.settings
{
    public interface IAuctionsApiSettings
    {
        string GetALlAuctionsEndpoint { get; }
        string GetAuctionByIdEndpoint { get; }
        string GetStatusListEndpoint { get; }
    }
}
