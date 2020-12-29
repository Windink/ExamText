using Abp.Application.Services;
using ExamText.ExamTestPapers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamTestPapers
{
    public interface IExamTestPaperAppService : IAsyncCrudAppService<ExamTestPaperDto,int,PageExamTestPaperResultRequestDto,CreateExamTestPaperDto,UpdateTestPaperDto>
    {

    }
}
