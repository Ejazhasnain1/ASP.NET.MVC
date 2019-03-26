using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindfireSolutions.ViewModel
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage = "*Please Enter your Email-Id ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Please Enter your Password ")]
        public string Password { get; set; }

    }
}