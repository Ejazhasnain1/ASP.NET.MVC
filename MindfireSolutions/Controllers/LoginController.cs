using MindfireSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MindfireSolutions.ViewModel;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    public class LoginController : Controller
    {
        MindfireDbContext reference = new MindfireDbContext();
        // GET: Login
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(EmployeeLogin emp)
        {
            if (ModelState.IsValid)
            {
                string localPassword = Hash.GetHash(emp.Password);
                var value = reference.GetEmployeeDetails.Where(m => m.Email.Equals(emp.Email) && m.Password.Equals(localPassword)).SingleOrDefault();
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(emp.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "*Invalid Username or Password";
                    return RedirectToAction("LoginUser");
                }
            }
            return View("LoginUser");
        }
           
     }
}
