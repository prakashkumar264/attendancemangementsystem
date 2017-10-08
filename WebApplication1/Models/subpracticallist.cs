using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class subpracticallist
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sem { get; set; }
        public string year { get; set; }
        public int batch { get; set; }
        public int teacherid { get; set; }
        public string teachername { get; set; }
        public IEnumerable<subjectpracticalsem> selectpracsem { get; set; }
        public IEnumerable<subjectpracticalyear> selectpracyear { get; set; }
        public IEnumerable<assgnsubpracteacher> selectadvisor { get; set; }
    }

    public class subjectpracticalsem
    {
        public int sem { get; set; }
    }

    public class subjectpracticalyear 
    {
        public string year { get; set; }
    }

    public class assgnsubpracteacher 
    {
        [Key]
        public int id { get; set; }
        public int roleid { get; set; }
        public string name { get; set; }
    }


}