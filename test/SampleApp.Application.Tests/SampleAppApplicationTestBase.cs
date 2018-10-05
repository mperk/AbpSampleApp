using Volo.Abp;

namespace SampleApp
{
    public abstract class SampleAppApplicationTestBase : AbpIntegratedTest<SampleAppApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
