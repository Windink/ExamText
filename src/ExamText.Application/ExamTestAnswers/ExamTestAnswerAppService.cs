using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ExamText.Authorization;
using ExamText.ExamTestAnswers.Dto;

namespace ExamText.ExamTestAnswers
{
    [AbpAuthorize(PermissionNames.Pages_Test_Answer)]
    public class ExamTestAnswerAppService : AsyncCrudAppService<ExamTestAnswer, ExamTestAnswerDto, int, PageExamTestAnswerResultReques, CreateExamTestAnswerDto, ExamTestAnswerDto>,IExamTestAnswerAppService
    {
        private readonly IRepository<ExamTestAnswer> _examtestrepository;

        public ExamTestAnswerAppService(IRepository<ExamTestAnswer> examtestrepository) : base(examtestrepository)
        {
            _examtestrepository = examtestrepository;

        }

    }
}
