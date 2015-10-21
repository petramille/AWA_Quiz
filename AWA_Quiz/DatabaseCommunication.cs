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


        public void FindStatistics()
        {
            try
            {
                myCommand.Connection = myConnection;
                myConnection.ConnectionString = connectionString; // @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Contacts;Integrated Security=SSPI"
                myConnection.Open();

                //Call sp
                myCommand.CommandText = "";
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                //Write parameters to add
                myCommand.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 12);
                


                myCommand.Parameters["@Username"].Value = "";
                
                
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