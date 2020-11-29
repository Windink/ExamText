using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    [AutoMapFrom(typeof(Examinee))]
    public class ExamineeDto : EntityDto
    {
        [Required]
        public string ExamNum { get; set; }

        public string ExamPassword { get; set; }


        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

       
    }
}
