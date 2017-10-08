using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Context
{
    public class AttendanceContext :DbContext 
    {
        public DbSet<login> login { get; set; }

        public AttendanceContext() : base("name=conn")
        {
            Database.SetInitializer<AttendanceContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.teacherlist> teacherlists { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.subjectlist> subjectlists { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.studentlist> studentlists { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.assignteacher> assignteachers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.subpracticallist> subpracticallists { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.assignpracteacher> assignpracteachers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.attendancelist> attendancelists { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.practicalattendancelist> practicalattendancelists { get; set; }
    }
}