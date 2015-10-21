using AWA_Quiz.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class QuizHandling
    {
        DatabaseCommunication myDataBase = new DatabaseCommunication();


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
            //Session with all questions that should be added to the quiz
            
        }

        //How to choose what quiz to display, id or title
        public void ReadQuiz(string title)
        {
            string commandLine = $"SELECT UnitStatus From Unit where Id = '{title}'";
            myDataBase.ReadFromSQL(commandLine);
        }

        public void UpdateQuestion(string title, string description, int numberOfCorrectAnswers, List<Answer> answerList)
        {
            //string commandLine = ({Resources.updateDb}, title);
            //myDataBase.EditSQL(commandLine);
        }

        public void DeleteQuestion()
        {

        }
    }
}