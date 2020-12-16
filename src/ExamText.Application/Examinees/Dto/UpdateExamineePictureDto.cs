using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ExamText.Examinees.Dto
{
    public class UpdateExamineePictureDto : EntityDto
    {
        public Bitmap Picture { get; set; }
    }
}
