using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;

namespace website_emp.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        Context context = new Context();
        public ActionResult UserProfile()
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            emp.department = context.department.Find(emp.Departmentid);
            return View(emp);
        }

        public ActionResult ManageRoles()
        {
            return View();
        }
        public ActionResult ManageShifts()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [Authorize(Roles ="Admin")]
        public ActionResult ManageShifts(Shift shift)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            shift.CreatedBy = emp.EmployeId;
            shift.CreatedOn = DateTime.Now;
            shift.IsDeleted = false;
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Shift").Select(p => p).FirstOrDefault();
            counter.Count++;
            shift.ShiftId = (int)counter.Count;
            context.SaveChanges();
            if (ModelState.IsValid)
            {
                context.shift.Add(shift);
                context.SaveChanges();
                return RedirectToAction("ShiftsDetail");
            }
            return View();
        }
        public ActionResult ShiftsDetail()
        {
            var shifts = from i in context.shift
                         where i.IsDeleted == false
                         select i;
            Pagination<Shift> page = Pagination<Shift>.Paged(shifts.ToList(), 1, 10);
            return View(page);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult UpdateShift(int shiftid)
        {
            Shift sh = context.shift.Find(shiftid);
            return View(sh);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult UpdateShift(Shift shift)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Shift sh = context.shift.Find(shift.ShiftId);
            sh.ModifiedBy = emp.EmployeId;
            sh.Modifiedon = DateTime.Now;
            sh.ShiftName = shift.ShiftName;
            sh.ShiftStartTime = shift.ShiftStartTime;
            sh.ShiftEndTime = shift.ShiftEndTime;
            if (ModelState.IsValid)
            {
                context.Entry(sh).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ShiftsDetail", "Administration");
            }
            return View(shift.ShiftId);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteShift(int? shiftid)
        { 
            if (shiftid.HasValue)
            {
                Shift sh = context.shift.Find(shiftid.Value);
                if (sh != null)
                {
                    sh.IsDeleted = true;
                    context.Entry(sh).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("ShiftDetail");
        }
    }
}