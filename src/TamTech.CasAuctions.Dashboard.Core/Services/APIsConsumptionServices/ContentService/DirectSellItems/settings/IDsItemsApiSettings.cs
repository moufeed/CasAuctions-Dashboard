using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.ContentService.DirectSellItems.settings
{
    public interface IDsItemsApiSettings
    {
        string allItemsEndpoint { get; }
        string itemByIdEndpoint { get; }
        string StatusListEndpoint { get; }
        string CategoriesListEndpoint { get; }
   
        string TakeActionEndpoint { get; }
    }
}
