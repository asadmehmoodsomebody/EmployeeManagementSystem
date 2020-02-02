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
        public DbSet<Employe> employe { get; set; }
        public DbSet<Attendance> attendance { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<DepartmentDesignation> departmentdesignation { get; set; }
        public DbSet<Designation> designation { get; set; }
        public DbSet<Earning> earning { get; set; }
        public DbSet<EmployeModuleRight> employemoduleright { get; set; }
        public DbSet<EmployeRole> employerole { get; set; }
        public DbSet<EmployeShift> employeshift { get; set; }
        public DbSet<EmployeShiftHistory> employeshifthistory { get; set; }
        public DbSet<FingerPrint> fingerprint { get; set; }
        public DbSet<Holiday> holiday { get; set; }
        public DbSet<Leave> leave { get; set; }
        public DbSet<Loan> loan { get; set; }
        public DbSet<LoanHistory> loanhistory { get; set; }
        public DbSet<Module> modulerights { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Right> right { get; set; }
        public DbSet<RoleModuleRight> rolemoduleright { get; set; }
        public DbSet<SalarySlip> salaryslip { get; set; }
        public DbSet<SalaryTemplate> salarytemplate { get; set; }
        public DbSet<Shift> shift { get; set; }
        public DbSet<Task> task { get; set; }
    }
    
}