using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeRole
    {
        [Key]
        public int EmployeRoleId { get; set; }
        //index1
        public int EmployeId { get; set; }
        //index2
        public int RoleId { get; set; }
    }
}