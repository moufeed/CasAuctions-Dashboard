using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Shared.SEO
{
    public class Gallery : SeoSchema
    {
        public Person Author { get; set; } = new Person();
    }
}
