using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService.SellerRequests.Settings
{
    public interface IRequestApiEndpoints
    {
        string RequestsListEndpoint { get; }

        string RequestDetialsEndpoint { get; }

        string ProcessActionsEndpoint { get; }

        string TakeActionEndpoint { get; }

        string StatusListEndpoint { get; }

    

    }
}


 