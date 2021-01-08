using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamTestAnswers.Dto
{
    [AutoMap(typeof(ExamTestAnswer))]
    public class ExamTestAnswerDto : EntityDto
    {
        public string ChoiceAnswers { get; set; }

        public string CompletionAnswers { get; set; }

        public string ShortAnswers { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public int ExamTestPaperId { get; set; }
    }
}
