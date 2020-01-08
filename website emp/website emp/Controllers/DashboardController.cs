using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website_emp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        website_emp.Models.context db = new Models.context();
        public ActionResult Index()
        {
            Models.status statusid = db.States.FirstOrDefault(p => p.State == "Allowed");
            var employ = db.Users.Where(p=>p.Status.StatusId == statusid.StatusId).Select(p=>p).ToArray();
            ViewBag.AttendanceNumber = employ.Count();
            var departments = db.Departments.Select(p => p).ToArray();
            ViewBag.DepartmentsNumber = departments.Count();
            return View();
        }
    }
}