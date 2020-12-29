using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using ExamText.ExamCompletions;

namespace ExamText.ExamChoiceQuestions
{
    [Table("ExamChoiceQuestion")]
    public class ExamChoiceQuestion : Entity
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
