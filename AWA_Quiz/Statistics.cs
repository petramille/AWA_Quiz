using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Statistics
    {
        DatabaseCommunication myDatabase = new DatabaseCommunication();

        private int quizId;
        private int questionId;
        private int userId;
        private bool IsCorrect;

        public void Calculate(User user, Question question, bool isCorrect)
        {

        }

        public void VisualizeStatistics()
        {

        }
    }
}