using SampleApp.Localization.SampleApp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SampleApp.Permissions
{
    public class SampleAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SampleAppPermissions.GroupName);

            //Define your own permissions here. Examaple:
            myGroup.AddPermission(SampleAppPermissions.UserSearch, L("Permission:UserSearch"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SampleAppResource>(name);
        }
    }
}
