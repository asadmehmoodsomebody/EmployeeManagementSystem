using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace website_emp.Models
{
    public class context :DbContext
    {
        public context() : base(@"Data Source=DESKTOP-M1JQCQK;Initial Catalog=Emp_Task_Management;Integrated security = true")
        {

        }
        public DbSet<user> Users { get; set; }
        public DbSet<department> Departments { get; set; }
        public DbSet<designation> Designations { get; set; }
        public DbSet<status> States { get; set; }
        public DbSet<SecurityKey> keys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().Property(p => p.UserName).HasMaxLength(100);
            modelBuilder.Entity<user>().HasIndex(p => p.UserName).IsUnique(true);

            modelBuilder.Entity<user>().Property(p => p.Email).HasMaxLength(100);
            modelBuilder.Entity<user>().HasIndex(p => p.Email).IsUnique(true);

            modelBuilder.Entity<department>().Property(p => p.DepartmentName).HasMaxLength(100);
            modelBuilder.Entity<department>().HasIndex(p => p.DepartmentName).IsUnique(true);

            modelBuilder.Entity<designation>().Property(p => p.DesignationName).HasMaxLength(100);
            modelBuilder.Entity<designation>().HasIndex(p => p.DesignationName).IsUnique(true);

            modelBuilder.Entity<status>().Property(p => p.State).HasMaxLength(100);
            modelBuilder.Entity<status>().HasIndex(p => p.State).IsUnique(true);
        }
    }
    
}