using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeModuleRightAssociative
    {
        [Key]
        public int EmployeModuleRightAssociativeId {get;set;}
        //index 1
        public int ModuleRightId { get; set; }
        //index 2 unique index1,index2
        public int EmployeId { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}