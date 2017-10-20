using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class uploadstudentController : Controller
    {
        // GET: uploadstudent
        public ActionResult uploadstudent()
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

        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"D:\SOOAD\latest\WebApplication1\WebApplication1\ExcelFormat\studenttemplate.xlsx");
            string fileName = "StudentTemplate.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost]
        public ActionResult uploadstudent(HttpPostedFileBase studentfile)
        {
            string filePath = string.Empty;
            if (studentfile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(studentfile.FileName);
                string extension = Path.GetExtension(studentfile.FileName);
                studentfile.SaveAs(filePath);

                string conString = string.Empty;
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.studentlist";

                        //[OPTIONAL]: Map the Excel columns with that of the database table

                        sqlBulkCopy.ColumnMappings.Add("Unique id", "uniqueid");
                        sqlBulkCopy.ColumnMappings.Add("Joinyear", "joinyear");
                        sqlBulkCopy.ColumnMappings.Add("Roll", "rollno");
                        sqlBulkCopy.ColumnMappings.Add("Name", "name");
                        sqlBulkCopy.ColumnMappings.Add("ParentMob", "parentmob");
                        sqlBulkCopy.ColumnMappings.Add("Semester", "sem");
                        sqlBulkCopy.ColumnMappings.Add("Year", "year");
                        sqlBulkCopy.ColumnMappings.Add("Batch", "batch");


                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            TempData["uploadsubject"] = "<script>alert('Subject Uploaded Successfully');</script>";
            return RedirectToAction("advisor", "advisor");
        }
    }
}