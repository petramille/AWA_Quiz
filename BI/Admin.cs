using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string userName, string password, string eMailAddress, string role) :
            base(firstName, lastName, userName, password, eMailAddress, role)
        {

        }
    }
}
