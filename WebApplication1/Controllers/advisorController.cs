using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class advisorController : Controller
    {
        // GET: advisor
        public ActionResult advisor()
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
                return View();
            }
        }

        public ActionResult generatedefaulter()
        {
            int sem = Convert.ToInt32(Session["sem"]);
            string year = Convert.ToString(Session["year"]);
            using (var adv = new AttendanceContext())
            {
                var advi = adv.Database.SqlQuery<advisor>("exec generatedefaulter @sem, @year", new SqlParameter("@sem", sem), new SqlParameter("@year", year)).ToList();
            }
            return RedirectToAction("advisor", "advisor");
        }


        public ActionResult exportexcel()
        {
            if(Convert.ToInt32(Session["sem"]) == 3 || Convert.ToInt32(Session["sem"]) == 4 )
            {
                string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from SEdefaulters"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                using (XLWorkbook wb = new XLWorkbook())
                                {
                                    wb.Worksheets.Add(dt, "SEdefaulters");

                                    Response.Clear();
                                    Response.Buffer = true;
                                    Response.Charset = "";
                                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    Response.AddHeader("content-disposition", "attachment;filename=DefaulterList.xlsx");
                                    using (System.IO.MemoryStream MyMemoryStream = new MemoryStream())
                                    {
                                        wb.SaveAs(MyMemoryStream);
                                        MyMemoryStream.WriteTo(Response.OutputStream);
                                        Response.Flush();
                                        Response.End();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Convert.ToInt32(Session["sem"]) == 5 || Convert.ToInt32(Session["sem"]) == 6)
            {
                string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from TEdefaulters"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                using (XLWorkbook wb = new XLWorkbook())
                                {
                                    wb.Worksheets.Add(dt, "TEdefaulters");

                                    Response.Clear();
                                    Response.Buffer = true;
                                    Response.Charset = "";
                                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    Response.AddHeader("content-disposition", "attachment;filename=DefaulterList.xlsx");
                                    using (System.IO.MemoryStream MyMemoryStream = new MemoryStream())
                                    {
                                        wb.SaveAs(MyMemoryStream);
                                        MyMemoryStream.WriteTo(Response.OutputStream);
                                        Response.Flush();
                                        Response.End();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Convert.ToInt32(Session["sem"]) == 7 || Convert.ToInt32(Session["sem"]) == 8)
            {
                string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from BEdefaulters"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                using (XLWorkbook wb = new XLWorkbook())
                                {
                                    wb.Worksheets.Add(dt, "BEdefaulters");

                                    Response.Clear();
                                    Response.Buffer = true;
                                    Response.Charset = "";
                                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    Response.AddHeader("content-disposition", "attachment;filename=DefaulterList.xlsx");
                                    using (System.IO.MemoryStream MyMemoryStream = new MemoryStream())
                                    {
                                        wb.SaveAs(MyMemoryStream);
                                        MyMemoryStream.WriteTo(Response.OutputStream);
                                        Response.Flush();
                                        Response.End();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return RedirectToAction("advisor", "advisor");
        }
    }
}