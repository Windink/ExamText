using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace ExamText.ExamQuestions.Dto
{
    [AutoMapFrom(typeof(ExamQuestion))]
    public class ExamQuestionDto : EntityDto
    {

        [Required]
        public string Question { get; set; }

        [Required]
        public string TrueAnswer { get; set; }

        [Required]
        public string OrtherAnswerOne { get; set; }

        [Required]
        public string OrtherAnswerTwo { get; set; }

        [Required]
        public string OrtherAnswerThree { get; set; }

    }
}
