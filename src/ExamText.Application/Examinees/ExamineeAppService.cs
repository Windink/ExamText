using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Timing;
using ExamText.Examinees.Dto;
using Microsoft.AspNetCore.Identity;

namespace ExamText.Examinees
{
    //[AbpAuthorize(PermissionNames.Pages_Examinees)]
    public class ExamineeAppService :AsyncCrudAppService<Examinee,ExamineeDto,int,PagedExamineeResultRequestDto,CreateExamineeDto,ExamineeDto> ,IExamineeAppService
    {
        private readonly IRepository<Examinee> _examineeRepository;


        public ExamineeAppService(IRepository<Examinee> examineeRepository):base(examineeRepository)
        {
            _examineeRepository = examineeRepository;
        }



        public override async Task<ExamineeDto> CreateAsync(CreateExamineeDto input)
        {
            CheckCreatePermission();
            Bitmap bitmap = input.Picture;

            string filename = "D:\\Windink Pro\\5.8.1\\aspnet-core\\facesystem\\data\\Face\\" + input.Name + ".jpg";

            bitmap.Save(filename);

            Examinee examinee = new Examinee()
            {
                Id = input.Id,
                CreationTime = Clock.Now,
                ExamLoginNum = input.ExamLoginNum,
                ExamLoginPassword = input.ExamLoginPassword,
                Name = input.Name,
                State = input.State,
                PicturePath = filename
            };

            //var examinee = ObjectMapper.Map<Examinee>(input);

            await _examineeRepository.InsertAsync(examinee);

            return  MapToEntityDto(examinee);
        }

        public override async Task<ExamineeDto> UpdateAsync(ExamineeDto input)
        {
            CheckUpdatePermission();

            var examinee = ObjectMapper.Map<Examinee>(input);
            await _examineeRepository.UpdateAsync(examinee);

            return MapToEntityDto(examinee);
        }

        public async Task<ListResultDto<ExamineeDto>> GetExaminees()
        {
            CheckGetPermission();
            var examinee = await _examineeRepository.GetAllListAsync();
            return new ListResultDto<ExamineeDto>(ObjectMapper.Map<List<ExamineeDto>>(examinee));
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();
            var examinee = _examineeRepository.Get(input.Id);
            await _examineeRepository.DeleteAsync(examinee);
        }


        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<int> GetExamineesCount()
        {
            var examinees = await _examineeRepository.GetAllListAsync();
            return examinees.Count;
        }
    }
}
