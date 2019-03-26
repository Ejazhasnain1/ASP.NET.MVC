using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MindfireSolutions.Models;
using System.ComponentModel.DataAnnotations;

namespace MindfireSolutions.ViewModel
{
    public class MindfireEmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmployeeImage { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<EmployeeContact> GetEmployeeContactList { get; set; }
    }
}