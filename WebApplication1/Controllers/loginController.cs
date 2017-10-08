using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Context;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;



namespace WebApplication1.Controllers
{
    public class loginController : Controller
    {
        SaltEncryption salt = new SaltEncryption();

        // GET: login
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult teacherlogin(login loginmodel, FormCollection formcollection)
        {
            string pass = salt.ComputeHash(loginmodel.pass, "SHA512", null);

            using (var log = new AttendanceContext())
            {
                var uniqid = new SqlParameter("uniqid", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = loginmodel.uniqid
                };

                var loginlist = log.Database.SqlQuery<login>("exec teacherlogin @uniqid", uniqid).ToList();

                Session["id"] = loginlist[0].id;
                Session["roleteach"] = loginlist[0].roleid;

                if (loginlist[0].active == 1)
                {
                    string pwd = loginlist[0].pass.ToString();
                    bool passkey = salt.VerifyHash(loginmodel.pass, "SHA512", pwd);
                    if(passkey == true)
                    {
                        if((Convert.ToString(Session["roleteach"]) == "1"))
                        {
                            Session["id"] = loginlist[0].id;
                            Session["name"] = loginlist[0].name;
                            return RedirectToAction("admin", "admin");
                        }
                        else if ((Convert.ToString(Session["roleteach"]) == "2"))
                        {
                            Session["id"] = loginlist[0].id;
                            Session["name"] = loginlist[0].name;
                            Session["sem"] = loginlist[0].semid;
                            Session["year"] = loginlist[0].year;
                            return RedirectToAction("advisor", "advisor");
                        }
                        else if ((Convert.ToString(Session["roleteach"]) == "3"))
                        {
                            Session["id"] = loginlist[0].id;
                            Session["name"] = loginlist[0].name;
                            return RedirectToAction("teacher", "teacher");
                        }
                    }

                }
                
            }

           
            return RedirectToAction("login","login");
        }

    }
}