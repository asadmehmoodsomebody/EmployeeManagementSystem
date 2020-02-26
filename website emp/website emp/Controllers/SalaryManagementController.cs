using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;
using website_emp.Models.ViewModels;

namespace website_emp.Controllers
{
    public class SalaryManagementController : Controller
    {
        Context context = new Context();
        
        public ActionResult AssignSalary(long? departmentid,string employename,int? pagenumber)
        {
            var departments = (from i in context.department
                               where i.IsDeleted == false
                               select new SelectListItem
                               {
                                   Value = i.DepartmentId.ToString(),
                                   Text = i.DepartmentName
                               }
                               ).ToList();
            var employes = (from i in context.employe
                            where i.IsDeleted == false
                            && i.IsActive == true
                            select i
                            ).ToList();
            departments.Insert(0, new SelectListItem { Value = "0", Text = "Select Department" });
            SelectList list = new SelectList(departments, "Value", "Text");
            
            if (!string.IsNullOrEmpty(employename))
            {
                ViewData["search"] = employename;
                employes = employes.Where(p => p.FirstName.Contains(employename)).Select(p=>p).ToList();
            }
            if (departmentid.HasValue && departmentid.Value!=0)
            {
                ViewData["departmentid"] = departmentid.Value;
                employes = employes.Where(p => p.Departmentid==departmentid.Value).Select(p => p).ToList();
                foreach(var item in list)
                {
                    if (item.Value == departmentid.Value.ToString())
                        item.Selected = true;
                }
            }
            foreach (var item in employes)
            {
                item.department = context.department.Find(item.Departmentid);
                item.designation = context.designation.Find(item.Designationid);
            }
            ViewData["Departments"] = list;
            if (!pagenumber.HasValue) pagenumber = 1;
            return View(Pagination<Employe>.Paged(employes,pagenumber.Value,10));
        }
        [HttpPost]
        public ActionResult AssignSalary(Employe employe)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe tempemp = context.employe.Find(employe.EmployeId);
            tempemp.Salary = employe.Salary;
            tempemp.ModifiedBy = emp.EmployeId;
            tempemp.Modifiedon = DateTime.Now;
            context.Entry(tempemp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("AssignSalary", "SalaryManagement");
        }
       public ActionResult ManageBonus(string search,int? pagenumber)
        {
            var bonus = (from i in context.earning
                          where i.IsDeleted == false
                          select i
                          ).ToList();
            foreach (var item in bonus)
            {
                item.employe = context.employe.Find(item.EmployeId);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
                item.employe.department = context.department.Find(item.employe.Departmentid);
            }
            bonus = (from i in bonus
                     where i.employe.IsDeleted == false
                     select i
                     ).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                bonus = bonus.Where(p => p.employe.UserName.Contains(search)).Select(p => p).ToList();
            }
            //bonus = bonus.Where(p => (p.ForMonth.Value.Month - 1 > DateTime.Now.Month && p.ForMonth.Value.Year >= DateTime.Now.Year)).Select(p => p).ToList();
            List<Earning> filteredlist = new List<Earning>();
            foreach (var item in bonus)
            {
                var invoices = context.invoice.Where(p=>p.EmployeId==item.EmployeId).Select(p=>p).ToList();
                bool Exist = false;
                foreach (var it in invoices)
                {
                    if (item.ForMonth.Value<=it.ToMonth.Value)
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    filteredlist.Add(item);
                }
                Exist = false;
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Earning>.Paged(filteredlist,pagenumber.Value,10));
        }
        public ActionResult AddBonus()
        {
            var employe = (from i in context.employe
                           where i.IsDeleted == false
                           && i.IsActive == true
                           select new SelectListItem
                           {
                               Value = i.EmployeId.ToString(),
                               Text = i.UserName
                           }
                           ).ToList();
            ViewData["EmployeId"] = new SelectList(employe, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddBonus(Earning earning)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Earning").Select(p => p).FirstOrDefault();
            Employe admin = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            counter.Count++;
            earning.EarningId = counter.Count;
            earning.CreatedBy = admin.EmployeId;
            earning.CreatedOn = DateTime.Now;
            earning.IsDeleted = false;
            context.earning.Add(earning);
            context.SaveChanges();
            return RedirectToAction("AddBonus");
        }
        public ActionResult EditBonus(long bonusid)
        {
            Earning earning = context.earning.Find(bonusid);
            earning.employe = context.employe.Find(earning.EmployeId);
            earning.employe.department = context.department.Find(earning.employe.Departmentid);
            earning.employe.designation = context.designation.Find(earning.employe.Designationid);
            return View(earning);
        }
        [HttpPost]
        public ActionResult EditBonus(Earning earning)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Earning earn = context.earning.Find(earning.EarningId);
            earn.ModifiedBy = emp.EmployeId;
            earn.Modifiedon = DateTime.Now;
            earn.ComName = earning.ComName;
            earn.Amount = earning.Amount;
            earn.ForMonth = earning.ForMonth;
            context.Entry(earn).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ManageBonus");
        }
        public ActionResult ManageLoan()
        {
            return View();
        }
        public ActionResult AddLoan()
        {
            return View();
        }
        public ActionResult EditLoan()
        {
            return View();
        }
        public ActionResult ManageDeduction(string search,int? pagenumber)
        {
            var deduction = (from i in context.deduction
                         where i.IsDeleted == false
                         select i
                         ).ToList();
            foreach (var item in deduction)
            {
                item.employe = context.employe.Find(item.EmployeId);
                item.employe.designation = context.designation.Find(item.employe.Designationid);
                item.employe.department = context.department.Find(item.employe.Departmentid);
            }
            deduction = (from i in deduction
                     where i.employe.IsDeleted == false
                     select i
                     ).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                deduction = deduction.Where(p => p.employe.UserName.Contains(search)).Select(p => p).ToList();
            }
            //bonus = bonus.Where(p => (p.ForMonth.Value.Month - 1 > DateTime.Now.Month && p.ForMonth.Value.Year >= DateTime.Now.Year)).Select(p => p).ToList();
            List<Deduction> filteredlist = new List<Deduction>();
            foreach (var item in deduction)
            {
                var invoices = context.invoice.Where(p => p.EmployeId == item.EmployeId).Select(p => p).ToList();
                bool Exist = false;
                foreach (var it in invoices)
                {
                    if (item.ForMonth.Value <= it.ToMonth.Value)
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    filteredlist.Add(item);
                }
                Exist = false;
            }
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Deduction>.Paged(filteredlist, pagenumber.Value, 10));
        }
        public ActionResult AddDeduction()
        {
            var employe = (from i in context.employe
                           where i.IsDeleted == false
                           && i.IsActive == true
                           select new SelectListItem
                           {
                               Value = i.EmployeId.ToString(),
                               Text = i.UserName
                           }
                          ).ToList();
            ViewData["EmployeId"] = new SelectList(employe, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddDeduction(Deduction deduction)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Deduction").Select(p => p).FirstOrDefault();
            Employe admin = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            counter.Count++;
            deduction.DeductionId = counter.Count;
            deduction.CreatedBy = admin.EmployeId;
            deduction.CreatedOn = DateTime.Now;
            deduction.IsDeleted = false;
            context.deduction.Add(deduction);
            context.SaveChanges();
            return RedirectToAction("ManageDeduction");
        }
        public ActionResult EditDeduction(long deductionid)
        {
            Deduction deduction = context.deduction.Find(deductionid);
            deduction.employe = context.employe.Find(deduction.EmployeId);
            deduction.employe.department = context.department.Find(deduction.employe.Departmentid);
            deduction.employe.designation = context.designation.Find(deduction.employe.Designationid);
            return View(deduction);
        }
        [HttpPost]
        public ActionResult EditDeduction(Deduction deduction)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Deduction _deduction = context.deduction.Find(deduction.DeductionId);
            _deduction.ModifiedBy = emp.EmployeId;
            _deduction.Modifiedon = DateTime.Now;
            _deduction.ComName = deduction.ComName;
            _deduction.Amount = deduction.Amount;
            _deduction.ForMonth = deduction.ForMonth;
            context.Entry(_deduction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ManageDeduction");
        }
        public ActionResult ManageIncrement()
        {
            return View();
        }
        public ActionResult AddIncrement()
        {
            return View();
        }
        public ActionResult EditIncrement()
        {
            return View();
        }
        public ActionResult GeneratePaySlip()
        {
            return View();
        }
        public ActionResult EmployeeSalaries(int? pagenumber,string search)
        {
            Employe employe = context.employe.Where(emp => emp.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var invoices = (from i in context.invoice
                            where i.IsDeleted == false
                            && i.EmployeId == employe.EmployeId
                            select i
                            ).ToList();
            foreach (var item in invoices)
            {
                item.employe = employe;
            }
            if (!string.IsNullOrEmpty(search))
            {
                DateTime tempdate = DateTime.Parse(search); 
                ViewData["search"] = search;
                invoices = (from i in invoices
                            where i.ForMonth.Value.Month == tempdate.Month
                            && i.ForMonth.Value.Year == tempdate.Year
                            && i.IsDeleted == false
                            select i).ToList();
            }
            if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            return View(Pagination<Invoice>.Paged(invoices,pagenumber.Value,10));
        }
        public ActionResult EmployeeSalaryDetails(long invoiceid)
        {
            Invoice invoice = context.invoice.Find(invoiceid);
            Employe employe = context.employe.Find(invoice.EmployeId);
            employe.designation = context.designation.Find(employe.Designationid);
            employe.department = context.department.Find(employe.Departmentid);
            var deductions = (from i in context.deduction
                            where i.IsDeleted == false
                            && i.EmployeId == invoice.EmployeId
                            && i.ForMonth.Value >= invoice.FromMonth.Value
                            && i.ForMonth.Value <= invoice.ToMonth.Value
                              select i
                            ).ToList();
            var earnings = (from i in context.earning
                            where i.IsDeleted == false
                            && i.EmployeId == invoice.EmployeId
                            && i.ForMonth.Value >= invoice.FromMonth.Value
                            && i.ForMonth.Value <= invoice.ToMonth.Value
                            select i
                            ).ToList();
            //double tearning = 0;
            //double tdeduction = 0;
            //foreach (var item in earnings)
            //{
            //    tearning += item.Amount;
            //}
            //foreach (var item in deductions)
            //{
            //    tdeduction += item.Amount;
            //}
            //double netsalary = employe.Salary -tdeduction + tearning;
            //ViewData["TotalEarning"] = tearning;
            //ViewData["TotalDeduction"] = tdeduction;
            //ViewData["NetSalary"] = netsalary;
            InvoiceEmployeEarningDeductionViewModel model = new InvoiceEmployeEarningDeductionViewModel
            {
                invoice = invoice,
                employe = employe,
                earning = earnings,
                deduction = deductions
            };
            return View(model);
        }
        public ActionResult SalaryReport(int? month,int? year,string username,int? pagenumber)
        {
           string[] months =new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            month = (month.HasValue) ? month.Value : DateTime.Now.Month;
            year = (year.HasValue) ? year.Value : DateTime.Now.Year;
            ViewData["year"] = year;
            ViewData["month"] = month;
            username = (!string.IsNullOrEmpty(username)) ? username : "";
            ViewData["username"] = username;
            var salary = (from i in context.invoice
                          where i.IsDeleted == false
                          && i.ForMonth.Value.Month == month
                          && i.ForMonth.Value.Year == year
                          select i
                          ).ToList();
            foreach (var item in salary)
            {
                item.employe = context.employe.Find(item.EmployeId);
            }
            salary = (from i in salary
                      where i.employe.FirstName.Contains(username)
                      select i
                      ).ToList();
            pagenumber = (pagenumber.HasValue) ? pagenumber.Value : 1;
            return View(Pagination<Invoice>.Paged(salary,pagenumber.Value,10));
        }
    }
}