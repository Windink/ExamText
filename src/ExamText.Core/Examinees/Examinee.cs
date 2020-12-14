using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;


namespace ExamText.Examinees
{
    [Table("Examinees")]
     public class Examinee :Entity<int>, IHasCreationTime
    {
        [Key]
        [Column("ExamnesID")]
        public override int Id { get; set ; }


        [Required]
        [StringLength(20)]
        public string  ExamLoginNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginPassword { get; set; }
        
        public DateTime CreationTime { get; set; }

        [Required]
        public string Name { get; set; }

        public String PicturePath { get; set; }

        
        public TaskState State { get; set; }

        public Examinee()
        {
            CreationTime = Clock.Now;
            
        }
        public enum TaskState : byte
        {
            Open = 0,
            Completed = 1
        }
        
    }
}
