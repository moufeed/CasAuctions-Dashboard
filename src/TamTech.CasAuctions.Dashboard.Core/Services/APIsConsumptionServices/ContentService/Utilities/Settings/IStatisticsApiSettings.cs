using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Utilities.Settings
{
    public interface IStatisticsApiSettings
    {
        string GetPOSNumericalStatisticsByStatusEndpoint { get; }

        string GetPOSNumericalStatisticsBySectorEndpoint { get; }

        string GetPOSNumericalStatisticsByTypeEndpoint { get; }

        string GetVendorNumericalStatisticsByStatusEndpoint { get; }

        string GetContactUsNumericalStatisticsByStatusEndpoint { get; }

        string GetContactUsNumericalStatisticsByTypeEndpoint { get; }
         
    }
}
