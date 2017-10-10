using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class attendancelistController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: attendancelist
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
                stdlisttheory update = new stdlisttheory();                
                update.attend = gettheorystd();
                update.theorysubject = gettheorysub();
                return View(update);
            }
        }

        [HttpPost]
        public ActionResult Index(stdlisttheory stdlst)
        {
            
            var insertattendance = new List<stdlisttheory>();
            int id = Convert.ToInt32(TempData["id"]);
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubsemfromid @id", new SqlParameter("@id", id)).ToList();
                TempData["semtest"] = advisor[0].sem;
            }
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubnameforlist @id", new SqlParameter("@id", id)).ToList();
                Session["subname2"] = advisor[0].name;
            }
            string subjectnamet = Convert.ToString(Session["subname2"]);
            int semt = Convert.ToInt32(TempData["semtest"]);
            StringBuilder sb = new StringBuilder();
            string testt = subjectnamet + " th";
            string stdnamet = "Total";
            using (var adv = new AttendanceContext())
            {
                var sem = new SqlParameter("@sem", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = semt
                };    
                var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = 1
                };
                var subjectname = new SqlParameter("@subjectname", SqlDbType.VarChar, 500)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = testt
                };
                var stdname = new SqlParameter("@stdname", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = stdnamet
                };
                insertattendance = adv.Database.SqlQuery<stdlisttheory>("exec inserttheoryattendancesubject  @sem, @IsCheck , @subjectname ,@stdname",  sem, IsCheck,subjectname, stdname).ToList();
            }
            foreach (var item in stdlst.attend)
            {
             
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
                      
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                        var subjectname = new SqlParameter("@subjectname", SqlDbType.VarChar, 100)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = subjectnamet
                        };
                        var test = new SqlParameter("@test", SqlDbType.VarChar, 100)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = testt
                        };
                        insertattendance = adv.Database.SqlQuery<stdlisttheory>("exec inserttheoryattendance @stdrollno, @sem,  @IsCheck ,@subjectname, @test ", stdrollno, sem, IsCheck, subjectname, test).ToList();
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
                        var subjectname = new SqlParameter("@subjectname", SqlDbType.VarChar, 500)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = subjectnamet
                        };
                        var test = new SqlParameter("@test", SqlDbType.VarChar, 500)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = testt
                        };
                        var IsCheck = new SqlParameter("@IsCheck", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = IsCheckt
                        };
                        insertattendance = adv.Database.SqlQuery<stdlisttheory>("exec inserttheoryattendance @stdrollno, @sem, @subjectname, @IsCheck, @test", stdrollno, sem, subjectname, IsCheck ,test).ToList();
                    }
                }
            }

            return RedirectToAction("Details","attendancelist");

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
                stdlisttheory update = new stdlisttheory();
                update.attendd = getliststd();
                update.theorysubject = gettheorysub();
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
                stdlisttheory update = new stdlisttheory();
                update.attendd = getliststd();
                update.theorysubject = gettheorysub();
                return View(update);
            }
        }

        [HttpPost]
        public ActionResult Edit(stdlisttheory stdlst)
        {
            var insertattendance = new List<stdlisttheory>();                       
            StringBuilder sb = new StringBuilder();
            int id = Convert.ToInt32(TempData["id"]);
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubsemfromid @id", new SqlParameter("@id", id)).ToList();
                TempData["semtest"] = advisor[0].sem;
            }
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubnameforlist @id", new SqlParameter("@id", id)).ToList();
                Session["subname2"] = advisor[0].name;
            }
            string subjectnamet = Convert.ToString(Session["subname2"]);
            int semt = Convert.ToInt32(TempData["semtest"]);
            string modifiedont = Convert.ToString(Session["prak"]);
            string testt = subjectnamet + " th";
            foreach (var item in stdlst.attendd)
            {
                int stdrollnot = item.stdrollno;
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
                        var test = new SqlParameter("@test", SqlDbType.VarChar, 250)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = testt
                        };
                        insertattendance = adv.Database.SqlQuery<stdlisttheory>("exec updatetheoryattendance @stdrollno, @IsCheck , @modifiedon ,@test ,@sem", stdrollno, IsCheck , modifiedon,test,sem).ToList();
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
                        var test = new SqlParameter("@test", SqlDbType.VarChar, 250)
                        {
                            Direction = System.Data.ParameterDirection.Input,
                            Value = testt
                        };
                        insertattendance = adv.Database.SqlQuery<stdlisttheory>("exec updatetheoryattendance @stdrollno, @IsCheck , @modifiedon ,@test ,@sem", stdrollno, IsCheck ,modifiedon,test,sem).ToList();
                    }
                }
            }

            return RedirectToAction("Details","attendancelist");
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
                stdlisttheory update = new stdlisttheory();
                update.totalattend = gettotalstd();
                update.totalroll = gettotalroll();
                update.theorysubject = gettheorysub();
                return View(update);
            }
        }

        public List<fetchsubthoerysubjectforselect> gettheorysub()
        {
            int teacherid = Convert.ToInt32(Session["id"]);
            var advisor = new List<fetchsubthoerysubjectforselect>();
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<fetchsubthoerysubjectforselect>("exec attendfetchtheorysub @teacherid", new SqlParameter("@teacherid", teacherid)).ToList();
      
            }
            return advisor;
        }

        //New
        public List<attendancelist> gettheorystd()
        {
            var advisor = new List<attendancelist>();
            int sem = Convert.ToInt32(TempData["sem"]);
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<attendancelist>("exec studentfetchtheory @sem", new SqlParameter("@sem", sem)).ToList();
            }
            return advisor;
        }

        //New
        [HttpPost]
        public ActionResult test(stdlisttheory aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.subid
                };
            }
            TempData["id"] = aa.subid;
            return RedirectToAction("testdemo", "attendancelist");
        }

        //New
        public ActionResult testdemo(stdlisttheory aa)
        {
            int id = Convert.ToInt32(TempData["id"]);
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubsemfromid @id", new SqlParameter("@id", id)).ToList();
                TempData["sem"] = advisor[0].sem;
            }

            return RedirectToAction("Index", "attendancelist");
        }

        //Details
        public ActionResult demo(int idd)
        {
            int id = Convert.ToInt32(idd);
            TempData["as"] = id;
            Session["demo"] = TempData["as"];
            using (var adv = new AttendanceContext())
            {
                var advisor = adv.Database.SqlQuery<stdlisttheory>("exec getsubnameforlist @id", new SqlParameter("@id", id)).ToList();
                Session["subname2"] = advisor[0].name;
            }
            string subjectname = Convert.ToString(Session["subname2"]);
            var moddates = new List<getdate>();
            using (var adv = new AttendanceContext())
            {
                moddates = adv.Database.SqlQuery<getdate>("exec getmoddate @subjectname", new SqlParameter("@subjectname", subjectname)).ToList();
            }
            return Json(moddates, JsonRequestBehavior.AllowGet);
        }

        public ActionResult demo2(string idd2)
        {
            string demo2 = Convert.ToString(idd2);
            Session["demo2"] = demo2;
            string subjectname = Convert.ToString(Session["subname2"]);
            var moddates = new List<getdate>();
            using (var adv = new AttendanceContext())
            {
                moddates = adv.Database.SqlQuery<getdate>("exec getmoddate @subjectname", new SqlParameter("@subjectname", subjectname)).ToList();
            }
            return Json(moddates, JsonRequestBehavior.AllowGet);
        }

     
        //Details
        public ActionResult getlist(stdlisttheory aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.modifiedon
                };
            }
            TempData["moddate"] = aa.modifiedon;
            return RedirectToAction("Details", "attendancelist");
        }

        //Details
        public List<attendancelisttt> getliststd()
        {
            var advisor = new List<attendancelisttt>();
            string modifiedon = Convert.ToString(TempData["moddate"]);
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<attendancelisttt>("exec getstudentmoddate @modifiedon" , new SqlParameter("@modifiedon" , modifiedon)).ToList();
            }
            return advisor;
        }

        //Edit
        public ActionResult getlistedit(stdlisttheory aa, FormCollection form)
        {
            using (var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = aa.modifiedon
                };
            }
            TempData["moddate"] = aa.modifiedon;
            Session["prak"] = aa.modifiedon;
            return RedirectToAction("Edit", "attendancelist");
        }

        public ActionResult gettotal(stdlisttheory aa, FormCollection form)
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
            return RedirectToAction("total", "attendancelist");
        }

        public List<totalattendacelistcount> gettotalstd()
        {
            var advisor = new List<totalattendacelistcount>();
            string subjectname = Convert.ToString(Session["subname2"]);
            string modifiedon1 = Convert.ToString(Session["demo2"]);
            string modifiedon2 = Convert.ToString(Session["secondmoddate"]);

            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<totalattendacelistcount>("exec gettotaltheoryattendance @subjectname , @modifiedon1, @modifiedon2", new SqlParameter("@subjectname", subjectname), new SqlParameter("@modifiedon1", modifiedon1), new SqlParameter("@modifiedon2", modifiedon2)).ToList();
            }
            return advisor;
        }

        public List<totalattendacelistrollno> gettotalroll()
        {
            var advisor = new List<totalattendacelistrollno>();
            string subjectname = Convert.ToString(Session["subname2"]);
       
            using (var adv = new AttendanceContext())
            {
                advisor = adv.Database.SqlQuery<totalattendacelistrollno>("exec gettotaltheoryattendancerollno @subjectname ", new SqlParameter("@subjectname", subjectname)).ToList();
            }
            return advisor;
        }

    }
}