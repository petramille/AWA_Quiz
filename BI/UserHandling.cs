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

        public List<string> ReadUser(string eMailAddress)
        {
            List<string> user = myDataBase.ReadFromSQL(eMailAddress, "sp_GetUser");
            return user;
        }

        // Methods to add, delete and remove users are also supposed to be here
    }
}
