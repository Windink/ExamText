using Abp.Application.Services;
using ExamText.ExamQuestions.Dto;

namespace ExamText.ExamQuestions
{
    public interface IExamQuestionAppService : IAsyncCrudAppService<ExamQuestionDto,int,PagedExamQuestionsResultRequestDto,ExamQuestionDto,ExamQuestionDto>
    {

    }
}
