﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ExamText.Authorization
{
    public class ExamTextAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Examinees, L("Examinees"));
            context.CreatePermission(PermissionNames.Pages_ExamCompletions, L("ExamCompletion"));
            context.CreatePermission(PermissionNames.Pages_ExamQuestions, L("ExamQuestions"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ExamTextConsts.LocalizationSourceName);
        }
    }
}
