using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunication;


namespace BI
{
    public class QuizHandling
    {
        DatabaseHandling myDataBase = new DatabaseHandling();


        public int CreateQuiz(string title, string description, string category)
        {
            DateTime creationDate = DateTime.Now;
            Quiz newQuiz = new Quiz(title, description, category, creationDate);
            int quizId = myDataBase.AddQuiz(title, description, category, creationDate);
            return quizId;
        }

        public int CreateQuestion(int quizId, string title, string description, int numberOfCorrectAnswers)
        {
            DateTime creationDate = DateTime.Now;
            //Question newQuestion = new Question(title, description, creationDate, numberOfCorrectAnswers, answerList);
            int questionId = myDataBase.AddQuestion(title, description, creationDate, numberOfCorrectAnswers, quizId);
            return questionId;
        }

        public void CreateAnswer(int questionId, string answerText, bool isCorrect)
        {
            Answer newAnswer = new Answer(answerText, isCorrect);
            myDataBase.AddAnswer(answerText, isCorrect, questionId);
        }

        public List<string> ReadAllTests()
        {
            List<string> allTests = myDataBase.ReadAllTestsSQL($"SELECT QuizTitle FROM Quiz");
            return allTests;
        }

        //How to choose what quiz to display, id or title? use a view to get all quiz info?
        public void ReadQuiz(string title)
        {
            List<string> myQuiz = myDataBase.ReadFromSQL(title, "sp_GetQuiz");
        }

        public void UpdateQuestion(int questionId, string title, string description, int numberOfCorrectAnswers)
        {
            string commandLine = $"UPDATE Question SET {title} = @Title, {description} = @Description, {numberOfCorrectAnswers} = @NrOfCorrectAnswers, WHERE {questionId} = @QuestionId";
            myDataBase.EditSQL(commandLine);
        }

        public void UpdateAnswer(int answerId, string answerText, bool isCorrect)
        {
            string commandLine = $"UPDATE Answer SET {answerText} = @Description, {isCorrect} = @IsCorrectAnswer, WHERE {answerId} = @AnswerId";
            myDataBase.EditSQL(commandLine);
        }

        //Trigger delete from intermediate tables and Answer table???? Now only the question is deleted
        public void DeleteQuestion(string questionTitle)
        {
            string commandLine = $"DELETE FROM Question WHERE {questionTitle} = @QuestionTitle";
            myDataBase.EditSQL(commandLine);
        }

        public void DeleteQuiz(string quizTitle)
        {
            string commandLine = $"DELETE FROM Quiz WHERE {quizTitle} = @QuizTitle";
            myDataBase.EditSQL(commandLine);
        }


        //Check the queries
        public void UpdateStatistics(int quizId, int questionId, int userId, bool isCorrect)
        {
            string commandLine;
            if (isCorrect)
            {
                commandLine = $"UPDATE Statistic SET {quizId} = @QuizID, {questionId} = @QuestionID, {userId} = @UserID, 1 = @AnsweredCorrectly";
            }
            else
            {
                commandLine = $"UPDATE Statistic SET {quizId} = @QuizID, {questionId} = @QuestionID, {userId} = @UserID, 0 = @AnsweredCorrectly";
            }
            myDataBase.EditSQL(commandLine);
        }
    }
}
