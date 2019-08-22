using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs.Admin.Menus
{
    public class MenuLiteVM
    {
        public Guid Id { get; set; }

        public string Position { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
