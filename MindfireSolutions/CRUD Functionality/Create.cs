using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace MindfireSolutions.CRUD_Functionality
{
    public class Create
    {
        public string SaveData(MindfireEmployeeRegister obj)
        {
            MindfireDbContext dbReference = new MindfireDbContext();
            string filePath = "";

            if (obj.ImageUpload.ContentLength > 0 && obj.ImageUpload != null)
            {
                string filename = Path.GetFileName(obj.ImageUpload.FileName);
                filePath = Path.Combine("\\UploadImage\\", obj.Email + Path.GetExtension(filename));
                string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadImage"), obj.Email + Path.GetExtension(filename));
                obj.ImageUpload.SaveAs(directoryPath);
            }
            var employee = new Employee()
            {
                Firstname = obj.Firstname,
                Lastname = obj.Lastname,
                Email = obj.Email,
                Address = obj.Address,
                Password = Hash.GetHash(obj.Password),
                EmployeeImage = filePath,
            };

            dbReference.GetEmployeeDetails.Add(employee);
       
            for (int i = 0; i < obj.UserContactList.Count(); i++)
            {
                EmployeeContact employeeContact = new EmployeeContact();
                employeeContact.ContactNumber = obj.ContactNumber[i];
                employeeContact.EmployeeId = employee.EmployeeId;
                employeeContact.ContactTypeId = (int)obj.UserContactList[i];

                dbReference.GetContactDetails.Add(employeeContact);
            }

            var accessUser = new Access()
            {
                EmployeeId = employee.EmployeeId,
                RoleId = 2
            };

            dbReference.GetAccessType.Add(accessUser);
            dbReference.SaveChanges();

            return obj.Email;

        }
    }
}