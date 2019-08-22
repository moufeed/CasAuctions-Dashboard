using System;

namespace TamTech.CasAuctions.Dashboard.SDK.Models.VMs
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}