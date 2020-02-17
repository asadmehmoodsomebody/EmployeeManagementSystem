using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class MonthlyAttendanceViewModel
    {
        public Pagination<Attendance> attendence { get; set; }
        public Employe employe { get; set; }
    }
}