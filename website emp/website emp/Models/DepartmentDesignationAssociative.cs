using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class DepartmentDesignationAssociative
    {
        [Key]
        public int DepartmentDesignationAssociativeId { get; set; }
        //forign key index 1
        public int DepartmentId { get; set; }
        //forign key index 2
        public int DesignationId { get; set; }
        //unique (index1, index 2)
        public bool Deleted { get; set; }
    }
}