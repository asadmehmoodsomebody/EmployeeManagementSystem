using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public Pagination<Department> departments { get; set; }
        public Department department { get; set; }
    }
}