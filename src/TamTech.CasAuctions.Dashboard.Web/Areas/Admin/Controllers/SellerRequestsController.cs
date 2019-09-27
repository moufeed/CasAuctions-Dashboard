using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TamTech.CasAuctions.Dashboard.SDK.Core.Telemetry;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Sort;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Filters;
using TamTech.CasAuctions.Dashboard.SDK.Services.IdentityService.SellerRequests;
using TamTech.CasAuctions.Dashboard.Web.Areas.Shared.Controllers;

namespace TamTech.CasAuctions.Dashboard.Web.Areas.Admin.Controllers
{
    public class SellerRequestsController : AdminBaseController
    {
        private readonly ISellerRequests _sellerRequests;
        public SellerRequestsController(ITelemetryService telemetryClientService, ILogger<AdminBaseController> logger,
                IStringLocalizer<BaseController> localizer, ISellerRequests SellerRequests) : base(telemetryClientService, logger, localizer)
        {
            _sellerRequests = SellerRequests;
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

                var status = await _sellerRequests.GetAllSelectListAsync();

                ViewBag.statusList = new SelectList(VerifySucceed(status) ? status.Data : new List<SelectListItemModel>(), "Value", "Text", model.StatusId);
                var result = await _sellerRequests.GetAllRequestsListAsync(filters);


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


        [HttpGet("{Culture}/[Area]/[Controller]/Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var _Actions = await _sellerRequests.GetRequestActionsAsync(id);
                ViewBag.Actions = VerifySucceed(_Actions) ? _Actions.Data : null;

                var result = await _sellerRequests.GetRequestDetailsAsync(id);
                return View(VerifySucceed(result) ? result.Data : null);

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }

        [HttpPost("{Culture}/[Area]/[Controller]/request/Action")]
        public virtual async Task<JsonResult> setAction(TakeActionModel model)
        {
            try
            {
                var result = await _sellerRequests.TakeActionAsync(model);
                if (result.Success)
                {
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonResult(result, model);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex, model);
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }
    }
}