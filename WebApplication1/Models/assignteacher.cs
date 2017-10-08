using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class assignteacher
    {
        public int id { get; set; }
        public string name { get; set; }
       
        public int teacherid { get; set; }
        public string teachername { get; set; }
        public IEnumerable<namteach> nameteac  { get; set; }
        public IEnumerable<assadvisorteacher> selectadvisor { get; set; }
    }


    public class assadvisorteacher 
    {
        [Key]
        public int id { get; set; }
        public int roleid { get; set; }
        public string name { get; set; }
    }

   public class namteach
    {
        public string name { get; set; }
    }
}