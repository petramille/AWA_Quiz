using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Student : User
    {
        public Student(int userId, string firstName, string lastName, string userName, string password, string eMailAddress, string role) :
            base(userId, firstName, lastName, userName, password, eMailAddress, role)
        {

        }
    }
}