using TamTech.CasAuctions.Dashboard.SDK.Models.Shared;

namespace TamTech.CasAuctions.Dashboard.SDK.Services.APIsConsumptionServices.Sliders.Settings
{
    public class SliderApiSettings : BaseAPISettings, ISliderApiSettings
    {


        public SliderApiSettings(BackendAPIsSettings settings, string controller) : base(settings, controller)
        {
        }

        #region public
        public string GetPublishedBySettingIdEndpoint => $"{_PortlPath}/GetPublicBySettingIdAsync";

        #endregion

        #region manager

        #region Get

        public string GetAllEndpoint => $"{_AdminPath}/GetAllExceptSoftDeletedAsync";

        public string GetByIdEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";
        #endregion

        #region Create / Edit / Publish / Delete

        public string CreateEndpoint => $"{_AdminPath}/CreateAsync";

        public string UpdateEndpoint => $"{_AdminPath}/EditAsync";

        public string DeleteByIdEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        public string publishByIdEndpoint => $"{_AdminPath}/PublishAsync";

    
        #endregion
        #endregion
    }
}
