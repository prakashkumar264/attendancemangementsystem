using System;
using System.Collections.Generic;
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
    public class assignteacherController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        public int tempvar;
        public int count = 0;
        // GET: assignteacher
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
                List<assignteacher> stt = getsubteach();
                return View(stt);
            }
        }

        // GET: assignteacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: assignteacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: assignteacher/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,sem,year,mode")] subjectlist subjectlist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.subjectlists.Add(subjectlist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(subjectlist);
            }
            catch
            {
                return View();
            }
        }

        // GET: assignteacher/Edit/5
        public ActionResult Edit(int? id)

        {
            subjectlist assgn = new subjectlist();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assgn = db.subjectlists.Find(id);
            if (assgn == null)
            {
                return HttpNotFound();
            }
            
            assgn.selectadvisor = getteachers();           
            return View(assgn);
        }

        // POST: assignteacher/Edit/5
        [HttpPost]
        public ActionResult Edit(subjectlist subteach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(subteach).State = System.Data.Entity.EntityState.Modified;
                    tempvar = Convert.ToInt32(subteach.teacherid);
                    TempData["techid"] = tempvar;
                    
                    db.Entry(subteach).Property(x => x.sem).IsModified = false;                    
                    db.Entry(subteach).Property(x => x.year).IsModified = false;
                                    
                    db.SaveChanges();     
                    return RedirectToAction("Index" , "assignteacher" ,   TempData["techid"] );
                }              
                return View(subteach);
            }
            catch
            {
                return View();
            }
        }

        // GET: assignteacher/Delete/5
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

        // POST: assignteacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                subjectlist subjectlist = db.subjectlists.Find(id);
                db.subjectlists.Remove(subjectlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<assignteacher> getsubteach()
        {
            //int sem = Convert.ToInt32(Session["sem"]);
            var teachers = new List<assignteacher>();
            using (var adv = new AttendanceContext())
            {
                teachers = adv.Database.SqlQuery<assignteacher>("exec assgnteacher").ToList();
            }
            return teachers;
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


        public List<namteach> nameteacher()
        {
            int xxx = Convert.ToInt32(TempData["techid"]);
            var advisor = new List<namteach>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<namteach>("exec nameteacher @id", new SqlParameter("@id", xxx)).ToList();
            }
            return null;
        }
    }
}