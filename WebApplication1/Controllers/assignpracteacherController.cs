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
    public class assignpracteacherController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        public int tempvar;
        public int count = 0;

        // GET: assignpracteacher
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
                nameteacher();
                List<assignpracteacher> stt = getsubteach();
                return View(stt);
            }
        }

        // GET: assignpracteacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: assignpracteacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: assignpracteacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: assignpracteacher/Edit/5
        public ActionResult Edit(int? id)
        {
            subpracticallist assgn = new subpracticallist();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assgn = db.subpracticallists.Find(id);
            if (assgn == null)
            {
                return HttpNotFound();
            }
            assgn.selectadvisor = getpracteachers();
            return View(assgn);
        }

        // POST: assignpracteacher/Edit/5
        [HttpPost]
        public ActionResult Edit(subpracticallist subteach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(subteach).State = System.Data.Entity.EntityState.Modified;
                    tempvar = Convert.ToInt32(subteach.teacherid);
                    TempData["techid"] = tempvar;
                    db.Entry(subteach).Property(x => x.batch).IsModified = false;
                    db.Entry(subteach).Property(x => x.sem).IsModified = false;
                    db.Entry(subteach).Property(x => x.year).IsModified = false;

                    db.SaveChanges();
                    return RedirectToAction("Index", "assignpracteacher", TempData["techid"]);
                }
                return View(subteach);
            }
            catch
            {
                return View();
            }
        }

        // GET: assignpracteacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subpracticallist subjectlist = db.subpracticallists.Find(id);
            if (subjectlist == null)
            {
                return HttpNotFound();
            }
            return View(subjectlist);
        }

        // POST: assignpracteacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                subpracticallist subjectlist = db.subpracticallists.Find(id);
                db.subpracticallists.Remove(subjectlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<assignpracteacher> getsubteach()
        {
            //int sem = Convert.ToInt32(Session["sem"]);
            var teachers = new List<assignpracteacher>();
            using (var adv = new AttendanceContext())
            {
                teachers = adv.Database.SqlQuery<assignpracteacher>("exec assgnpracteacher ").ToList();
            }
            return teachers;
        }

        public List<nampracteach> nameteacher()
        {
            int xxx = Convert.ToInt32(TempData["techid"]);
            var advisor = new List<nampracteach>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<nampracteach>("exec namepracteacher @id", new SqlParameter("@id", xxx)).ToList();
            }
            return null;
        }

        public List<assgnsubpracteacher> getpracteachers ()
        {
            var advisor = new List<assgnsubpracteacher>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<assgnsubpracteacher>("exec fetchteacher").ToList();

            }
            return advisor;
        }
    }
}
