using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BEdefaulters
    {
        [Key]
        public int id { get; set; }
        public int? stdrollno { get; set; }
        public string stdname { get; set; }
        public string total_theory { get; set; }
        public string theory_percentage { get; set; }
        public string total_practical { get; set; }
        public string practical_percentage { get; set; }
        public string extra_attendance { get; set; }
        public string total_attendance { get; set; }
        public string attendance_percentage { get; set; }
    }
}