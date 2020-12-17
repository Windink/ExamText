using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ExamText.ExamQuestions.Dto;
using System;
using System.Threading.Tasks;

namespace ExamText.ExamQuestions
{
    public class ExamQuestionAppService : AsyncCrudAppService<ExamQuestion,ExamQuestionDto, int, PagedExamQuestionsResultRequestDto, ExamQuestionDto, ExamQuestionDto> ,IExamQuestionAppService
    {
        private readonly IRepository<ExamQuestion> _examquestionRepository;

        public ExamQuestionAppService(IRepository<ExamQuestion> examquestionRepository): base(examquestionRepository)
        {
            _examquestionRepository = examquestionRepository;

        }

        //public override async Task<ExamQuestionDto> CreateAsync(ExamQuestionDto input)
        //{
        //    var examquestion = ObjectMapper.Map<ExamQuestion>(input);

        //    await _examquestionRepository.InsertAsync(examquestion);

        //    return MapToEntityDto(examquestion);
        //}

 
    }
}
