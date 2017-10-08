using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class studentlist
    { 
       
        public int id { get; set; }
        public string uniqueid { get; set; }
        public int joinyear { get; set; }
        public int rollno { get; set; }
        public string name { get; set; }
        public string parentmob { get; set; }
        public int sem { get; set; }
        public string year { get; set; }
        public string batch { get; set; }
        public IEnumerable<studentlist> stdlist { get; set; }
    }
 
}