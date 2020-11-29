using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace ExamText.Examinees
{
    [Table("Examinees")]
     public class Examinee : Entity,IHasCreationTime
    {
        [Required]
        public string  ExamNum { get; set; }
        
        public string ExamPassword { get; set; }


        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        public Examinee()
        {
            CreationTime = DateTime.Now;
        }
        public enum TaskState : byte
        {
            Open = 0,
            Completed = 1
        }
    }
}
