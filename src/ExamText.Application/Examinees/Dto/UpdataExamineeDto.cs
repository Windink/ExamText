using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    
    public class UpdataExamineeDto : EntityDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginPassword { get; set; }

        public TaskState State { get; set; }

    }
}
