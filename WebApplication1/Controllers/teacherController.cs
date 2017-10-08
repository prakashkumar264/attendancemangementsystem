using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class teacherController : Controller
    {
        // GET: teacher
        public ActionResult teacher()
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
    }
}