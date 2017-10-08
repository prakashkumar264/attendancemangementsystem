using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class practicalattendancelistController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        [HttpGet]
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
                stdlistpractical update = new stdlistpractical();
                update.attend = getpracstd();
                update.practicalsubject = getpracticalsub();
                return View(update);
            }
        }

        [HttpPost]
        public ActionResult Index(stdlistpractical stdlst)
        {

            var insertattendance = new List<stdlistpractical>();
            string name = Convert.ToString(Session["subname2"]);
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlistpractical>("exec fetchsubjectsembyname @name", new SqlParameter("@name", name)).ToList();
                TempData["sem2"] = advisor[0].sem;
            }
            int semt = Convert.ToInt32(TempData["sem2"]);
            string batcht = Convert.ToString(Session["currentbatch"]);
            StringBuilder sb = new StringBuilder();
            foreach (var item in stdlst.attend)
            {
                string subjectnamet  = Convert.ToString(Session["subname2"]);
                int stdrollnot = item.rollno;
                if (item.IsCheck)
                {
                    int IsCheckt = 1;
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
                        var subjectname = new SqlParameter("@subjectname", SqlDbType.VarChar, 50)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = subjectnamet
                        };
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                        var batch = new SqlParameter("@batch", SqlDbType.VarChar,5)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = batcht
                        };
                        insertattendance = adv.Database.SqlQuery<stdlistpractical>("exec insertpracticalattendance @stdrollno, @sem, @subjectname, @IsCheck,@batch", stdrollno, sem, subjectname, IsCheck,batch).ToList();
                    }
                }
                else
                {
                    int IsCheckt = 0;
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
                        var subjectname = new SqlParameter("@subjectname", SqlDbType.VarChar, 50)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = subjectnamet
                        };
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                        var batch = new SqlParameter("@batch", SqlDbType.VarChar, 5)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = batcht
                        };
                        insertattendance = adv.Database.SqlQuery<stdlistpractical>("exec insertpracticalattendance @stdrollno, @sem, @subjectname, @IsCheck,@batch", stdrollno, sem, subjectname, IsCheck, batch).ToList();
                    }
                }
            }

            return RedirectToAction("Details", "practicalattendancelist");

        }

        public ActionResult Details()
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
                stdlistpractical update = new stdlistpractical();
                update.attendddd = getliststd();
                update.practicalsubject = getpracticalsub();
                return View(update);
            }
        }

        public ActionResult Edit()
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
                stdlistpractical update = new stdlistpractical();
                update.attendddd = getliststd();
                update.practicalsubject = getpracticalsub();
                return View(update);
            }
        }

        [HttpPost]
        public ActionResult Edit(stdlistpractical stdlst)
        {
            var insertattendance = new List<stdlistpractical>();

            string modifiedont = Convert.ToString(Session["moddate"]);

            StringBuilder sb = new StringBuilder();
            foreach (var item in stdlst.attendddd)
            {
                string subjectnamet = Convert.ToString(Session["subname2"]);
                int stdrollnot = item.stdrollno;
                if (item.IsCheck)
                {
                    int IsCheckt = 1;
                    using (var adv = new AttendanceContext())
                    {
                       
                        var stdrollno = new SqlParameter("@stdrollno", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = stdrollnot
                        };
                        var modifiedon = new SqlParameter("@modifiedon", SqlDbType.VarChar, 50)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = modifiedont
                        };
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                      
                        insertattendance = adv.Database.SqlQuery<stdlistpractical>("exec updatepracticalattendance @stdrollno, @IsCheck ,@modifiedon", stdrollno, IsCheck,modifiedon ).ToList();
                    }
                }
                else
                {
                    int IsCheckt = 0;
                    using (var adv = new AttendanceContext())
                    {
                        var stdrollno = new SqlParameter("@stdrollno", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = stdrollnot
                        };
                        var modifiedon = new SqlParameter("@modifiedon", SqlDbType.VarChar, 50)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = modifiedont
                        };
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                        insertattendance = adv.Database.SqlQuery<stdlistpractical>("exec updatepracticalattendance @stdrollno, @IsCheck,@modifiedon", stdrollno,IsCheck, modifiedon).ToList();
                    }
                }
            }

            return RedirectToAction("Details", "practicalattendancelist");

        }

        [HttpGet]
        public ActionResult total()
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
                stdlistpractical update = new stdlistpractical();
                update.totalattend = gettotalstd();
                update.totalroll = gettotalroll();
                update.practicalsubject = getpracticalsub();
                return View(update);
            }
        }
        //New
        public List<fetchsubpracticalsubjectforselect> getpracticalsub()
        {
            int teacherid = Convert.ToInt32(Session["id"]);
            var advisor = new List<fetchsubpracticalsubjectforselect>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<fetchsubpracticalsubjectforselect>("exec attendfetchpracsub @teacherid", new SqlParameter("@teacherid", teacherid)).ToList();
          
            }
            return advisor;
        }

        //New
        public ActionResult getbatch(string idd)
        {
            string name = Convert.ToString(idd);
            TempData["subname"] = name;
            Session["subname2"] = TempData["subname"];
            int teacherid = Convert.ToInt32(Session["id"]);
            var batches = new List<getbatch>();
            using (var adv = new AttendanceContext())
            {
                batches = adv.Database.SqlQuery<getbatch>("exec getpracsubbatch @name, @teacherid", new SqlParameter("@name", name), new SqlParameter("@teacherid", teacherid)).ToList();
            }
            return Json(batches, JsonRequestBehavior.AllowGet);
        }

        public ActionResult submitsubname(stdlistpractical aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.batch
                };
            }
            TempData["batch"] = aa.batch;
            Session["currentbatch"] = TempData["batch"];

            return RedirectToAction("getsubsem", "practicalattendancelist");
        }

        public ActionResult getsubsem(stdlistpractical aa)
        {
            string name = Convert.ToString(Session["subname2"]);
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlistpractical>("exec fetchsubjectsembyname @name", new SqlParameter("@name", name)).ToList();
                TempData["sem"] = advisor[0].sem;
            }
            return RedirectToAction("Index", "practicalattendancelist");
        }

        public List<practicalattendancelist> getpracstd()
        {
            var advisor = new List<practicalattendancelist>();
            int sem = Convert.ToInt32(TempData["sem"]);
            string batch = Convert.ToString(TempData["batch"]);
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<practicalattendancelist>("exec studentfetchpractical @sem, @batch ", new SqlParameter("@sem", sem) , new SqlParameter("@batch", batch)).ToList();
            }
            return advisor;
        }

        public ActionResult demo(int idd)
        {
            
            string batch  = Convert.ToString(idd);
            Session["totalbatch"] = batch;
            string subjectname = Convert.ToString(Session["subname2"]);
            var moddates = new List<getdatepractical>();
            using (var adv = new AttendanceContext())
            {
                moddates = adv.Database.SqlQuery<getdatepractical>("exec getmoddatepractical @subjectname, @batch", new SqlParameter("@subjectname", subjectname), new SqlParameter("@batch", batch)).ToList();
            }
            return Json(moddates, JsonRequestBehavior.AllowGet);
        }

        public ActionResult demo2(string idd2)
        {
            string demo2 = Convert.ToString(idd2);
            Session["firstmoddate"] = demo2;
            string batch = Convert.ToString(Session["totalbatch"]);
            string subjectname = Convert.ToString(Session["subname2"]);
            var moddates = new List<getdatepractical>();
            using (var adv = new AttendanceContext())
            {
                moddates = adv.Database.SqlQuery<getdatepractical>("exec getmoddatepractical @subjectname, @batch", new SqlParameter("@subjectname", subjectname), new SqlParameter("@batch", batch)).ToList();
            }
            return Json(moddates, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getmoddate(stdlistpractical aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.modifiedon
                };
            }
            Session["moddate"] = aa.modifiedon;
            return RedirectToAction("Details", "practicalattendancelist");
        }

        public ActionResult getmoddate2(stdlistpractical aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.modifiedon
                };
            }
            Session["moddate"] = aa.modifiedon;
            return RedirectToAction("Edit", "practicalattendancelist");
        }

        public List<attendancelistpractical> getliststd()
        {
            var advisor = new List<attendancelistpractical>();
            string modifiedon = Convert.ToString(Session["moddate"]);
            
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<attendancelistpractical>("exec getstudentmoddatepractical @modifiedon", new SqlParameter("@modifiedon", modifiedon)).ToList();
            }
            return advisor;
        }


        public ActionResult gettotal(stdlistpractical aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var modifiedon2 = new SqlParameter("@modifiedon2", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.modifiedon2
                };
            }
            Session["secondmoddate"] = aa.modifiedon2;
            return RedirectToAction("total", "practicalattendancelist");
        }

        public List<totalpracticalattendacelistcount> gettotalstd()
        {
            var advisor = new List<totalpracticalattendacelistcount>();
            string subjectname = Convert.ToString(Session["subname2"]);
            string batch = Convert.ToString(Session["totalbatch"]);
            string modifiedon1 = Convert.ToString(Session["firstmoddate"]);
            string modifiedon2 = Convert.ToString(Session["secondmoddate"]);
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<totalpracticalattendacelistcount>("exec gettotalpracticalattendance @subjectname, @batch , @modifiedon1, @modifiedon2", new SqlParameter("@subjectname", subjectname), new SqlParameter("@batch",batch), new SqlParameter("@modifiedon1", modifiedon1), new SqlParameter("@modifiedon2", modifiedon2)).ToList();
            }
            return advisor;
        }

        public List<totalpracticalattendacelistrollno> gettotalroll()
        {
            var advisor = new List<totalpracticalattendacelistrollno>();
            string subjectname = Convert.ToString(Session["subname2"]);
            string batch = Convert.ToString(Session["totalbatch"]);
         
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<totalpracticalattendacelistrollno>("exec gettotalpracticalattendanceroll @subjectname, @batch ", new SqlParameter("@subjectname", subjectname), new SqlParameter("@batch", batch)).ToList();
            }
            return advisor;
        }

    }
}
