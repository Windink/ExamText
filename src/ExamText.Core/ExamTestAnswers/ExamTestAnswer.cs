using Abp.Domain.Entities;
using ExamText.Authorization.Users;
using ExamText.ExamTestPapers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamText.ExamTestAnswers
{
    [Table("ExamTestAnswers")]
    public class ExamTestAnswer : Entity
    {
        
        public string ChoiceAnswers { get; set; }

        public string CompletionAnswers { get; set; }

        public string ShortAnswers { get; set; }

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey(nameof(ExamTestPaperId))]
        public ExamTestPaper examTestPaper { get; set; }

        [Required]
        public int ExamTestPaperId { get; set; }

        public int branch { get; set; }
        
        
    }
}
