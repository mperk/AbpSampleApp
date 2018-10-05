using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace SampleApp.Branding
{
    [Dependency(ReplaceServices = true)]
    public class SampleAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SampleApp";
    }
}
