using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class advisorController : Controller
    {
        // GET: advisor
        public ActionResult advisor()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("login", "login");
            }
            else
            {
                var id = Session["id"];
                var name = Session["name"];
                var sem = Session["sem"];
                return View();
            }
        }

        public ActionResult generatedefaulter()
        {
            int sem = Convert.ToInt32(Session["sem"]);
            string year = Convert.ToString(Session["year"]);
            using (var adv = new AttendanceContext())
            {
                var advi = adv.Database.SqlQuery<advisor>("exec generatedefaulter @sem, @year", new SqlParameter("@sem", sem), new SqlParameter("@year", year)).ToList();
            }
            return RedirectToAction("advisor", "advisor");
        }
    }
}