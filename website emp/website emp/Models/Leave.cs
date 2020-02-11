using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Leave
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LeaveId { get; set; }
        public string Description { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public bool? IsAccepted { get; set; }
        public int TotalDays { get; set; }
        public long EmployeId { get; set; }
        public virtual Employe employe { get; set; }
    }
}