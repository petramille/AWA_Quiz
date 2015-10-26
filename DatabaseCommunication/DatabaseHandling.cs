using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunication.Properties;

namespace DatabaseCommunication
{
    public class DatabaseHandling
    {
        SqlConnection myConnection = new SqlConnection();
        SqlCommand myCommand = new SqlCommand();

        string connectionString = Resources.connectionString;



        //version taking two parameters - parameters not communicated to db!!
        public List<string> ReadFromSQL(string quizTitle, string commandText)
        {
            myConnection.ConnectionString = connectionString;
            SqlDataReader myReader = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = commandText;
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

        //version taking three parameters, parameters not communicated to db!!
        public List<string> ReadFromSQL(string eMailAddress, string quizTitle, string commandText)
        {
            myConnection.ConnectionString = connectionString;
            SqlDataReader myReader = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = commandText;
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

        public int AddQuiz(string quizTitle, string quizDescription, string quizCategory, DateTime quizCreationDate)
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

                myCommand.Parameters["@QuizTitle"].Value = quizTitle;
                myCommand.Parameters["@QuizDescription"].Value = quizDescription;
                myCommand.Parameters["@QuizCategory"].Value = quizCategory;
                myCommand.Parameters["@QuizCreationDate"].Value = quizCreationDate;


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
            finally
            {

                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }


        public int AddQuestion(string questionTitle, string questionDescription, DateTime questionCreationDate, int questionNrOfCorrectAnswers, int quizId)
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
                myCommand.Parameters["@QuestionTitle"].Value = questionTitle;
                myCommand.Parameters["@QuestionDescription"].Value = questionDescription;
                myCommand.Parameters["@QuestionCreationDate"].Value = questionCreationDate;
                myCommand.Parameters["@QuestionNrOfCorrectAnswers"].Value = questionNrOfCorrectAnswers;

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
            finally
            {

                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }

        public void AddAnswer(string answerDescription, bool answerCorrect, int questionId)
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
                myCommand.Parameters["@AnswerDescription"].Value = answerDescription;
                if (answerCorrect)
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
            //catch exception
            catch (Exception)
            {


            }
            finally
            {

                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }




    }
}

