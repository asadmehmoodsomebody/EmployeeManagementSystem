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
        // GET: SalaryManagement
        Context context = new Context();
        [Authorize(Roles ="Admin")]
        public ActionResult AddTemplate()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult AddTemplate(SalaryTemplate template)
        {
            
            template.CreatedBy = 1;
            template.CreatedOn = DateTime.Now;
            template.IsDeleted = false;
            if (ModelState.IsValid)
            {
                MentainanceCounter count = context.counter.Where(p => p.TableName == "SalaryTemplate").Select(p => p).FirstOrDefault();
                count.Count++;
                template.SalaryTemplateId = count.Count;
                context.SaveChanges();
                context.salarytemplate.Add(template);
                context.SaveChanges();
                return RedirectToAction("TemplateList");
            }
            return View();
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult DeleteTemplate(long templateid)
        {
            SalaryTemplate st = context.salarytemplate.Find(templateid);
            st.IsDeleted = true;
            context.Entry(st).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("TemplateList");
        }
        public ActionResult makepayment()
        {
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Text = i.DepartmentName,
                            Value = i.DepartmentId.ToString()
                        }
                        ).ToList();
            ViewBag.department = new SelectList(deps, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult makepayment(string departmentid,string date)
        {
            DateTime d = DateTime.Parse(date);
            var sal = (from i in context.salaryslip
                       where i.ForMonth.Value.Month == d.Month
                       && i.ForMonth.Value.Year == d.Year
                       select i
                       ).ToList();
            Employe memp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var emp = (from i in context.employe
                       where i.IsActive == true && i.IsDeleted == false
                       select i
                       ).ToList();
            if (sal.Count > 0)
            {
                var deps = (from i in context.department
                            where i.IsDeleted == false
                            select new SelectListItem
                            {
                                Text = i.DepartmentName,
                                Value = i.DepartmentId.ToString()
                            }
                        ).ToList();
                ViewBag.department = new SelectList(deps, "Value", "Text");
                ViewBag.errormsg = "Salary Already Exist";
                return View();
            }
            else
            {
                MentainanceCounter counter = context.counter.Where(p => p.TableName == "SalarySlip").Select(p => p).FirstOrDefault();
                foreach (var item in emp)
                {
                    counter.Count++;
                    SalarySlip slip = new SalarySlip()
                    {
                        CreatedBy = memp.EmployeId,
                        CreatedOn = DateTime.Now,
                        ForMonth = DateTime.Now,
                        EmployeId = item.EmployeId,
                        employe = context.employe.Find(item.EmployeId),
                        IsDeleted = false,
                        salarytemplate = context.salarytemplate.Find(item.SalaryTemplateId),
                        SalarySlipId = counter.Count,
                        SalaryTemplateId = item.SalaryTemplateId
                    };
                    context.salaryslip.Add(slip);
                }
                context.SaveChanges();
                return View("GeneratePaySlip");
            }
        }
        [Authorize(Roles ="Admin")]
        public ActionResult AssignSalary(long? DepartmentId)
        {
            IEnumerable<SelectListItem> items = (from i in context.department
                                            where i.IsDeleted == false
                                            select new SelectListItem {
                                                Text = i.DepartmentName,
                                                Value=i.DepartmentId.ToString()
                                            }).ToList();
            IEnumerable<SelectListItem> sitems = from i in context.salarytemplate
                                                where i.IsDeleted == false
                                                select new SelectListItem
                                                {
                                                    Text = i.TemplateName,
                                                    Value = i.SalaryTemplateId.ToString()
                                                };
            SelectList list = new SelectList(items, "Value", "Text");
            if (DepartmentId.HasValue)
            {
                foreach (var item in list)
                {
                    if (item.Value == DepartmentId.Value.ToString())
                        item.Selected = true;
                }
            }
            ViewBag.DepartmentId = list;
            ViewData["SalaryTemplateId"] = new SelectList(sitems, "Value", "Text");
            var emp = (from i in context.employe
                       where i.IsActive == true
                       && i.IsDeleted == false
                       select new EmployeSalaryDepartmentViewModel
                       {
                           employe=i
                       }
                        ).ToList();
            foreach (var item in emp)
            {
                item.employe.department = context.department.Find(item.employe.Departmentid);
                if (item.employe.DepartmentDesignationId.HasValue)
                {
                    item.employe.departmentdesignation = context.departmentdesignation.Find(item.employe.DepartmentDesignationId);
                    item.designation = context.designation.Where(p => p.DesignationId == item.employe.departmentdesignation.DesignationId).Select(p => p).FirstOrDefault();
                }else
                {
                    item.designation = new Designation() { DesignationName = "Employe" };
                }
            }
            if (DepartmentId.HasValue) {
                emp = (from i in emp
                       where i.employe.Departmentid == DepartmentId.Value
                       select i
                      ).ToList();
            }  
            return View(emp);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult AssignSalary(Employe employe)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Employe emp2 = context.employe.Find(employe.EmployeId);
            emp2.SalaryTemplateId = employe.SalaryTemplateId;
            emp2.salarytemplate = context.salarytemplate.Find(emp2.SalaryTemplateId);
            emp2.ModifiedBy = emp.EmployeId;
            emp2.Modifiedon = DateTime.Now;
            context.Entry(emp2).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("AssignSalary");

        }
        public ActionResult CheckSalary()
        {
            return View();
        }
        public ActionResult PayrollManagement()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult TemplateList()
        {
            var templatelist = from i in context.salarytemplate
                               where i.IsDeleted == false
                               select i;
            return View(templatelist.ToList());
        }
        public ActionResult GeneratePaySlip(long? departemtid,DateTime? date)
        {
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Text = i.DepartmentName,
                            Value = i.DepartmentId.ToString()
                        }
                        ).ToList();
            ViewBag.department = new SelectList(deps, "Value", "Text");
            return View();
        }
        public ActionResult EmployeeSalaries(string search)
        {
            var employs = (from i in context.employe
                           where i.IsDeleted == false
                           && i.IsActive == true
                           select new EmployeSalaryDepartmentViewModel
                           {
                               employe=i
                           }
                           ).ToList();
           foreach (var item in employs)
            {
                item.employe.department = context.department.Find(item.employe.Departmentid);
                item.employe.salarytemplate = context.salarytemplate.Find(item.employe.SalaryTemplateId);
                if (item.employe.DepartmentDesignationId.HasValue)
                {
                    item.employe.departmentdesignation = context.departmentdesignation.Find(item.employe.DepartmentDesignationId);
                    item.designation = context.designation.Where(p => p.DesignationId == item.employe.departmentdesignation.DesignationId).Select(p=>p).FirstOrDefault();
                }else
                {
                    item.designation = new Designation() { DesignationName = "Employe" };
                }
            }
           if (!string.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                employs = (from i in employs
                          where i.employe.FirstName.Contains(search)
                          select i).ToList();
            }
            return View(Pagination<EmployeSalaryDepartmentViewModel>.Paged(employs,1,10));
        }
        public ActionResult ManageSalary()
        {
            return View();
        }
        public ActionResult SalaryReport()
        {
            return View();
        }
    }
}