using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ExamText.Authorization
{
    public class ExamTextAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {        
            
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Examinees, L("Examinees"));

            var roles = context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            roles.CreateChildPermission(PermissionNames.Pages_Roles_Get, L("GetRoles"));

            var users = context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Create, L("CreateUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Update, L("UpdataUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Delete, L("DeteleUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_ChangePassword, L("ChangeUserPassword"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Get, L("GetUser"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ExamTextConsts.LocalizationSourceName);
        }
    }
}
