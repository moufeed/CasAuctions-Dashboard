using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TamTech.CasAuctions.Dashboard.SDK.Core.Telemetry;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Sort;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Filters;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Auctions;
using TamTech.CasAuctions.Dashboard.Web.Areas.Shared.Controllers;

namespace TamTech.CasAuctions.Dashboard.Web.Areas.Admin.Controllers
{
    public class AuctionsController : AdminBaseController
    {

        private readonly IAuctionsService _acutionsservice;
        public AuctionsController(ITelemetryService telemetryClientService, ILogger<AdminBaseController> logger,
            IStringLocalizer<BaseController> localizer , IAuctionsService acutionsservice) : base(telemetryClientService, logger, localizer)
        {
            _acutionsservice = acutionsservice;
        }

        [HttpGet("{Culture}/[Area]/[Controller]")]
        public async Task<IActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "name");
            SortingModel sorting = CreateSortingModel(model.SortBy);
            try
            {

                DTFilter filters = new DTFilter
                {
                    Lang = GetCurrentDataLang(),
                    PageSize = model.PageSize,
                    PageNumber = model.PageNumber,
                    SortBy = sorting.SortBy,
                    Descending = sorting.Descending,
                    Search = GenrateSearchParams(model)
                };

                var result = await _acutionsservice.GetAllAuctionsListAsync(filters);
                if (result.Success)
                {
                    return View(result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
             
            return View();
        }
    }
}