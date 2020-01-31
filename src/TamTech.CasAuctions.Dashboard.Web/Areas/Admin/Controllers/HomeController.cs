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
using Microsoft.Extensions.Logging;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.Statistics;
using TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices;
using TamTech.CasAuctions.Dashboard.SDK.Services.TelemetryAnalyticService;

namespace TamTech.CasAuctions.Dashboard.Web.Areas.Admin.Controllers
{       
  [Authorize(Policy = PolicyConstants.DashboardAdmin)]
    public class HomeController : AdminBaseController
    {
        
        #region Props  
                                                                  
        private readonly SDK.Services.AuctionService.Statistics.IStatisticsService _casAuctionStatisticsService;
        private readonly ITelemetryAnalyticService _telemetryAnalyticService;
    //    IUploadManagerService _uploadManager;

        #endregion

        #region Ctors  
        public HomeController(ITelemetryService telemetryClientService,   
               ILogger<HomeController> logger,
               IStringLocalizer<BaseController> localizer,
            SDK.Services.AuctionService.Statistics.IStatisticsService  casAuctionStatisticsService, ITelemetryAnalyticService telemetryAnalyticService)
            : base(telemetryClientService, logger, localizer)
        {
        
            _casAuctionStatisticsService = casAuctionStatisticsService;
            _telemetryAnalyticService = telemetryAnalyticService;
          
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
            ViewBag.UsersChart = null;

           
            try
            {

              var _analyticResult  =  await  _telemetryAnalyticService.GetCountActiveUsersAsync(DateTime.Now.AddMonths(-3), DateTime.Now);

                if (_analyticResult.Success)
                {
                    ViewBag.ActiveUsersChart = _analyticResult.Data;
                }
                var _lang = GetCurrentDataLang();
                var users = await _casAuctionStatisticsService.GetUsersStatistics(_lang);

                if (users.Success)
                {
                    ViewBag.UsersChart = users.Data;
                }

                



            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

           

            return View();
        }


        
        [HttpGet("{Culture}/[Area]/[Controller]/AuctionsStatistics")]
        public async Task<JsonResult> AuctionsStatistics(DateTime fromdate , DateTime todate , int TimeZone)
        {

            try
            {
                var auctions_statistics = await _casAuctionStatisticsService.GetAuctionsStatistics(fromdate, todate, TimeZone);
                return Json(auctions_statistics);
            }
            catch (Exception ex)
            {

                return ReturnJsonErrorResult(ex.Message, fromdate);

            }
             

        }
        [HttpGet("{Culture}/[Area]/[Controller]/DSItemsStatistics")]
        public async Task<JsonResult> DSItemsStatistics(DateTime fromdate, DateTime todate, int TimeZone)
        {

            try
            {
                var statistics = await _casAuctionStatisticsService.GetDSItemsStatistics(fromdate, todate, TimeZone);
                return Json(statistics);
            }
            catch (Exception ex)
            {
                return ReturnJsonErrorResult(ex.Message, fromdate);

            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public virtual IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
