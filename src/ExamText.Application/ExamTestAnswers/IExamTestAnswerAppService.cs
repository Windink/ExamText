using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ExamText.ExamTestAnswers.Dto;

namespace ExamText.ExamTestAnswers
{
    public interface IExamTestAnswerAppService :IAsyncCrudAppService<ExamTestAnswerDto,int,PageExamTestAnswerResultReques,CreateExamTestAnswerDto,ExamTestAnswerDto>
    {

    }
}
