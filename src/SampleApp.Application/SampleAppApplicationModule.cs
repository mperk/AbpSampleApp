using Microsoft.Extensions.DependencyInjection;
using SampleApp.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace SampleApp
{
    [DependsOn(
        typeof(SampleAppDomainModule),
        typeof(AbpIdentityApplicationModule))]
    public class SampleAppApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<SampleAppPermissionDefinitionProvider>();
            });

            context.Services.Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SampleAppApplicationAutoMapperProfile>();
            });
        }
    }
}
