using Abp.Authorization;
using ExamText.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamCompletions
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamCompletionAppService
    {


    }
}
