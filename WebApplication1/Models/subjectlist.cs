using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class subjectlist
    {
  
        public int id { get; set; }
        public string name { get; set; }
        public int sem { get; set; }
        public string year { get; set; }
        
        public int teacherid { get; set; }
        public string teachername { get; set; }
        public IEnumerable<subjectsem> selectsem { get; set; }
        public IEnumerable<subjectyear> selectyear { get; set; }
        
        public IEnumerable<assgnsubteacher> selectadvisor { get; set; }
        public IEnumerable<selteacherdetails> ddn  { get; set; }
    }

    public class subjectsem
    {
        public int sem { get; set; }
    }

    public class subjectyear
    {
        public string year { get; set; }
    }

    

    public class assgnsubteacher
    {
        [Key]
        public int id { get; set; }
        public int roleid { get; set; }
        public string name { get; set; }
    }

    public class selteacherdetails
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}