using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfCorrectAnswers { get; set; }


        private List<Answer> answerList;
    }
}