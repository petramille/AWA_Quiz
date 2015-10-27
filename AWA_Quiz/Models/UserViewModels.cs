using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWA_Quiz.Models
{
    public class UserViewModels
    {

        [DisplayName("First name")]
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string LastName { get; set; }

        [DisplayName("User name")]
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "The length of the password must be at least 5 characters")]
        public string Password { get; set; }

        [DisplayName("E-mail")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string Role { get; set; }
    }
}