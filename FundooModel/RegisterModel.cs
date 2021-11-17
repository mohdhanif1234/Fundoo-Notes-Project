using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(" ", ErrorMessage = "E-mail is not valid. Please Enter valid email")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
