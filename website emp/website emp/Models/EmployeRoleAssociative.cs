using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeRoleAssociative
    {
        [Key]
        public int EmployeRoleId { get; set; }
        // index 1 foriegn key
        public int EmployeId { get; set; }
        //index 2 foriegn key
        public int RoleId { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}