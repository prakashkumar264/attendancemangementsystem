using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class updateadvisor
    {
        //public int id { get; set; }
        public string teacher { get; set; }
        public string teacher2 { get; set; }
        public string teacher3 { get; set; }
        public int SE { get; set; }
        public int TE { get; set; }
        public int BE { get; set; }
        public IEnumerable<chooseadvisor> selectadvisor { get; set; }
        public IEnumerable<chooseSE> selectSE { get; set; }
        public IEnumerable<chooseTE> selectTE { get; set; }
        public IEnumerable<chooseBE> selectBE { get; set; }
    }

    public class chooseadvisor
    {
        [Key]
        public int id { get; set; }
        public int roleid { get; set; }
        public string name { get; set; }
    }

    public class chooseSE
    {

        public int id { get; set; }
        public int sem { get; set; }
      
    }
    public class chooseTE
    {

        public int id { get; set; }
        public int sem { get; set; }
       
    }
    public class chooseBE
    {
      
        public int id { get; set; }
        public int sem { get; set; }
       
    }


}