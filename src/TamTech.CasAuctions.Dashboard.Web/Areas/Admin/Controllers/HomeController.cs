using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamTech.CasAuctions.Dashboard.Web.Areas.Shared.Controllers;
using TamTech.CasAuctions.Dashboard.SDK.Core.Telemetry;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity; 
using TamTech.CasAuctions.Dashboard.SDK.Core.Extensions;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using Microsoft.AspNetCore.Http;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload;
using Microsoft.Extensions.Localization;     
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContactUs;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Statistics;
using TamTech.CasAuctions.Dashboard.SDK.Core.Settings.Utilities;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContentCommonUtilities;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Statistics.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Pagination;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.ContactUs.Models;
using TamTech.CasAuctions.Dashboard.SDK.Core.Helpers;
using TamTech.CasAuctions.Dashboard.SDK.Core.Providers.Requests.Models;
using TamTech.CasAuctions.Dashboard.SDK.Services.Upload.Models;
using Microsoft.Extensions.Logging;

namespace TamTech.CasAuctions.Dashboard.Web.Areas.Admin.Controllers
{       
    [Authorize(Policy = PolicyConstants.DashboardAdmin)]
    public class HomeController : AdminBaseController
    {

        #region Props  
        private readonly ISettingsManager _settingsHelpers;
        private readonly IUsersManagerService _identityService; 
        private readonly IContactService _contactService;
        private readonly ICCUServices _contentServices;
        private readonly IStatisticsService _statisticsService;
    //    IUploadManagerService _uploadManager;

        #endregion

        #region Ctors  
        public HomeController(ITelemetryService telemetryClientService,
            ISettingsManager settingsHelpers,
           //  IUploadManagerService uploadManager,
               ILogger<HomeController> logger,
             IStringLocalizer<BaseController> localizer,
             ICCUServices contentServices,
             IContactService contactService,
             IStatisticsService statisticsService)
            : base(telemetryClientService, logger, localizer)
        {
            _settingsHelpers = settingsHelpers;
          //  _uploadManager = uploadManager;
            _contentServices = contentServices;
            _contactService = contactService;
            _statisticsService = statisticsService;
        }
        #endregion

        [AllowAnonymous]       
        public async Task<IActionResult> Index()
        {
          if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
        public virtual async Task<IActionResult> Dashboard ()
        {
          
            Dictionary<string, object> searchParams = new Dictionary<string, object>();
            searchParams.Add("StatusId", 1);
            try
            {

                var _lang = GetCurrentDataLang();
                var users = await _statisticsService.GetUsersStatistics(_lang);

                if (users.Success)
                {
                    ViewBag.Users = users.Data;
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

           

            return View();
        }

       
          
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public virtual IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
