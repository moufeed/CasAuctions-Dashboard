using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Menus.Settings
{    
    public interface IMenuItemApiSettings
    {    
        #region {Menu Items}  Create / Edit / Delete / Publish

        string CreateMenuItemAsyncEndpoint { get; }

        string EditMenuItemAsyncEndpoint { get; }

        string DeleteMenuItemAsyncEndpoint { get; }

        string PublishMenuItemAsyncEndpoint { get; }


        #endregion  
    }
}
