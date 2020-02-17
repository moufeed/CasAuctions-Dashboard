using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.IdentityService.SellerRequests.Settings
{
   public class RequestApiEndpoints : IRequestApiEndpoints 
    {
        private string _identityServiceUrl;


        public RequestApiEndpoints(BackendAPIsSettings settings)
        {
            _identityServiceUrl = settings.IdentityApiUrl.TrimEnd('/');
        }

        public string RequestsListEndpoint => $"{_identityServiceUrl}/api/Admin/SellerRequest";

        public string RequestDetialsEndpoint => $"{_identityServiceUrl}/api/Admin/SellerRequest";

        public string ProcessActionsEndpoint => $"{_identityServiceUrl}/api/Admin/SellerRequest/ProcessActions";

        public string TakeActionEndpoint => $"{_identityServiceUrl}/api/Admin/SellerRequest/TakeAction";

        public string StatusListEndpoint => $"{_identityServiceUrl}/api/SellerRequest/Status/SelectList";

        public string PrivatePermissionEndpoint => $"{_identityServiceUrl}/api/Admin/User/AddPrivatePermission";

    }
}
