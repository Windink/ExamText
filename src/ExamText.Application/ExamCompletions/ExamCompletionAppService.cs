using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using ExamText.Authorization;
using ExamText.ExamCompletions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamText.ExamCompletions
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamCompletionAppService : AsyncCrudAppService<ExamCompletion, ExamCompletionDto, int,PageExamCompletionRequestDto,ExamCompletionDto, ExamCompletionDto>,IExamCompletionAppService
    {
        private readonly IRepository<ExamCompletion> _examCompletionRepository;

        public ExamCompletionAppService(IRepository<ExamCompletion> examquestionRepository) : base(examquestionRepository)
        {
            _examCompletionRepository = examquestionRepository;
        }


    }
}
