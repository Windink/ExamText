using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamText.ExamCompletions
{
    [Table("ExamCompletions")]
    public class ExamCompletion : Entity
    {
        [Key]
        [Column("ExamCompletionID")]
        public override int Id { get; set; }

        [Required]
        public string Question { get; set; }


        [Required]
        public string Answer { get; set; }
    }
}
