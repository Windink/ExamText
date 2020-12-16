using Abp.Authorization;
using ExamText.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamCompletion
{
    [AbpAuthorize(PermissionNames.Pages_ExamCompletions)]
    public class ExamCompletionAppService
    {
    }
}
