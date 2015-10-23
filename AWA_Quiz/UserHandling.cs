using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class UserHandling
    {
        DatabaseCommunication myDataBase = new DatabaseCommunication();

        public List<string> ReadUser(string eMailAddress)
        {
            List<string> user = myDataBase.ReadFromSQL(eMailAddress, "sp_GetUser");
            return user;
        }

       // Methods to add, delete and remove users are also supposed to be here
    }
}