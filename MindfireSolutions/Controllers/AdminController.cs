using MindfireSolutions.CRUD_Functionality;
using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        MindfireDbContext dbreference = new MindfireDbContext();
        // GET: Admin
        [Authorize]
        public ActionResult AdminDetails()
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var employee = new Read().ReadData(email);
            return View(employee);
        }

        //ActionMethod to return Employee object to Ajax call
        [HttpGet]
        public ActionResult EditUsersDetails(int id)
        {
            var employee = dbreference.GetEmployeeDetails.Where(m => m.EmployeeId == id).SingleOrDefault();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(EditEmployeeDetails emp)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var employee = dbreference.GetEmployeeDetails.Where(m => m.EmployeeId == emp.EmployeeId).SingleOrDefault();
                new Edit().EditDetails(employee.Email, emp);
                return Json(new { success = true, }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UserDetails()
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var emp = dbreference.GetEmployeeDetails.Where(m => m.Email != email).ToList();
            return View(emp);
        }

        public ActionResult ViewUserDetails(int userId)
        {
            var getEmployeeDetails = dbreference.GetEmployeeDetails.Where(m => m.EmployeeId == userId).SingleOrDefault();
            var employee = new Read().ReadData(getEmployeeDetails.Email);
            return View(employee);
        }

        [HttpGet]
        public ActionResult DeleteUser(int userId)
        {
            var getEmployeeDetails = dbreference.GetEmployeeDetails.Single(m => m.EmployeeId == userId);
            dbreference.GetEmployeeDetails.Remove(getEmployeeDetails);
            dbreference.SaveChanges();
            return RedirectToAction("UserDetails", "Admin");
        }
    }
}