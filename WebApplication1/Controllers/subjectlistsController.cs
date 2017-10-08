using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;
using System.Collections;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class subjectlistsController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: subjectlists
        public ActionResult Index()
        {
           
            return View(db.subjectlists.ToList());
        }

        // GET: subjectlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subjectlist subjectlist = db.subjectlists.Find(id);
            if (subjectlist == null)
            {
                return HttpNotFound();
            }
            return View(subjectlist);
        }

        // GET: subjectlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subjectlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,sem,year")] subjectlist subjectlist)
        {
            if (ModelState.IsValid)
            {
                db.subjectlists.Add(subjectlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjectlist);
        }

        // GET: subjectlists/Edit/5
        public ActionResult Edit(int? id)
        {
            subjectlist semyear = new subjectlist();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semyear = db.subjectlists.Find(id);
            if (semyear == null)
            {
                return HttpNotFound();
            }
          
            semyear.selectsem = getsem();
            semyear.selectyear = getyear();
           
            semyear.selectadvisor = getteachers();
            return View(semyear);
        }

        // POST: subjectlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sem,year")] subjectlist subjectlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjectlist);
        }

        // GET: subjectlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subjectlist subjectlist = db.subjectlists.Find(id);
            if (subjectlist == null)
            {
                return HttpNotFound();
            }
            return View(subjectlist);
        }

        // POST: subjectlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subjectlist subjectlist = db.subjectlists.Find(id);
            db.subjectlists.Remove(subjectlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<subjectsem> getsem()
        {
            var sem = new List<subjectsem>();
            using (var reg = new AttendanceContext())
            {
                sem = reg.Database.SqlQuery<subjectsem>("exec fetchsubjectsem").ToList();
            }
            return sem;
        }

        public List<subjectyear> getyear()
        {
            var year = new List<subjectyear>();
            using (var reg = new AttendanceContext())
            {
                year = reg.Database.SqlQuery<subjectyear>("exec fetchsubjectyear").ToList();
            }
            return year;
        }

      

        public List<assgnsubteacher> getteachers()
        {
            var advisor = new List<assgnsubteacher>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<assgnsubteacher>("exec fetchteacher").ToList();
            }
            return advisor;
        }

    }
}
