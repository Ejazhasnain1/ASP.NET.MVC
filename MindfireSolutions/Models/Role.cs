using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RolePosition { get; set; }
    }
}