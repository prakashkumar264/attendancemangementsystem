using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class teacherlist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string uniqid { get; set; }
        public int roleid { get; set; }
        public int semid { get; set; }
        public string year { get; set; }
        public IEnumerable<fillrole> roles { get; set; }
        public IEnumerable<choosesemteacher> sem { get; set; }
        public IEnumerable<chooseyearteacher> year2  { get; set; }
    }

    public class fillrole 
    {
        public int roleid { get; set; }
        public string rolename { get; set; }
    }

    public class choosesemteacher
    {

        public int id { get; set; }
        public int sem { get; set; }

    }

    public class chooseyearteacher
    {

        public int id { get; set; }
        public string year { get; set; }

    }

}