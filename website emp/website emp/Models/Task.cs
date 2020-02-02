using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string ModuleName { get; set; }
        public int Assingnedby { get; set; }
        public int Assingedto { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }
        public string StatusRemarks { get; set; }
        public DateTime OptimisticTime { get; set; }
        public DateTime OptimizedTime { get; set; }
        public DateTime? LazyTime { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}