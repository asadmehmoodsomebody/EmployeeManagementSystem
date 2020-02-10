using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Attendance
    {
        [Key]
        public long AttendanceId { get; set;}
        public DateTime? ForDay { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public string Status { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public long EmployeId { get; set; }
        public Employe employe { get; set; }
    }
}