using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class register
    {
        public string name { get; set; }
        public string email { get; set; }
        public string uniqueid { get; set; }
        public string password { get; set; }
        public string teachrole { get; set; }
        public IEnumerable<role> roles { get; set; }
    }

    public class role
    {
        public int roleid { get; set; }
        public string rolename { get; set; }
    }

}