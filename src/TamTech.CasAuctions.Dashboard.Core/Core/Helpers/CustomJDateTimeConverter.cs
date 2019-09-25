using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Helpers
{
    public class CustomJDateTimeConverter : IsoDateTimeConverter
    {
        public CustomJDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";//"yyyy-MM-ddThh:mm:ss.sTZD";//  "YYYY-MM-DDThh:mm:ss.sTZD";
        }
    }
}
