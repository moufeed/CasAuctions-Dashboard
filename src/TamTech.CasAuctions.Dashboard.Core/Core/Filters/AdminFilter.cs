using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 
using TamTech.CasAuctions.Dashboard.SDK.Core.Settings.Utilities;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Filters
{ 
    public class AdminFilter : ActionFilterAttribute, IActionFilter
    {  
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;

            if (controller != null)
            {

                controller.ViewBag.AppVersion = SettingsHelper.AppVersion; 
            } 

        }
    }
}
