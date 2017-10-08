using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class login
    {
        [Key]
        public int id {get; set; }
        public string uniqid { get; set; }
        public string pass { get; set; }
        public int roleid { get; set; }
        public int active { get; set; }
        public string name { get; set; }
        public int semid { get; set; }
        public string year { get; set; }
    }
}