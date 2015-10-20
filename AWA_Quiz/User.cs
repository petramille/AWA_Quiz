using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWA_Quiz
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMailAddress { get; set; }
        public string Role { get; set; }

        public User(int userId, string firstName, string lastName, string userName, string password, string eMailAddress, string role)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            EMailAddress = eMailAddress;
            Role = role;
        }
    }
}