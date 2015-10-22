using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AWA_Quiz.Properties;

namespace AWA_Quiz
{
    public class DatabaseCommunication
    {
        SqlConnection myConnection = new SqlConnection();
        SqlCommand myCommand = new SqlCommand();

        string connectionString = Resources.connectionString;


        //Get list from database via view - all quiz info
        //View was created but difficult to handle same name from different original tables
        public List<string> ReadFromSQL(string quizTitle)
        {
            myConnection.ConnectionString = connectionString;
            SqlDataReader myReader = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = "sp_GetQuiz";
                myReader = myCommand.ExecuteReader();

                List<string> mySQLResult = new List<string>();
                if (myReader != null)
                {
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            mySQLResult.Add(myReader[i].ToString());
                        }
                    }
                    return mySQLResult;
                }
                else
                {
                    return null;
                }
            }
            //Catch the exception!!
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }


        //Edit the database via query
        public void EditSQL(string commandLine)
        {
            myConnection.ConnectionString = connectionString;
            SqlDataReader myReader = null;

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = commandLine;
                myReader = myCommand.ExecuteReader();

            }
            //Catch the exception!!
            catch (Exception ex)
            {

            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }

        public int AddQuiz(Quiz quiz)
        {
            try
            {
                myCommand.Connection = myConnection;
                myConnection.ConnectionString = connectionString;
                myConnection.Open();

                myCommand.CommandText = "sp_AddQuiz";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                myCommand.Parameters.Add("@QuizTitle", System.Data.SqlDbType.VarChar, 50);
                myCommand.Parameters.Add("@QuizDescription", System.Data.SqlDbType.VarChar, 250); //size is max
                myCommand.Parameters.Add("@QuizCategory", System.Data.SqlDbType.VarChar, 50);
                myCommand.Parameters.Add("@QuizCreationDate", System.Data.SqlDbType.Date);

                myCommand.Parameters["@QuizTitle"].Value = quiz.Title;
                myCommand.Parameters["@QuizDescription"].Value = quiz.Description;
                myCommand.Parameters["@QuizCategory"].Value = quiz.Category;
                myCommand.Parameters["@QuizCreationDate"].Value = quiz.CreationDate;


                myCommand.Parameters["@QuizId"].Direction = System.Data.ParameterDirection.Output;

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                int quizId = System.Convert.ToInt32(myCommand.Parameters["@QuizId"].Value);
                return quizId;

            }
            catch (Exception)
            {

                return 0;
            }
        }


        public int AddQuestion(Question question, int quizId)
        {
            try
            {
                myCommand.Connection = myConnection;
                myConnection.ConnectionString = connectionString;
                myConnection.Open();

                myCommand.CommandText = "sp_AddQuestion";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                myCommand.Parameters.Add("@QuizID", System.Data.SqlDbType.Int);
                myCommand.Parameters.Add("@QuestionTitle", System.Data.SqlDbType.VarChar, 250); //size is max
                myCommand.Parameters.Add("@QuestionDescription", System.Data.SqlDbType.VarChar, 250); //size is max
                myCommand.Parameters.Add("@QuestionCreationDate", System.Data.SqlDbType.Date);
                myCommand.Parameters.Add("@QuestionNrOfCorrectAnswers", System.Data.SqlDbType.Int);

                myCommand.Parameters["@QuizID"].Value = quizId;
                myCommand.Parameters["@QuestionTitle"].Value = question.Title;
                myCommand.Parameters["@QuestionDescription"].Value = question.Description;
                myCommand.Parameters["@QuestionCreationDate"].Value = question.CreationDate;
                myCommand.Parameters["@QuestionNrOfCorrectAnswers"].Value = question.NumberOfCorrectAnswers;

                myCommand.Parameters["@QuestionId"].Direction = System.Data.ParameterDirection.Output;

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                int questionId = System.Convert.ToInt32(myCommand.Parameters["@QuestionId"].Value);
                return questionId;

            }
            catch (Exception)
            {

                return 0;
            }
        }

        public void AddAnswer(Answer answer, int questionId)
        {
            try
            {
                myCommand.Connection = myConnection;
                myConnection.ConnectionString = connectionString;
                myConnection.Open();

                myCommand.CommandText = "sp_AddAnswer";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                myCommand.Parameters.Add("@QuestionID", System.Data.SqlDbType.Int);
                myCommand.Parameters.Add("@AnswerDescription", System.Data.SqlDbType.VarChar, 250); //size is max
                myCommand.Parameters.Add("@AnswerIsCorrectAnswer", System.Data.SqlDbType.Int);


                myCommand.Parameters["@QuestionID"].Value = questionId;
                myCommand.Parameters["@AnswerDescription"].Value = answer.AnswerText;
                if (answer.IsCorrect)
                {
                    myCommand.Parameters["@AnswerIsCorrectAnswer"].Value = 1;
                }
                else
                {
                    myCommand.Parameters["@AnswerIsCorrectAnswer"].Value = 0;
                }

                myCommand.ExecuteNonQuery();
                myConnection.Close();

            }
            catch (Exception)
            {


            }
        }
        public void ReadQuiz(string title)
        {
            try
            {
                myCommand.Connection = myConnection;
                myConnection.ConnectionString = connectionString;
                myConnection.Open();

                //Call sp
                myCommand.CommandText = "";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                //Write parameters to add
                myCommand.Parameters.Add("@QuizTitle", System.Data.SqlDbType.VarChar, 50);
                

                myCommand.Parameters["@QuizTitle"].Value = title;

                myCommand.Parameters["@"].Direction = System.Data.ParameterDirection.Output;

                myCommand.ExecuteNonQuery();
                myConnection.Close();



            }
            catch (Exception)
            {


            }
        }
    }
}