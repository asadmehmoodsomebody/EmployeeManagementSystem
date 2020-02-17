using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;
using website_emp.Models.ViewModels;

namespace website_emp.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MarkAttendance(string search,long? departmentid)
        {
            DateTime time = DateTime.Now;
            IEnumerable<EmployeAttendanceViewModel> model = (from i in context.employe
                                                             join k in context.shift
                                                             on i.ShiftId equals k.ShiftId
                                                             where i.IsDeleted == false && i.IsActive == true
                                                             && k.IsDeleted == false
                                                             select new EmployeAttendanceViewModel
                                                             {
                                                                 employe = i,
                                                                 shift = k
                                                             }
                                                             ).ToList();
            //DateTime ti = DateTime.Parse(DateTime.Now.ToLongDateString());
            //DateTime te = DateTime.Parse("03:00 AM");
            //ti.Add(TimeSpan.Parse(te.ToString()));
            foreach (var item in model)
            {
                item.leaves = (from i in context.leave
                               where i.IsAccepted == true
                               && i.startTime <= DateTime.Now
                               && i.endTime >= DateTime.Now
                               && i.EmployeId == item.employe.EmployeId
                               select i
                               ).ToList();
                item.employe.department = context.department.Find(item.employe.Departmentid);
                item.attendance = (from i in context.attendance
                                   where i.ForDay.Value.Day == time.Day
                                   && i.ForDay.Value.Year == time.Year
                                   && i.ForDay.Value.Month == time.Month
                                   && i.Status != null
                                   && i.EmployeId == item.employe.EmployeId
                                   select i
                                   ).FirstOrDefault();
            }
            var items = (from i in context.department
                         where i.IsDeleted == false
                         select new SelectListItem
                         {
                             Value = i.DepartmentId.ToString(),
                             Text = i.DepartmentName
                         }
                         ).ToList();
            SelectList deps = new SelectList(items, "Value", "Text");
            if (departmentid.HasValue || !String.IsNullOrEmpty(search))
            {
                if (departmentid.HasValue)
                {
                    model = (from i in model
                             where i.employe.Departmentid == departmentid.Value
                             select i).ToList();
                    foreach (var it in deps)
                    {
                        if (it.Value == departmentid.Value.ToString())
                            it.Selected = true;
                    }
                }
                if (!String.IsNullOrEmpty(search))
                {
                    ViewData["search"] = search;
                    model = (from i in model
                             where i.employe.UserName.Contains(search)
                             select i).ToList();
                }
            }
            ViewBag.departments = deps;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAttendance(IEnumerable<Attendance> attendance)
        {
            Employe emp = context.employe.Where(em => em.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            foreach (var item in attendance)
            {
                var att = (from i in context.attendance
                           where i.EmployeId == item.EmployeId
                           && i.ForDay.Value.Day == DateTime.Now.Day
                            && i.ForDay.Value.Month == DateTime.Now.Month
                             && i.ForDay.Value.Year == DateTime.Now.Year
                           select i
                           ).ToList();
                if (att.Count > 0)
                {
                    att[0].ModifiedBy = emp.EmployeId;
                    att[0].Modifiedon = DateTime.Now;
                    att[0].Status = item.Status;
                    context.Entry(att[0]).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }else
                {
                    MentainanceCounter counter = context.counter.Where(p => p.TableName == "Attendance").Select(p => p).FirstOrDefault();
                    counter.Count++;
                    item.AttendanceId = counter.Count;
                    context.SaveChanges();
                    item.employe = context.employe.Find(item.EmployeId);
                    item.ForDay = DateTime.Now;
                    item.IsDeleted = false;
                    context.attendance.Add(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("MarkAttendance", "Attendance");
        }
        [HttpGet]
        public ActionResult DailyAttendance(DateTime? date)
        {
            if (!date.HasValue)
            {
                date = DateTime.Now;
            }
            DateTime time = DateTime.Now;
            IEnumerable<EmployeAttendanceViewModel> model = (from i in context.employe
                                                             join k in context.shift
                                                             on i.ShiftId equals k.ShiftId
                                                             where i.IsDeleted == false && i.IsActive == true
                                                             && k.IsDeleted == false
                                                             select new EmployeAttendanceViewModel
                                                             {
                                                                 employe = i,
                                                                 shift = k
                                                             }
                                                             ).ToList();
            ViewData["date"] = date.Value.ToString("MM/dd/yyyy");
            foreach (var item in model)
            {
                item.leaves = (from i in context.leave
                               where i.IsAccepted == true
                               && i.startTime <= DateTime.Now
                               && i.endTime >= DateTime.Now
                               && i.EmployeId == item.employe.EmployeId
                               select i
                               ).ToList();
                item.employe.department = context.department.Find(item.employe.Departmentid);
                item.attendance = (from i in context.attendance
                                   where i.ForDay.Value.Day == date.Value.Day
                                   && i.ForDay.Value.Year == date.Value.Year
                                   && i.ForDay.Value.Month == date.Value.Month
                                   && i.Status != null
                                   && i.EmployeId == item.employe.EmployeId
                                   select i
                                   ).FirstOrDefault();
            }
            model = model.Where(p => p.attendance != null).Select(p => p).ToList();
            Pagination<EmployeAttendanceViewModel> page = Pagination<EmployeAttendanceViewModel>.Paged(model, 1, 10);
            return View(page);
        }
        [HttpGet]
        public ActionResult MonthlyAttendance(long? employeid,DateTime? starttime,DateTime? endtime)
        {
            if (!employeid.HasValue)
            {
                employeid = context.employe.Where(p=>p.IsDeleted==false && p.IsActive==true).Select(p=>p).FirstOrDefault().EmployeId;
            }
            if (!starttime.HasValue)
            {
                starttime = DateTime.Now;
            }
            if (!endtime.HasValue)
            {
                endtime = DateTime.Now;
            }
            ViewData["starttime"] = starttime.Value.ToShortDateString();
            ViewData["endtime"] = endtime.Value.ToShortDateString(); 
            Employe employe = context.employe.Find(employeid.Value);
            employe.attendance = (from i in context.attendance
                                  where i.IsDeleted == false
                                  && i.ForDay.Value >= starttime.Value
                                  && i.ForDay.Value <= endtime.Value
                                  select i
                                ).ToList();
            employe.shift = context.shift.Find(employe.ShiftId);
            var emp = (from i in context.employe
                       where i.IsDeleted == false
                       && i.IsActive == true
                       select new SelectListItem
                       {
                           Value = i.EmployeId.ToString(),
                           Text = i.FirstName + " "+i.LastName 
                       }
                       ).ToList();
            ViewBag.employes = new SelectList(emp, "Value", "Text",employeid.ToString());
            MonthlyAttendanceViewModel mod = new MonthlyAttendanceViewModel();
            mod.attendence = Pagination<Attendance>.Paged(employe.attendance, 1, 10);
            mod.employe = employe;
            return View(mod);
        }
        public ActionResult LeaveRequest()
        {
            var leaves = (from i in context.leave
                          orderby i.startTime descending
                          select i
                          ).ToList();
            foreach (var item in leaves)
            {
                item.employe = context.employe.Find(item.EmployeId);
            }
            Pagination<Leave> page = Pagination<Leave>.Paged(leaves, 1, 10);
            return View(page);
        }
        public ActionResult LeaveRequestAccept(long leaveid)
        {
            Leave leave = context.leave.Find(leaveid);
            leave.IsAccepted = true;
            context.Entry(leave).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("LeaveRequest");
        }
        public ActionResult LeaveRequest_E()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LeaveRequest_E(Leave leave)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Leave").Select(p => p).FirstOrDefault();
            counter.Count++;
            context.SaveChanges();
            leave.employe = emp;
            leave.LeaveId = counter.Count;
            leave.EmployeId = emp.EmployeId;
            leave.IsAccepted = false;
            context.leave.Add(leave);
            context.SaveChanges();
            return RedirectToAction("MyLeave");
        }
        public ActionResult Holidays(string month ,string year)
        {
            if (string.IsNullOrEmpty(month))
            {
                month = "January";
            }
            if (string.IsNullOrEmpty(year))
            {
                year ="2010";
            }
            DateTime time = DateTime.Parse("1 " + month + " " + year);
            var holidays = (from i in context.holiday
                            where i.IsDeleted == false
                            && i.HolidayDate.Value.Month == time.Month
                            && i.HolidayDate.Value.Year == time.Year
                            select i
                            ).ToList();
            Pagination<Holiday> hol = Pagination<Holiday>.Paged(holidays, 1, 10);
            return View(hol);
        }
        public ActionResult DeleteHolidays(long holidayid)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Holiday holiday = context.holiday.Find(holidayid);
            holiday.IsDeleted = true;
            holiday.ModifiedBy = emp.EmployeId;
            holiday.Modifiedon = DateTime.Now;
            context.Entry(holiday).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Holidays");
        }
        public ActionResult ManualAttendance()
        {
            return View();
        }
        public ActionResult LeaveRequestAdmin()
        {
            return View();
        }
        public ActionResult AddHolidays()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHolidays(Holiday holiday)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Holiday").Select(p => p).FirstOrDefault();
            counter.Count++;
            holiday.HolidayId = counter.Count;
            context.SaveChanges();
            holiday.IsDeleted = false;
            holiday.CreatedOn = DateTime.Now;
            holiday.CreatedBy = emp.EmployeId;
            context.holiday.Add(holiday);
            context.SaveChanges();
            return RedirectToAction("Holidays");
        }
        public ActionResult MyLeave()
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var leaves = (from i in context.leave
                          where i.EmployeId == emp.EmployeId
                          select i
                          ).ToList();
            foreach (var item in leaves)
            {
                item.employe = emp;
            }
            Pagination<Leave> leave = Pagination<Leave>.Paged(leaves, 1, 10);
            return View(leave);
        }
        public ActionResult WorkHours()
        {
            return View();
        }
        public ActionResult WorkHoursMonthly()
        {
            return View();
        }

    }
}