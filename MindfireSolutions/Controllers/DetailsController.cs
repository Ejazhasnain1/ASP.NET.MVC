using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System.Data.Entity;
using MindfireSolutions.CRUD_Functionality;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        MindfireDbContext reference = new MindfireDbContext();
        // GET: Details
        public ActionResult DisplayUserDetails()
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var employee = new Read().ReadData(email);
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserDetails(EditEmployeeDetails emp)
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new Edit().EditDetails(email, emp);
                return Json(new { success = true, }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }
    }
}
