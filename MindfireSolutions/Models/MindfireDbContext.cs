using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class MindfireDbContext :DbContext
    {
        public MindfireDbContext() :base("MindfireSolutionsDb")
        {
        }
        public DbSet<Employee> GetEmployeeDetails { get; set; }
        public DbSet<EmployeeContact> GetContactDetails { get; set; }
        public DbSet<ContactType> GetContactType { get; set; }
        public DbSet<Role> GetRoleType { get; set; }
        public DbSet<Access> GetAccessType { get; set; }
    }
}


