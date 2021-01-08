using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ExamText.Authorization;
using ExamText.ExamChoiceQuestions.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamText.ExamChoiceQuestions
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamChoiceQuestionAppService : AsyncCrudAppService<ExamChoiceQuestion,ExamChoiceQuestionDto, int, PageExamChoiceQuestionsResultRequestDto, CreateExamChoiceQuestionDto, ExamChoiceQuestionDto> ,IExamChoiceQuestionAppService
    {
        private readonly IRepository<ExamChoiceQuestion> _examquestionRepository;
        private char[] changeNum = new char[] { 'A', 'B', 'C', 'D' };

        public ExamChoiceQuestionAppService(IRepository<ExamChoiceQuestion> examquestionRepository): base(examquestionRepository)
        {
            _examquestionRepository = examquestionRepository;

        }


        //public override async Task<ExamChoiceQuestionDto> CreateAsync(CreateExamChoiceQuestionDto input)
        //{
        //    CheckCreatePermission();

        //    var examquestion = ObjectMapper.Map<ExamChoiceQuestion>(input);
           
        //    if((Array.Find(changeNum,x=>x==examquestion.TrueAnswerIndex)).Equals((char)0))
        //    { examquestion.TrueAnswerIndex = 'A'; }

        //    //await _examquestionRepository.InsertAsync(examquestion);

        //    return MapToEntityDto(examquestion);
        //}

      
    }
}
