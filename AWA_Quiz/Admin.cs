using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class Admin : User
    {
        public Admin (string firstName, string lastName, string userName, string password, string eMailAddress, string role) : 
            base(firstName, lastName, userName, password, eMailAddress, role)
        {

        }
    }
}