using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ExamText.Authorization;
using ExamText.ExamTestPapers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamText.ExamTestPapers
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamTestPaperAppService : AsyncCrudAppService<ExamTestPaper,ExamTestPaperDto, int, PageExamTestPaperResultRequestDto, CreateExamTestPaperDto, UpdateTestPaperDto>, IExamTestPaperAppService
    {
        private readonly IRepository<ExamTestPaper> _examtestrepository;

        public ExamTestPaperAppService(IRepository<ExamTestPaper> examtestrepository) : base(examtestrepository)
        {
            _examtestrepository = examtestrepository;

        }

        public async override Task<ExamTestPaperDto> CreateAsync(CreateExamTestPaperDto input)
        {
            CheckCreatePermission();

            var test = ObjectMapper.Map<ExamTestPaper>(input);

            await _examtestrepository.InsertAsync(test);

            return MapToEntityDto(test);
        }

        //public override Task<ExamTestPaperDto> UpdateAsync(UpdateTestPaperDto input)
        //{
        //    CheckUpdatePermission();


        //    return;
        //}

    }
}
