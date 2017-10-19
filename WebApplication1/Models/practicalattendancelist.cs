using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class practicalattendancelist
    {
        [Key]
        public int  rollno { get; set; }
        public int sem { get; set; }
        public string batch { get; set; }
        public bool IsCheck { get; set; }
        public string modifiedon { get; set; }
    }

    public class attendancelistpractical
    {
        [Key]
        public int stdrollno { get; set; }
        public bool IsCheck { get; set; }

    }

    public class totalpracticalattendacelistcount 
    {
        [Key]
        public int count { get; set; }
    }
    public class totalpracticalattendacelistrollno 
    {
        [Key]
        public int stdrollno { get; set; }
    }

    public class stdlistpractical
    {
        public List<practicalattendancelist> attend { get; set; }
        public List<attendancelistpractical> attendddd { get; set; }
        public List<totalpracticalattendacelistcount> totalattend { get; set; }
        public List<totalpracticalattendacelistrollno> totalroll { get; set; }
        public int subid { get; set; }
        [Key]
        public int sem { get; set; }
        public string modifiedon { get; set; }
        public string modifiedon2 { get; set; }
        public string batch { get; set; }
        public string name { get; set; }
        public string valueyesno { get; set; }
        public IEnumerable<fetchsubpracticalsubjectforselect> practicalsubject { get; set; }
        public List<getdatepractical> getdatepractical { get; set; }
        public List<yesno> yesno { get; set; }
    }

    public class fetchsubpracticalsubjectforselect
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int sem { get; set; }
        public int batch { get; set; } 
    } 

    public class getdatepractical
    {
        [Key]
        public string modifiedon { get; set; }
    }

    public class getbatch
    {
        [Key]
        public int batch { get; set; }
    }

    public class yesno
    {
        [Key]
        public int value { get; set; }
        public string name { get; set; }
    }
}