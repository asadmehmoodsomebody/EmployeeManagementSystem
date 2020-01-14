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
        public DbSet<module> Modules { get; set; }
        public DbSet<moduleRight> ModuleRights { get; set; }
        public DbSet<right> Rights { get; set; }
        public DbSet<role> Roles { get; set; }
        public DbSet<roleModuleRight> RoleModuleRights { get; set; }
        public DbSet<userRight> UserRights { get; set; }
        public DbSet<userRole> UserRoles { get; set; }
        public DbSet<shift> Shifts { get; set; }
        public DbSet<fingerPrint> FingerPrints { get; set; }
        public DbSet<holiday> Holidays { get; set; }
        public DbSet<leaveRequest> LeaveRequests { get; set; }
        public DbSet<attendance> Attendance { get; set; }
        public DbSet<salaryTemplate> SalaryTemplates { get; set; }
        public DbSet<paySlip> PaySlips { get; set; }
        public DbSet<deduction> Deductions { get; set; }
        public DbSet<fine> Fines { get; set; }
        public DbSet<loanRequest> LoanRequests { get; set; }
        public DbSet<loanInstallment> LoanInstallments { get; set; }
        public DbSet<project> Projects { get; set; }
        public DbSet<task> Task { get; set; }
        public DbSet<groupTask> GroupTask { get; set; }
        public DbSet<userGroupTask> UserGroupTask { get; set; }
        public DbSet<userTask> UserTask { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            //unique properties
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

            //composite key
            //modelBuilder.Entity<userRole>().HasKey(p => new { p.Role, p.User });
            //modelBuilder.Entity<roleModuleRight>().HasKey(p => new { p.ModuleRight, p.Role });
            //modelBuilder.Entity<userRight>().HasKey(p => new { p.ModuleRight, p.User });

            // checking
            //modelBuilder.Entity<userRight>().HasIndex(p => new { p.ModuleRight, p.User }).IsUnique(true);
            //modelBuilder.Entity<roleModuleRight>().HasIndex(p => new { p.ModuleRight, p.Role }).IsUnique(true);
            //modelBuilder.Entity<userRole>().HasIndex(p => new { p.Role, p.User }).IsUnique(true);

        }
    }
    
}