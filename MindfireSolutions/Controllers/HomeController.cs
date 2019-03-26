using MindfireSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    public class HomeController : Controller
    {
        MindfireDbContext reference = new MindfireDbContext();
        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var value = reference.GetEmployeeDetails.Where(m => m.Email.Equals(email)).SingleOrDefault();
                var accessRole = reference.GetAccessType.Where(m => m.EmployeeId == value.EmployeeId).SingleOrDefault();
                if (accessRole.RoleId == 2)
                {
                    return RedirectToAction("DisplayUserDetails", "Details");
                }
                else
                {
                    return RedirectToAction("AdminDetails", "Admin");
                }
            }
            return View();
        }      
    }
}