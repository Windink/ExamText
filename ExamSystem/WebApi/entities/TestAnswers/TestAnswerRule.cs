using System;
using System.Collections.Generic;
using System.Text;
using ExamSystem.WebApi.Common_Interface;

namespace ExamSystem.WebApi.entities.TestAnswers
{
    public class TestAnswerRule : IResult
    {
        public string ChoiceAnswers { get; set; }

        public string CompletionAnswers { get; set; }

        public string ShortAnswers { get; set; }

        public long UserId { get; set; }

        public int ExamTestPaperId { get; set; }

    }
}
