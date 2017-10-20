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
    public class BEdefaultersController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: BEdefaulters
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
                return View(db.BEdefaulters.ToList());

            }           
        }

        // GET: BEdefaulters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BEdefaulters bEdefaulters = db.BEdefaulters.Find(id);
            if (bEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(bEdefaulters);
        }

        // GET: BEdefaulters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BEdefaulters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,stdrollno,stdname,total_theory,theory_percentage,total_practical,practical_percentage,extra_attendance,total_attendance,attendance_percentage")] BEdefaulters bEdefaulters)
        {
            if (ModelState.IsValid)
            {
                db.BEdefaulters.Add(bEdefaulters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bEdefaulters);
        }

        // GET: BEdefaulters/Edit/5
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
            BEdefaulters bEdefaulters = db.BEdefaulters.Find(id);
            if (bEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(bEdefaulters);
        }

        // POST: BEdefaulters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BEdefaulters bEdefaulters)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(bEdefaulters).State = EntityState.Modified;

                    db.SaveChanges();
                    var extra = new List<extratotal>();
                    int semt = Convert.ToInt32(Session["sem"]);
                    int stdrollnot = Convert.ToInt32(bEdefaulters.stdrollno);
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
                return View(bEdefaulters);
            }
            catch
            {
                return View();
            }
        }

        // GET: BEdefaulters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BEdefaulters bEdefaulters = db.BEdefaulters.Find(id);
            if (bEdefaulters == null)
            {
                return HttpNotFound();
            }
            return View(bEdefaulters);
        }

        // POST: BEdefaulters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BEdefaulters bEdefaulters = db.BEdefaulters.Find(id);
            db.BEdefaulters.Remove(bEdefaulters);
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
