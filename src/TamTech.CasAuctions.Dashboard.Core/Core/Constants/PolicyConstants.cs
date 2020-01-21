

using System.Collections.Generic;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Policies;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Constants
{      /// <summary>
       /// General roles :
       /// Super admin can give the super admin role to other users
       /// Author is the user who write content to be reviewed
       /// Editor is the user who publish/unpublish the content to be available for access
       /// ContentAdmin can do crud operations
       /// </summary>
    public static class PolicyConstants
    {

        public static List<PolicySetting> Policies;
        #region CAS Auctions

        public const string AuctionsAdmin = "AuctionsAdmin";
        public const string DsItemsAdmin = "DsItemsAdmin";
        public const string SellerRequestsAdmin = "SellerRequestsAdmin";



        #endregion


        public const string AuthenticatedUser = "AuthenticatedUser";  
       

        public const string MenusContentAdmin = "MenusContentAdmin";
        public const string SlidersContentAdmin = "SlidersContentAdmin";
        public const string PagesContentAdmin = "PagesContentAdmin";
        public const string UsersAdmin = "UsersAdmin";

        public const string DashboardAdmin = "DashboardAdmin";
        public const string AdminAccess = "AdminAccess";
        public const string ConfigurationsAdmin = "ConfigurationsAdmin";
        public const string BiographiesAdmin = "BiographiesAdmin";

        public const string IdentityUserAccess = "IdentityUserAccess";
        public const string IdentityManager = "IdentityManager";



    }
}
