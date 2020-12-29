
using System.Text;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace ExamText.ExamShortAnswerQuestions
{
    [Table("ExamShortAnswerQuestion")]
    public class ExamShortAnswerQuestion : Entity
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

    }
}
