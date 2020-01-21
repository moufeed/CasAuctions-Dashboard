using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Core.Telemetry;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Filter;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.SelectList;
using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Filters;
using TamTech.CasAuctions.Dashboard.SDK.Services.AuctionService.DirectSellItems;  
using TamTech.CasAuctions.Dashboard.Web.Areas.Shared.Controllers;

namespace TamTech.CasAuctions.Dashboard.Web.Areas.Admin.Controllers
{

    [Authorize(Policy = PolicyConstants.DsItemsAdmin)]
    public class DirectSellController : AdminBaseController
    {

        private readonly IDsItemsService _dsService;
        private readonly IStringLocalizer<BaseController> _localizer;
        public DirectSellController(ITelemetryService telemetryClientService, ILogger<AdminBaseController> logger,
            IStringLocalizer<BaseController> localizer, IDsItemsService acutionsservice) : base(telemetryClientService, logger, localizer)
        {
            _dsService = acutionsservice;
            _localizer = localizer;
        }
         
    

        private void createSortList(Filter model)
        {
            List<SelectListItem> SortItems = new List<SelectListItem>()
            {
        new SelectListItem {
          Text = _localizer["Title"],
          Value =  "Title"  ,
          Selected = model.SortBy == "Title"
        },
        new SelectListItem {
          Text = _localizer["CreatedDate"],
          Value =  "CreatedDate"  ,
          Selected = model.SortBy == "CreatedDate"
        },
      
        new SelectListItem   {
          Text = _localizer["EndDate"] ,
          Value = "EndDate" ,
          Selected =  model.SortBy == "EndDate"
        },
        
         new SelectListItem  {
          Text = _localizer["Status"] ,
          Value = "StatusId" ,
          Selected =  model.SortBy == "StatusId"
        },
         new SelectListItem  {
          Text = _localizer["Category"] ,
          Value = "CategoryId" ,
          Selected =  model.SortBy == "CategoryId"
        },
       
        };
            ViewBag.sortList = SortItems;
        }

        [HttpGet("{Culture}/[Area]/[Controller]")]
        public async Task<IActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "name");
            createSortList(model);
             
            try
            {

                var status = await _dsService.GetStatusListAsync();

                ViewBag.statusList = new SelectList(VerifySucceed(status) ? status.Data : new List<SelectListItemModel>(), "Value", "Text", model.StatusId);

                var categories = await _dsService.GetCatgoriesListAsync();

                ViewBag.categoriesList = new SelectList(VerifySucceed(categories) ? categories.Data : new List<SelectListItemModel>(), "Value", "Text", model.CategoryId);


                DTFilter filters = new DTFilter
                {
                    Lang = GetCurrentDataLang(),
                    PageSize = model.PageSize,
                    PageNumber = model.PageNumber,
                    SortBy = model.SortBy,
                    Search = GenrateSearchParams(model)
                };

                var result = await _dsService.GetAllItemsListAsync(filters);
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
                var result = await _dsService.GetDsItemDetailsAsync(id);
                return View(VerifySucceed(result) ? result.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }



        [HttpPost("{Culture}/[Area]/[Controller]/Action")]
        public virtual async Task<JsonResult> setAction(TakeActionModel model)
        {
            try
            {
                var result = await _dsService.TakeActionAsync(model);
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