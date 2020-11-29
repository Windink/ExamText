using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExamText.Examinees.Dto;
namespace ExamText.Examinees
{
    public interface IExamineeAppService : IAsyncCrudAppService<ExamineeDto,int,PagedExamineeResultRequestDto,CreateExamineeDto,ExamineeDto>
    {
        Task<ListResultDto<ExamineeDto>> GetExaminees();
    }
}
