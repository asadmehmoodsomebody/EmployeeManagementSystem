using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Leave
    {
        public int LeaveId { get; set; }
        public int EmployeId { get; set; }
        public string LeaveDescription { get; set; }
        public DateTime LeaveStart { get; set; }
        public DateTime LeaveEnd { get; set; }
        public int LeaveLength { get; set; }
        public int ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}