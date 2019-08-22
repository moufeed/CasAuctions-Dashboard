using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Helpers.Converters
{
    public interface IStringConverters
    {
        List<string> ToListString(string words, char separator = ',');
    }
}
