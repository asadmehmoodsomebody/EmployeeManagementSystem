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
        public Context():base("Server=LAPTOP-ENVV97AF;initial catalog = EMS;integrated security = true;") {}
        public DbSet<Department> department { get; set; }
        public DbSet<Designation> designation { get; set; }
        public DbSet<Employe> employe { get; set; }
        public DbSet<EmployeModuleRight> employemoduleright { get; set; }
        public DbSet<EmployeRole> employerole { get; set; }
        public DbSet<Module> module { get; set; }
        public DbSet<ModuleRight> moduleright { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Right> right { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<RoleModuleRight> rolemoduleright { get; set; }
        public DbSet<Attendance> attendance { get; set; }
        public DbSet<Deduction> deduction { get; set; }
        public DbSet<Earning> earning { get; set; }
        public DbSet<Increment>  increment { get; set; }
        public DbSet<Loan> loan { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<Shift> shift { get; set; }
        public DbSet<FingerPrint> fingerprint { get; set; }
        public DbSet<Holiday> holiday { get; set; }
        public DbSet<Leave> leave { get; set; }
        public DbSet<MentainanceCounter> counter { get; set; }
        public DbSet<Task> task { get; set; }
        public DbSet<LoanInstallment> loaninstallment { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Employe>().HasOptional(a => a.fingerprint).WithRequired(b => b.employe);
            builder.Entity<Employe>().HasOptional(a => a.fingerprint).WithRequired(b => b.employe);
        }
    }
}