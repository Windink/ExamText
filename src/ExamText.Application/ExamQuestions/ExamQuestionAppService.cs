using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExamText.ExamQuestions.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamText.ExamQuestions
{
    public class ExamQuestionAppService : IExamQuestionAppService
    {
        public Task<ExamQustionDto> CreateAsync(ExamQustionDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ExamQustionDto>> GetAllAsync(ExamQustionDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQustionDto> GetAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQustionDto> UpdateAsync(ExamQustionDto input)
        {
            throw new NotImplementedException();
        }
    }
}
