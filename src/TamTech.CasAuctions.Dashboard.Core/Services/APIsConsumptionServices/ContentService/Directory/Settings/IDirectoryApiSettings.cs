using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Directory.Settings
{
    public interface IDirectoryApiSettings
    {
        string GetPublishedBySlugEndPoint { get; }

        string FindEndPoint { get; }

        string GetCountOfPublishedEndPoint { get; }

        string GetAllPublishedSlugsEndPoint { get; }
    }
}
