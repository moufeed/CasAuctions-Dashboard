using System.Collections.Generic;

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Cultures

{
    public static class CultureConstants
    {

        public static readonly CultureModel DefaultCulture = new CultureModel
        {
            Name = "english",
            Culture = "en",
            Lang = "en"
        };

        public static readonly List<CultureModel> CulturesList = new List<CultureModel>
        {
            DefaultCulture,
           
        };
        public static readonly string Constraint = DefaultCulture.Culture.Length == 2 ? "^([a||e||t||f||d])+([r||n||r||e])$" : "^([ar||en]{2})+(-)+([ar||en]{2})$";
       
    }
}
