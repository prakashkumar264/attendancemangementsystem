using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class logoutController : Controller
    {
        // GET: logout
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("login", "login");
        }
    }
}