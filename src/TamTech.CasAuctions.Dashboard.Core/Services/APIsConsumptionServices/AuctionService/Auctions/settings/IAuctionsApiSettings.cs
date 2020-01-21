using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.AuctionService.Auctions.settings
{
    public interface IAuctionsApiSettings
    {
        string GetALlAuctionsEndpoint { get; }
        string GetAuctionByIdEndpoint { get; }
        string GetStatusListEndpoint { get; }
        string GetCategoriesListEndpoint { get; }
        string GetTypesListEndpoint { get; }
        string TakeActionEndpoint { get; }
    }
}
