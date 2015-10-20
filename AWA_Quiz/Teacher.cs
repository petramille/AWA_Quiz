using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Teacher : User
    {
        public Teacher(int userId, string firstName, string lastName, string userName, string password, string eMailAddress, string role) :
            base(userId, firstName, lastName, userName, password, eMailAddress, role)
        {

        }
    }
}