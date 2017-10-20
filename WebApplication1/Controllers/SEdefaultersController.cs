using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SEdefaultersController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: SEdefaulters
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

                return View(db.SEdefaulters.ToList());

            }
        }

        // GET: SEdefaulters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            SEdefaulters sEdefaulters = db.SEdefaulters.Find(id);
            if (sEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(sEdefaulters);
        }

        // GET: SEdefaulters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEdefaulters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,stdrollno,stdname,total_theory,theory_percentage,total_practical,practical_percentage,extra_attendance,total_attendance,attendance_percentage")] SEdefaulters sEdefaulters)
        {
            if (ModelState.IsValid)
            {
                db.SEdefaulters.Add(sEdefaulters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEdefaulters);
        }

        // GET: SEdefaulters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            SEdefaulters sEdefaulters = db.SEdefaulters.Find(id);
            if (sEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(sEdefaulters);
        }

        // POST: SEdefaulters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SEdefaulters sEdefaulters)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(sEdefaulters).State = EntityState.Modified;

                    db.SaveChanges();
                    var extra = new List<extratotal>();
                    int semt = Convert.ToInt32(Session["sem"]);
                    int stdrollnot = Convert.ToInt32(sEdefaulters.stdrollno);
                    using (var adv = new AttendanceContext())
                    {
                        var sem = new SqlParameter("@sem", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = semt
                        };
                        var stdrollno = new SqlParameter("@stdrollno", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = stdrollnot
                        };
                        extra = adv.Database.SqlQuery<extratotal>("exec extraattendance  @stdrollno, @sem ", stdrollno, sem).ToList();
                    }
                    return RedirectToAction("Index");
                }
                return View(sEdefaulters);
            }
            catch
            {
                return View();
            }
        }

        // GET: SEdefaulters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEdefaulters sEdefaulters = db.SEdefaulters.Find(id);
            if (sEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(sEdefaulters);
        }

        // POST: SEdefaulters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEdefaulters sEdefaulters = db.SEdefaulters.Find(id);
            db.SEdefaulters.Remove(sEdefaulters);
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
    }
}
