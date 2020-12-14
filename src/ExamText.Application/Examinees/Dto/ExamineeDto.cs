using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    [AutoMapFrom(typeof(Examinee))]
    public class ExamineeDto : EntityDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginPassword { get; set; }

        public DateTime CreationTime { get; set; }


        public String PicturePath { get; set; }


        public TaskState State { get; set; }

    }
}
