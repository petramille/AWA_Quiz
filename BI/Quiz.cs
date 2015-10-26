using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI
{
    public class Quiz
    {
        // public int QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Question> questionList;

        public Quiz(string title, string description, string category, DateTime creationDate)
        {
            Title = title;
            Description = description;
            Category = category;
            CreationDate = creationDate;

        }


    }
}
