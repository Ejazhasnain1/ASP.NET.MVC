using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class EmployeeContact
    {
        [Column(Order =0)]
        [Key]
        public int ContactId { get; set; }


        
        [Column(Order = 2)]
        public string ContactNumber { get; set; }



        [Column(Order = 3)]
        [ForeignKey("ContactTypeDetails")]
        public int ContactTypeId { get; set; }

        public ContactType ContactTypeDetails { get; set; }



        [Column(Order = 1)]
        [ForeignKey("EmployeeDetails")]        
        public int EmployeeId { get; set; }

        public Employee EmployeeDetails { get; set; }

       

      
    }
}

