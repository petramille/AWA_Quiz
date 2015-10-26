using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI
{
    public class Student : User
    {
        public Student(string firstName, string lastName, string userName, string password, string eMailAddress, string role) :
            base(firstName, lastName, userName, password, eMailAddress, role)
        {

        }
    }

}
