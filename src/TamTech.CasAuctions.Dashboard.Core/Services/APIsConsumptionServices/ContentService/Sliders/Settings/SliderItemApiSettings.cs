using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Sliders.Settings
{
    public class SliderItemApiSettings : BaseAPISettings, ISliderItemApiSettings
    {


        public SliderItemApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }


        #region manager

        #region Get
        public string GetSliderItemByIdEndpoint => $"{_AdminPath}/GetSliderItemByIdAsync";
        #endregion


        #region Create / Edit / Publish / Delete      
        public string CreateSliderItemEndpoint => $"{_AdminPath}/CreateAsync";

        public string UpdateSliderItemEndpoint => $"{_AdminPath}/EditAsync";

        public string publishSliderItemByIdEndpoint => $"{_AdminPath}/PublishAsync";

        public string DeleteSliderItemByIdEndpoint => $"{_AdminPath}/HardDeleteAsync";
        #endregion
        #endregion
    }
}
