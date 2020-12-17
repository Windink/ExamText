using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    [AutoMapFrom(typeof(Examinee))]
    public class ExamineeDto : EntityDto<long>
    {     

        public DateTime CreationTime { get; set; }
        [Required]
        public String PicturePath { get; set; }

        public TaskState State { get; set; }

        //public User user { get; set; }

    }
}
