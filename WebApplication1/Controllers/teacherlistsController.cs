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
    public class teacherlistsController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: teacherlists
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
                return View(db.teacherlists.ToList());
            }           
        }

        // GET: teacherlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacherlist teacherlist = db.teacherlists.Find(id);
            if (teacherlist == null)
            {
                return HttpNotFound();
            }
            return View(teacherlist);
        }

        // GET: teacherlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teacherlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,uniqid,roleid")] teacherlist teacherlist)
        {
            if (ModelState.IsValid)
            {
                db.teacherlists.Add(teacherlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherlist);
        }

        // GET: teacherlists/Edit/5
        public ActionResult Edit(int? id)
        {
            teacherlist reg = new teacherlist();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg = db.teacherlists.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            reg.roles = getroles();
            reg.sem = getBE();
            reg.year2 = getyear();
            return View(reg);
        }

        // POST: teacherlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,uniqid,roleid,semid,year")] teacherlist teacherlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherlist);
        }

        // GET: teacherlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacherlist teacherlist = db.teacherlists.Find(id);
            if (teacherlist == null)
            {
                return HttpNotFound();
            }
            return View(teacherlist);
        }

        // POST: teacherlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacherlist teacherlist = db.teacherlists.Find(id);
            db.teacherlists.Remove(teacherlist);
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


        public List<fillrole> getroles()
        {
            var role = new List<fillrole>();
            using (var reg = new AttendanceContext())
            {
                role = reg.Database.SqlQuery<fillrole>("exec fetchrole").ToList();
            }
            return role;
        }

        public List<choosesemteacher> getBE()
        {
            var be = new List<choosesemteacher>();
            using (var adv = new AttendanceContext())
            {
                be = adv.Database.SqlQuery<choosesemteacher>("exec fetchsubjectsem ").ToList();
            }
            return be;
        }

        public List<chooseyearteacher> getyear()
        {
            var be = new List<chooseyearteacher>();
            using (var adv = new AttendanceContext())
            {
                be = adv.Database.SqlQuery<chooseyearteacher>("exec fetchsubjectyear ").ToList();
            }
            return be;
        }

    }
}
