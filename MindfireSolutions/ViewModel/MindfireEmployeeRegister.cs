using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
using MindfireSolutions.CustomHelper;

namespace MindfireSolutions.ViewModel
{
    public class MindfireEmployeeRegister
    {

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


        [Required(ErrorMessage = "*Please Enter your Email-Id ")]
        [EmailAddress(ErrorMessage = "*Please Enter correct Email-Id")]
        public string Email { get; set; }




        [Required(ErrorMessage = "*Please Upload Your Image File ")]
        [FileSize(512000)]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }


        [Required(ErrorMessage = "*Please Enter Your address ")]
        [MinLength(5, ErrorMessage = "*Minimum length should be 5")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*Please Enter Your Contact ")]
        public string[] ContactNumber { get; set; }


        [Required(ErrorMessage = "*Please Enter your Password ")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$#!%*?&]{8,}$", ErrorMessage = "Password should contain atleast one uppercase+lowercase+digit+special character respectively")]
        public string Password { get; set; }


        [Required(ErrorMessage = "*Please Enter your Password ")]
        [Compare("Password", ErrorMessage = "*Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public ContactList[] UserContactList { get; set; }


    }
    public enum ContactList
    {
        Mobile = 1,
        Fax,
        Home,
        Office,
        Landline
    }
}
