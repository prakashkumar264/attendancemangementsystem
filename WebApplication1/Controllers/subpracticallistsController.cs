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

namespace WebApplication1.Controllers
{
    public class subpracticallistsController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: subpracticallists
        public ActionResult Index()
        {
            return View(db.subpracticallists.ToList());
        }

        // GET: subpracticallists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subpracticallist subpracticallist = db.subpracticallists.Find(id);
            if (subpracticallist == null)
            {
                return HttpNotFound();
            }
            return View(subpracticallist);
        }

        // GET: subpracticallists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subpracticallists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,sem,year,batch")] subpracticallist subpracticallist)
        {
            if (ModelState.IsValid)
            {
                db.subpracticallists.Add(subpracticallist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subpracticallist);
        }

        // GET: subpracticallists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subpracticallist subpracticallist = new subpracticallist();
            subpracticallist = db.subpracticallists.Find(id);
            subpracticallist.selectpracsem = getsem();
            subpracticallist.selectpracyear = getyear();
            if (subpracticallist == null)
            {
                return HttpNotFound();
            }
            return View(subpracticallist);
        }

        // POST: subpracticallists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sem,year,batch")] subpracticallist subpracticallist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subpracticallist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subpracticallist);
        }

        // GET: subpracticallists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subpracticallist subpracticallist = db.subpracticallists.Find(id);
            if (subpracticallist == null)
            {
                return HttpNotFound();
            }
            return View(subpracticallist);
        }

        // POST: subpracticallists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subpracticallist subpracticallist = db.subpracticallists.Find(id);
            db.subpracticallists.Remove(subpracticallist);
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

        public List<subjectpracticalsem> getsem()
        {
            var sem = new List<subjectpracticalsem>();
            using (var reg = new AttendanceContext())
            {
                sem = reg.Database.SqlQuery<subjectpracticalsem>("exec fetchsubjectsem").ToList();
            }
            return sem;
        }

        public List<subjectpracticalyear> getyear()
        {
            var year = new List<subjectpracticalyear>();
            using (var reg = new AttendanceContext())
            {
                year = reg.Database.SqlQuery<subjectpracticalyear>("exec fetchsubjectyear").ToList();
            }
            return year;
        }

      
    }
}
