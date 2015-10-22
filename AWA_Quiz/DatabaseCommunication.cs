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


        //Get list from database via query
        public List<string> ReadFromSQL(string commandLine)
        {
            myConnection.ConnectionString = connectionString;
            SqlDataReader myReader = null;

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = commandLine;
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

                //Call sp
                myCommand.CommandText = "";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                //Write parameters to add
                myCommand.Parameters.Add("@Title", System.Data.SqlDbType.VarChar, 50);
                myCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 250); //size is max
                myCommand.Parameters.Add("@Category", System.Data.SqlDbType.VarChar, 50);
                myCommand.Parameters.Add("@CreationDate", System.Data.SqlDbType.Date);

                myCommand.Parameters["@Title"].Value = quiz.Title;
                myCommand.Parameters["@Description"].Value = quiz.Description;
                myCommand.Parameters["@Category"].Value = quiz.Category;
                myCommand.Parameters["@CreationDate"].Value = quiz.CreationDate;


                myCommand.Parameters["@QuizId"].Direction = System.Data.ParameterDirection.Output;

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                int quizId = 0;
                return quizId;
                
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public void AddQuestion()
        {
            //for (int i = 0; i < quiz.questionList.Count; i++)
            //{
            //    myCommand.Parameters.Add("@Title", System.Data.SqlDbType.VarChar, 250); //size is max
            //    myCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 250); //size is max
            //    myCommand.Parameters.Add("@CreationDate", System.Data.SqlDbType.Date);
            //    myCommand.Parameters.Add("@NrOfCorrectAnswers", System.Data.SqlDbType.Int);

            //    //go through all answers
            //    //for (int i = 0; i < quiz.questionList.an; i++)
            //    //{

            //    //}

            //}
        }
    }
}