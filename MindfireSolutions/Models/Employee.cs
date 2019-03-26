using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class Employee
    {
        [Column(Order =0)]
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Column(Order = 1)]
        public string Firstname { get; set; }

        [Required]
        [Column(Order = 2)]
        public string Lastname { get; set; }

        [Required]
        [Column(Order = 3)]
        public string Email { get; set; }

        [Required]
        [Column(Order = 4)]
        public string Password { get; set; }


        [Required]
        [Column(Order=6)]
        public string EmployeeImage { get; set; }

        [Required]
        [Column(Order = 5)]
        public string Address { get; set; }

       

    }
}