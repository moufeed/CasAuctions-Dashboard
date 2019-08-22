using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.Biography;
using TamTech.CasAuctions.Dashboard.SDK.Models.Dtos.Slugs;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.Portal.Partials
{
    public class HeaderVm
    {
        public HeaderVm(List<SlugModel> Slugs, BiographyInfoVm BiographyInfo)
        {
            this.BiographyInfo = BiographyInfo;
            this.Slugs = Slugs;
        }


        public BiographyInfoVm BiographyInfo { get; set; }

        public List<SlugModel> Slugs { get; set; }
    }
}
