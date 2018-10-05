using System;

namespace SampleApp.Permissions
{
    public static class SampleAppPermissions
    {
        public const string GroupName = "SampleApp";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return Array.Empty<string>();
        }
    }
}