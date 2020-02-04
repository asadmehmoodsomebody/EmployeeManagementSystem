using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        // foreignkey
        public int DepartmentId { get; set; }
        [StringLength(maximumLength:150)]
        //unique
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}