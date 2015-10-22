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
        [MinLength(5, ErrorMessage = "The length of the password must be at least 5 characters")]
        public string Password { get; set; }

        [DisplayName("E-mail")]
        [Required]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "The e-mail address is not valid")]
        public string EMailAddress { get; set; }

        public string Role { get; set; }
    }
}