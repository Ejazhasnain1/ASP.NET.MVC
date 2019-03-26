using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindfireSolutions.ViewModel
{
    public class EditEmployeeDetails
    {
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "*Please Enter your Firstname")]
        [MinLength(2, ErrorMessage = "*Minimum length should be 2")]
        [MaxLength(19, ErrorMessage = "*Maximum length should be 20")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "*Only Alphabets are allowed")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "*Please Enter your Lastname ")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = " *Only Alphabets are allowed")]
        [MinLength(2, ErrorMessage = "*Minimum length should be 2")]
        [MaxLength(20, ErrorMessage = "*Maximum length should be 20")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "*Please Enter Your address ")]
        [MinLength(5, ErrorMessage = "*Minimum length should be 5")]
        public string Address { get; set; }
    }
}