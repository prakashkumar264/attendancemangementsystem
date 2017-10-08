using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Context;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.Controllers
{
    public class updateadvisorController : Controller
    {
        // GET: updateadvisor
        public ActionResult updateadvisor()
        {            
            if (Session["id"] == null)
            {
                return RedirectToAction("login", "login");
            }
            else
            {
                var id = Session["id"];
                var name = Session["name"];
                updateadvisor update = new updateadvisor();
                update.selectadvisor = getteachers();
                update.selectSE = getSE();
                update.selectTE = getTE();
                update.selectBE = getBE();
                return View(update);
            }
        }

        
        [HttpPost]
        public ActionResult updaterole(updateadvisor updatemodel, FormCollection formcollection)
        {
            using (var up = new AttendanceContext())
            {
                var tid = new SqlParameter("@id", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.teacher
                };
                var tid2 = new SqlParameter("@id2", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.teacher2
                };
                var tid3 = new SqlParameter("@id3", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.teacher3
                };
                var se = new SqlParameter("@se", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.SE                    
                };
                var te = new SqlParameter("@te", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.TE
                };
                var be = new SqlParameter("@be", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = updatemodel.BE
                };

       
                var update = up.Database.SqlQuery<updateadvisor>("exec updaterole @id , @id2, @id3, @se, @te, @be", tid,tid2,tid3,se,te,be).ToList();
            }

            TempData["updateclsadvmsg"] = "<script>alert('Class Advisor Updated Successfully');</script>";
            return RedirectToAction("admin", "admin");
        }


        public List<chooseadvisor> getteachers()
        {
            var advisor = new List<chooseadvisor>();
            using (var adv = new AttendanceContext())
            {
              advisor = adv.Database.SqlQuery<chooseadvisor>("exec fetchteacher").ToList();
            }
            return advisor;
        }

        public List<chooseSE> getSE()
        {
            var se = new List<chooseSE>();
            using (var adv = new AttendanceContext())
            {
                se = adv.Database.SqlQuery<chooseSE>("exec fetchsem SE").ToList();
            }
            return se;
        }
        public List<chooseTE> getTE()
        {
            var te = new List<chooseTE>();
            using (var adv = new AttendanceContext())
            {
                te = adv.Database.SqlQuery<chooseTE>("exec fetchsem TE").ToList();
            }
            return te;
        }
        public List<chooseBE> getBE()
        {
            var be = new List<chooseBE>();
            using (var adv = new AttendanceContext())
            {
                be = adv.Database.SqlQuery<chooseBE>("exec fetchsem BE").ToList();
            }
            return be;
        }


    }
}