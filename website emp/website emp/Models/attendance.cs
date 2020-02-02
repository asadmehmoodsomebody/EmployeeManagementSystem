using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}