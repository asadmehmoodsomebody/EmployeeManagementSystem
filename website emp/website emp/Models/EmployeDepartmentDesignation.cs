using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeDepartmentDesignation
    {
        [Key]
        public int EmployeDepartmentDesignationId { get; set; }
        //unique
        public int EmployeId { get; set; }
        //unique
        public int DepartmentDesignationId { get; set; }
    }
}