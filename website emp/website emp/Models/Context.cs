using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
namespace website_emp.Models
{
    public class Context:DbContext
    {
        public Context():base("Server=LAPTOP-ENVV97AF;initial catalog = Emp_Task_Management;integrated security = true;") {}
        public DbSet<Department> department { get; set; }
        public DbSet<DepartmentDesignationAssociative> departmentdesignationassociative { get; set; }
        public DbSet<Designation> designation { get; set; }
        public DbSet<Employe> employe { get; set; }
        public DbSet<EmployeModuleRightAssociative> employemodulerightassociative { get; set; }
        public DbSet<EmployeRoleAssociative> employeroleassociative { get; set; }
        public DbSet<Module> module { get; set; }
        public DbSet<ModuleRightAssociative> modulerightassociative { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Right> right { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<RoleModuleRightAssociative> rolemodulerightassociative { get; set; }
        public DbSet<Task> task { get; set; }
        public DbSet<EmployeDepartmentDesignation> employedepartmentdesignation { get; set; }
        public DbSet<EmployeRole> employerole { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<DepartmentDesignationAssociative>().HasIndex(p => new { p.DepartmentId, p.DesignationId }).IsUnique(true);
            builder.Entity<Employe>().Property(p => p.UserName).HasMaxLength(150);
            builder.Entity<Employe>().HasIndex(p => p.UserName).IsUnique(true);
            builder.Entity<EmployeModuleRightAssociative>().HasIndex(p => new { p.ModuleRightId, p.EmployeId }).IsUnique(true);
            builder.Entity<EmployeRoleAssociative>().HasIndex(p => new { p.EmployeId, p.RoleId }).IsUnique(true);
            builder.Entity<Module>().HasIndex(p => p.ModuleName).IsUnique(true);
            builder.Entity<ModuleRightAssociative>().HasIndex(p => new { p.ModuleId, p.RightId }).IsUnique(true);
            builder.Entity<Right>().Property(p => p.RightName).HasMaxLength(100);
            builder.Entity<Right>().HasIndex(p => p.RightName).IsUnique(true);
            builder.Entity<Role>().Property(p => p.RoleName).HasMaxLength(100);
            builder.Entity<Role>().HasIndex(p => p.RoleName).IsUnique(true);
            builder.Entity<RoleModuleRightAssociative>().HasIndex(p => new { p.ModuleRightId, p.RoleId }).IsUnique(true);
            builder.Entity<EmployeDepartmentDesignation>().HasIndex(p => p.DepartmentDesignationId).IsUnique(true);
            builder.Entity<EmployeRole>().HasIndex(p => new { p.EmployeId, p.RoleId }).IsUnique(true);
        }
    }
}