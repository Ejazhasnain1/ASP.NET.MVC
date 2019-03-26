using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MindfireSolutions.ViewModel;
using MindfireSolutions.Models;
using System.Data.Entity;

namespace MindfireSolutions.CRUD_Functionality
{
    public class Read
    {
        MindfireDbContext dbReference = new MindfireDbContext();
        public MindfireEmployeeDetails ReadData(string emailId)
        {
            var getEmployeeDetails = dbReference.GetEmployeeDetails.Where(m => m.Email == emailId).SingleOrDefault();
            var getContactDetailsList = dbReference.GetContactDetails.Where(m => m.EmployeeId == getEmployeeDetails.EmployeeId).Include(m => m.ContactTypeDetails).ToList();

            MindfireEmployeeDetails employee = new MindfireEmployeeDetails();

            employee.EmployeeId = getEmployeeDetails.EmployeeId;
            employee.Firstname = getEmployeeDetails.Firstname;
            employee.Lastname = getEmployeeDetails.Lastname;
            employee.Email = getEmployeeDetails.Email;
            employee.Address = getEmployeeDetails.Address;
            employee.EmployeeImage = getEmployeeDetails.EmployeeImage;
            employee.GetEmployeeContactList = getContactDetailsList;

            return employee;
        }
    }
}