using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class DailyAttendanceViewModel
    {
        public Employe emp { get; set; }
        public Attendance attendance { get; set; }
    }
}