using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    //[AutoMapTo(typeof(Examinee))]
    public class CreateExamineeDto
    {
        [Column("ExamnesID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamLoginPassword { get; set; }

        public DateTime CreationTime { get; set; }


        public Bitmap Picture { get; set; }


        public TaskState State { get; set; }

    }
}
