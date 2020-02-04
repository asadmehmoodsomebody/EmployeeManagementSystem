using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace website_emp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(150,ErrorMessage ="This is required",MinimumLength =1)]
        public string DepartmentName { get; set; }
        public string DepartmentDesciption { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}