using System;

namespace SampleApp.Permissions
{
    public static class SampleAppPermissions
    {
        public const string GroupName = "SampleApp";

        //Add your own permission names. Example:
        public const string UserSearch = GroupName + ".UserSearch";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return Array.Empty<string>();
        }
    }
}