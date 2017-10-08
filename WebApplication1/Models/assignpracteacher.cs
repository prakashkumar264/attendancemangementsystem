using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class assignpracteacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int batch { get; set; }
        public int teacherid { get; set; }
        public string teachername { get; set; }
        public IEnumerable<nampracteach> nameteac { get; set; }
        public IEnumerable<assadvisorpracteacher> selectadvisor { get; set; }
    }

    public class assadvisorpracteacher
    {
        [Key]
        public int id { get; set; }
        public int roleid { get; set; }
        public string name { get; set; }
    }

    public class nampracteach
    {
        public string name { get; set; }
    }
}