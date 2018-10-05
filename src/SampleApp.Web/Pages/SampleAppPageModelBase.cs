using SampleApp.Localization.SampleApp;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SampleApp.Pages
{
    public abstract class SampleAppPageModelBase : AbpPageModel
    {
        protected SampleAppPageModelBase()
        {
            LocalizationResourceType = typeof(SampleAppResource);
        }
    }
}