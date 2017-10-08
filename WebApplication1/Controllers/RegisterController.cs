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
    public class RegisterController : Controller
    {
        SaltEncryption salt = new SaltEncryption();
        // GET: Register
        public ActionResult Register()
        {
            register reg = new register();
            reg.roles = getroles();

            return View(reg);
        }

        [HttpPost]
        public ActionResult teacherregister(register registermodel, FormCollection formcollection)
        {
            var registerteacher = new List<register>();

            using ( var reg = new AttendanceContext())
            {
                var name = new SqlParameter("@name", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = registermodel.name
                };
                var email = new SqlParameter("@email", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = registermodel.email
                };
                var uniqid = new SqlParameter("@uniqid", SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = registermodel.uniqueid
                };
                var roleid = new SqlParameter("@roleid", SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = registermodel.teachrole
                };

                var pass = new SqlParameter("@pass", SqlDbType.NVarChar)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value  = salt.ComputeHash(registermodel.password, "SHA512", null)
                };
                
                registerteacher = reg.Database.SqlQuery<register>("exec registerteacher @name, @email, @uniqid, @roleid,@pass", name, email, uniqid, roleid, pass).ToList();
               
            }

            TempData["registerteacher"] = "<script>alert('Teacher Register Successfully');</script>";
            return RedirectToAction("Register", "Register");
        }

        public List<role> getroles()
        {
            var role = new List<role>();
            using (var reg = new AttendanceContext())
            {
                role = reg.Database.SqlQuery<role>("exec fetchrole").ToList();
            }
            return role;
        }
    }
}