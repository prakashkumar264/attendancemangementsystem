using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class attendancelist
    {
        [Key]
        public int rollno { get; set; }
        public int sem { get; set; }
        public bool IsCheck { get; set; }
        public string modifiedon { get; set; }
    }

    public class attendancelisttt
    {
        [Key]
        public int stdrollno { get; set; }
        public bool IsCheck { get; set; }
        
    }

    public class totalattendacelistcount
    {
        [Key]
        public int count { get; set; }
    }
    public class totalattendacelistrollno
    {
        [Key]
        public int stdrollno { get; set; }
    }

    public class stdlisttheory
    {
        public List<attendancelist> attend { get; set; }
        public List<attendancelisttt> attendd { get; set; }
        public List<totalattendacelistcount> totalattend { get; set; }
        public List<totalattendacelistrollno> totalroll { get; set; }
        public int subid { get; set; }
        public int sem { get; set; }
        public string modifiedon { get; set; }
        public string modifiedon2 { get; set; }
        public string name { get; set; }
        public string test { get; set; }
        public string subjectname { get; set; }
        public IEnumerable<fetchsubthoerysubjectforselect> theorysubject { get; set; }
        public List<getdate> getdate { get; set; }
    }

    public class fetchsubthoerysubjectforselect
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int sem { get; set; }
    }

   public class getdate
    {
        [Key]
        public string modifiedon { get; set; }
    }
}