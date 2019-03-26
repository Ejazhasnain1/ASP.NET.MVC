using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class Access
    {
        [Column(Order = 0)]
        [Key]
        public int AccessId { get; set; }

        [Column(Order = 1)]
        [ForeignKey(nameof(EmployeeUserDetails))]
        public int EmployeeId { get; set; }

        public Employee EmployeeUserDetails { get; set; }

        [Column(Order = 2)]
        [ForeignKey("RoleDetails")]
        public int RoleId { get; set; }

        public Role RoleDetails { get; set; }

    }
}




