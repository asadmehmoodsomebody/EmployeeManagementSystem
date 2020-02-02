using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public string ProjectTitile { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime OptimisticTime { get; set; }
        public DateTime OptimizedTime { get; set; }
        public DateTime LazyTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}