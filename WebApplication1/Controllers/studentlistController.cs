using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class studentlistController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: studentlist
        public ActionResult Index()
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
                List<studentlist> stt = getstd();
                return View(stt);
            }
        }

        // GET: studentlist/Details/5
        
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentlist std = db.studentlists.Find(id);
            if(std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // GET: studentlist/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: studentlist/Create
        [HttpPost]
        public ActionResult Create(studentlist std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.studentlists.Add(std);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(std);
            }
            catch
            {
                return View();
            }
        }

        // GET: studentlist/Edit/5
      
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentlist std = db.studentlists.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // POST: studentlist/Edit/5
        [HttpPost]
        public ActionResult Edit(studentlist std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(std).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(std);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: studentlist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentlist std = db.studentlists.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);            
        }

        // POST: studentlist/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, studentlist stdd)
        {
            try
            {
                studentlist std = db.studentlists.Find(id);
                if (ModelState.IsValid)
                {
                    if(id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    
                    if(std == null)
                    {
                        return HttpNotFound();
                    }
                    db.studentlists.Remove(std);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(std);
            }
            catch
            {
                return View();
            }
        }

        public List<studentlist> getstd()
        {
            int sem = Convert.ToInt32(Session["sem"]);
            var std = new List<studentlist>();
            using (var adv = new AttendanceContext())
            {
                std = adv.Database.SqlQuery<studentlist>("exec fetchstdid @sem", new SqlParameter("@sem", sem)).ToList();
            }
            return std;
        }
    }
}
