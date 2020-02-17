using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class EmployeAttendanceViewModel
    {
        public Employe employe { get; set; }
        public Attendance attendance { get; set; }
        public IEnumerable<Leave> leaves {get;set;}
        public Shift shift { get; set; }
    }
}