using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using SampleApp.Localization.SampleApp;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SampleApp.Pages
{
    public abstract class SampleAppPageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<SampleAppResource> L { get; set; }
    }
}
