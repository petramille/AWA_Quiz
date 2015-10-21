using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class QuizHandling
    {
        public void CreateQuiz(string title, string description, string category, List<Question> questionList)
        {
            DateTime creationDate = DateTime.Now;
            Quiz newQuiz = new Quiz(title, description, category, creationDate, questionList);
        }

        public void CreateQuestion(string title, string description, int numberOfCorrectAnswers, List<Answer> answerList)
        {
            
            DateTime creationDate = DateTime.Now;
            Question newQuestion = new Question(title, description, creationDate, numberOfCorrectAnswers, answerList);
            List<Question> questionList = new List<Question>();
            questionList.Add(newQuestion);
            
        }

        public void ReadQuestion()
        {

        }

        public void UpdateQuestion()
        {

        }

        public void DeleteQuestion()
        {

        }
    }
}