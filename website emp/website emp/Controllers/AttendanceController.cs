using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website_emp.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MarkAttendance()
        {
            return View();
        }
        public ActionResult DailyAttendance()
        {
            return View();
        }
        public ActionResult MonthlyAttendance()
        {
            return View();
        }
        public ActionResult LeaveRequest()
        {
            return View();
        }

    }
}