using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class EmployeSalaryTemplate
    {
        public Employe employe { get; set; }
        public SalarySlip salaryslip { get; set; }
        public IEnumerable<Department> departments { get; set; }
    }
}