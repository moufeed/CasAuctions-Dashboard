using System;
using System.Collections.Generic;
using System.Text;
using TamTech.CasAuctions.Dashboard.SDK.Services.ContentService.Regions.Models;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Admin.Regions;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Mappers.Regions
{
    public static class RegionsMapper
    {

        public static CreateRegionModel MapToCreateRegionModel(this RegionVM item)
        {
            return new CreateRegionModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Image = item.Image,
                ParentId = item.ParentId,
                IsOfficial = item.IsOfficial,
            };
        }


        public static RegionVM MapToRegionVM(this RegionDto item)
        {
            return new RegionVM
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Image = item.Image,
                Published = item.Published,
                IsOfficial = item.IsOfficial,
                GroupId = item.GroupId,
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                ModifiedDate = item.ModifiedDate,
                Locked = item.Locked,

            };
        }

        public static UpdateRegionModel MapToUpdateRegionModel(this RegionVM item)
        {
            return new UpdateRegionModel
            {
                Name = item.Name,
                Description = item.Description,
                Icon = item.Icon,
                Slug = item.Slug,
                Tags = item.Tags,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Lang = item.Lang,
                Image = item.Image,
                ParentId = item.ParentId,
                Id = item.Id,
                IsOfficial = item.IsOfficial
            };
        }
    }
}
