using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult admin()
        {

            if( Session["id"] == null)
            {               
                return RedirectToAction("login", "login");
            }
            else
            {
                var id = Session["id"];
                var name = Session["name"];
                return View();
            }
        }

        [HttpGet]
        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon(); 
            return RedirectToAction("login", "login");
        }

        public ActionResult reset()
        {
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<admin>("exec resetsem ").ToList();
            }
            return RedirectToAction("admin", "admin");
        }

        public ActionResult updatestudentsem()
        {
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<admin>("exec updatestudentsem").ToList();
            }
            return RedirectToAction("admin", "admin");
        }
    }
}