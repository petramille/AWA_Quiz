﻿using AWA_Quiz.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWA_Quiz
{
    public class QuizHandling
    {
        DatabaseCommunication myDataBase = new DatabaseCommunication();


        public int CreateQuiz(string title, string description, string category)
        {
            DateTime creationDate = DateTime.Now;
            Quiz newQuiz = new Quiz(title, description, category, creationDate);
            int quizId = myDataBase.AddQuiz(newQuiz);
            return quizId;
        }

        public void CreateQuestion(int quizId, string title, string description, int numberOfCorrectAnswers, List<Answer> answerList)
        {
            DateTime creationDate = DateTime.Now;
            Question newQuestion = new Question(title, description, creationDate, numberOfCorrectAnswers, answerList);
            int questionId = myDataBase.AddQuestion(newQuestion, quizId);
            
        }

        public void CreateAnswer(int questionId, string answerText, bool isCorrect)
        {
            Answer newAnswer = new Answer(answerText, isCorrect);
            myDataBase.AddAnswer(newAnswer, questionId);
        }

        //How to choose what quiz to display, id or title?
        public void ReadQuiz(string title)
        {
            string commandLine = $"SELECT Title, Description From Question where Title = '{title}'";
            myDataBase.ReadFromSQL(commandLine);
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


        public void DeleteQuestion(int questionId)
        {
            string commandLine = $"DELETE FROM Question WHERE {questionId} = @QuestionId"; //Trigger delete from intermediate tables and Answer table????
            myDataBase.EditSQL(commandLine);
        }
    }
}