using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunication;

namespace BI
{
    public class UserHandling
    {
        DatabaseHandling myDataBase = new DatabaseHandling();


        public List<string> LogIn(string eMail, string password)
        {
            List<string> tmpUser = new List<string>();
            tmpUser = myDataBase.LogInSQL(eMail, password, "sp_GetUser");

            List<string> tmpList = new List<string>();
            if (tmpUser == null)
            {
                tmpList.Add("No access to the database at the moment");
            }

            else
            {
                tmpList = tmpUser;
            }
            return tmpList;
        }

        

        // Methods to add, delete and remove users are also supposed to be here
    }
}
