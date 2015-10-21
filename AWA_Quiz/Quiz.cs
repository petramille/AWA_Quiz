using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Quiz
    {
       // public int QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }

        private List<Question> questionList;

        public Quiz(string title, string description, string category, DateTime creationDate, List<Question> questionList)
        {
            Title = title;
            Description = description;
            Category = category;
            CreationDate = creationDate;
            this.questionList = questionList;
        }

       
    }

}