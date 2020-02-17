using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;

namespace website_emp.Controllers
{
    public class ManageEmployeeController : Controller
    {
        Context context = new Context();
        // GET: ManageEmployee
        public ActionResult Index(string search)
        {
            IEnumerable<Employe> emp = (from i in context.employe
                                        where i.IsDeleted == false
                                        select i
                                        ).ToList<Employe>();
            if (!String.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                emp = from i in emp
                      where i.FirstName.Contains(search) || i.LastName.Contains(search)
                      select i;
            }
            Pagination<Employe> emps = Pagination<Employe>.Paged(emp, 1, 10);
            
            return View(emps);
        }
        public ActionResult AddEmployee()
        {
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Text = i.DepartmentName,
                            Value = i.DepartmentId.ToString()
                        }).ToList();
            int depid = int.Parse(deps[0].Value);
            var des = (from i in context.designation
                       where i.IsDeleted==false select
                       new SelectListItem {
                           Value= i.DesignationId.ToString(),
                           Text = i.DesignationName
                       }
                       ).ToList();
            var shifts = (from i in context.shift
                          where i.IsDeleted == false
                          select new SelectListItem
                          {
                              Value = i.ShiftId.ToString(),
                              Text = i.ShiftName

                          }
                          ).ToList();
            var templates = (from i in context.salarytemplate
                             where i.IsDeleted == false
                             select new SelectListItem
                             {
                                 Value = i.SalaryTemplateId.ToString(),
                                 Text = i.TemplateName
                             }
                             ).ToList();

            des.Insert(0, new SelectListItem { Value = "", Text = "Employe" });
            ViewBag.departments = new SelectList(deps, "Value", "Text");
            ViewBag.designations = new SelectList(des, "Value", "Text");
            ViewBag.salarytemplates = new SelectList(templates, "Value", "Text");
            ViewBag.shifts = new SelectList(shifts, "Value", "Text");
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult AddEmployee(Employe employe,string DesignationId)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            if (!String.IsNullOrEmpty(DesignationId))
            {
               
                long d = long.Parse(DesignationId);
                var depdes = context.departmentdesignation.Where(p => p.DesignationId == d && p.DepartmentId == employe.Departmentid)
                    .Select(p => p).ToList<DepartmentDesignation>();
                if (depdes.Count() > 0)
                {
                    if (depdes[0].IsDeleted.Value)
                    {
                        depdes[0].IsDeleted = false;
                        depdes[0].ModifiedBy = emp.EmployeId;
                        depdes[0].Modifiedon = DateTime.Now;
                    }
                    employe.DepartmentDesignationId = depdes[0].DepartmentDesignationId;
                    employe.departmentdesignation = depdes[0];

                }else
                {
                    MentainanceCounter c = context.counter.Where(p => p.TableName == "DepartmentDesignation").Select(p => p).FirstOrDefault();
                    c.Count++;
                    DepartmentDesignation newdepdes = new DepartmentDesignation();
                    newdepdes.DepartmentDesignationId = c.Count;
                    context.SaveChanges();
                    newdepdes.CreatedBy = emp.EmployeId;
                    newdepdes.CreatedOn = DateTime.Now;
                    newdepdes.IsDeleted = false;
                    newdepdes.department = context.department.Find(employe.Departmentid);
                    newdepdes.DepartmentId = employe.Departmentid;
                    newdepdes.DesignationId = d;
                    newdepdes.designation = context.designation.Find(d);
                    employe.DepartmentDesignationId = c.Count;
                    employe.departmentdesignation = newdepdes;
                    context.SaveChanges();
                }
            }
            employe.CreatedBy = emp.EmployeId;
            employe.CreatedOn = DateTime.Now;
            employe.IsDeleted = false;
            employe.department = context.department.Find(employe.Departmentid);
            employe.shift = context.shift.Find(employe.ShiftId);
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Employe").Select(p => p).FirstOrDefault();
            counter.Count++;
            employe.EmployeId = counter.Count;
            MentainanceCounter counter2 = context.counter.Where(p => p.TableName == "EmployeRole").Select(p => p).FirstOrDefault();
            counter2.Count++;
            EmployeRole role = new EmployeRole();
            role.EmployeRoleId = counter2.Count;
            context.SaveChanges();
            Role _role = context.role.Where(p => p.RoleName == "User").Select(p => p).FirstOrDefault();
            role.RoleId = _role.RoleId;
            role.role = _role;
            role.employe = employe;
            role.EmployeId = employe.EmployeId;
            role.CreatedOn = DateTime.Now;
            role.CreatedBy = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault().EmployeId;
             context.SaveChanges();

            if (ModelState.IsValid)
            {
                context.employe.Add(employe);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(long employeid)
        {
            Employe emp = context.employe.Find(employeid);
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Text = i.DepartmentName,
                            Value = i.DepartmentId.ToString()
                        }).ToList();
            int depid = int.Parse(deps[0].Value);
            var des = (from i in context.department
                       join j in context.departmentdesignation
                       on i.DepartmentId equals j.DepartmentId
                       join k in context.designation on
                       j.DesignationId equals k.DesignationId
                       where k.IsDeleted == false && j.IsDeleted == false
                       && i.DepartmentId == depid
                       select new SelectListItem
                       {
                           Value = j.DepartmentDesignationId.ToString(),
                           Text = k.DesignationName
                       }).ToList();
            var shifts = (from i in context.shift
                          where i.IsDeleted == false
                          select new SelectListItem
                          {
                              Value = i.ShiftId.ToString(),
                              Text = i.ShiftName

                          }
                          ).ToList();
            var templates = (from i in context.salarytemplate
                             where i.IsDeleted == false
                             select new SelectListItem
                             {
                                 Value = i.SalaryTemplateId.ToString(),
                                 Text = i.TemplateName
                             }
                             ).ToList();

            des.Insert(0, new SelectListItem { Value = "", Text = "Employe" });
            string empdesignation = (emp.DepartmentDesignationId.HasValue) ? emp.DepartmentDesignationId.Value.ToString() : "";
            ViewBag.departments = new SelectList(deps, "Value", "Text",emp.Departmentid.ToString());
            ViewBag.designations = new SelectList(des, "Value", "Text",empdesignation);
            ViewBag.salarytemplates = new SelectList(templates, "Value", "Text",emp.SalaryTemplateId.ToString());
            ViewBag.shifts = new SelectList(shifts, "Value", "Text",emp.ShiftId.ToString());
            return View(emp);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employe employe,string DesignationId)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            if (!String.IsNullOrEmpty(DesignationId))
            {

                long d = long.Parse(DesignationId);
                var depdes = context.departmentdesignation.Where(p => p.DesignationId == d && p.DepartmentId == employe.Departmentid)
                    .Select(p => p).ToList<DepartmentDesignation>();
                if (depdes.Count() > 0)
                {
                    if (depdes[0].IsDeleted.Value)
                    {
                        depdes[0].IsDeleted = false;
                        depdes[0].ModifiedBy = emp.EmployeId;
                        depdes[0].Modifiedon = DateTime.Now;
                    }
                    employe.DepartmentDesignationId = depdes[0].DepartmentDesignationId;
                    employe.departmentdesignation = depdes[0];

                }
                else
                {
                    MentainanceCounter c = context.counter.Where(p => p.TableName == "DepartmentDesignation").Select(p => p).FirstOrDefault();
                    c.Count++;
                    DepartmentDesignation newdepdes = new DepartmentDesignation();
                    newdepdes.DepartmentDesignationId = c.Count;
                    context.SaveChanges();
                    newdepdes.CreatedBy = emp.EmployeId;
                    newdepdes.CreatedOn = DateTime.Now;
                    newdepdes.IsDeleted = false;
                    newdepdes.department = context.department.Find(employe.Departmentid);
                    newdepdes.DepartmentId = employe.Departmentid;
                    newdepdes.DesignationId = d;
                    newdepdes.designation = context.designation.Find(d);
                    employe.DepartmentDesignationId = c.Count;
                    employe.departmentdesignation = newdepdes;
                    context.SaveChanges();
                }
            }
            Employe temp = context.employe.Find(employe.EmployeId);
            employe.CreatedBy = temp.CreatedBy;
            employe.CreatedOn = temp.CreatedOn;
            employe.IsDeleted = temp.IsDeleted;
            employe.UserName = temp.UserName;
            employe.ModifiedBy = emp.EmployeId;
            employe.Modifiedon = DateTime.Now;
            employe.department = context.department.Find(employe.Departmentid);
            employe.shift = context.shift.Find(employe.ShiftId);

            context.Entry(temp).CurrentValues.SetValues(employe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowEmployee()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteEmployee(long employeid)
        {
            Employe employe = context.employe.Find(employeid);
            employe.IsDeleted = true;
            employe.IsActive = false;
            context.Entry(employe).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Department(long? departmentid)
        {
            ViewData["status"] = "Add Department";
            ViewData["action"] = "AddDepartment";
            if (departmentid.HasValue)
            {
                ViewData["action"] = "UpdateDepartment";
                ViewData["status"] = "Update Department";
                ViewData["deparmentname"] = context.department.Find(departmentid.Value).DepartmentName;
                ViewData["departmentid"] = departmentid.Value;
            }
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select i
                        ).ToList();
            Pagination<Department> page = Pagination<Department>.Paged(deps, 1, 10);
            return View(page);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteDepartment (long departmentid)
        {
            Department dep = context.department.Find(departmentid);
            dep.IsDeleted = true;
            context.Entry(dep).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Department");
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult UpdateDepartment (Department deparment)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Department dep = context.department.Find(deparment.DepartmentId);
            dep.DepartmentName = deparment.DepartmentName;
            dep.ModifiedBy = emp.EmployeId;
            dep.Modifiedon = DateTime.Now;
            context.Entry(dep).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Department");
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult AddDepartment(Department department)
        {

            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var deps = context.department.Where(p => p.DepartmentName == department.DepartmentName).Select(p=>p).ToList();
            if (deps.Count > 0)
            {
                deps[0].ModifiedBy = emp.EmployeId;
                deps[0].Modifiedon = DateTime.Now;
                deps[0].IsDeleted = false;
                context.SaveChanges();
            }
            else
            {
                MentainanceCounter count = context.counter.Where(p => p.TableName == "Department").Select(p => p).FirstOrDefault();
                count.Count++;
                department.DepartmentId = count.Count;
                context.SaveChanges();
                department.CreatedBy = emp.EmployeId;
                department.IsDeleted = false;
                department.CreatedOn = DateTime.Now;
                context.department.Add(department);
                context.SaveChanges();
            }
            return RedirectToAction("Department");
        }
        public ActionResult Designation(long? designationid)
        {
            ViewData["status"] = "Add Designation";
            ViewData["action"] = "AddDesignation";
            if (designationid.HasValue)
            {
                ViewData["action"] = "UpdateDesignation";
                ViewData["status"] = "Update Designation";
                ViewData["designationname"] = context.designation.Find(designationid.Value).DesignationName;
                ViewData["designationid"] = designationid.Value;
            }
            var des = (from i in context.designation
                        where i.IsDeleted == false
                        select i
                        ).ToList();
            Pagination<Designation> page = Pagination<Designation>.Paged(des, 1, 10);
            return View(page);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDesignation(long designationid)
        {
            Designation dep = context.designation.Find(designationid);
            dep.IsDeleted = true;
            context.Entry(dep).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Designation");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Updatedesignation(Designation designation)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            Designation dep = context.designation.Find(designation.DesignationId);
            dep.DesignationName = designation.DesignationName;
            dep.ModifiedBy = emp.EmployeId;
            dep.Modifiedon = DateTime.Now;
            context.Entry(dep).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Designation");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDesignation(Designation designation)
        {

            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var deps = context.designation.Where(p => p.DesignationName == designation.DesignationName).Select(p => p).ToList();
            if (deps.Count > 0)
            {
                deps[0].ModifiedBy = emp.EmployeId;
                deps[0].Modifiedon = DateTime.Now;
                deps[0].IsDeleted = false;
                context.SaveChanges();
            }
            else
            {
                MentainanceCounter count = context.counter.Where(p => p.TableName == "Designation").Select(p => p).FirstOrDefault();
                count.Count++;
                designation.DesignationId = count.Count;
                context.SaveChanges();
                designation.CreatedBy = emp.EmployeId;
                designation.IsDeleted = false;
                designation.CreatedOn = DateTime.Now;
                context.designation.Add(designation);
                context.SaveChanges();
            }
            return RedirectToAction("Designation");
        }
        //[HttpPost]
        //[Authorize(Roles ="Admin")]
        //public ActionResult GetDesignations(long DepartmentId)
        //{
        //    var deps = (from i in context.department
        //               join j in context.departmentdesignation
        //               on i.DepartmentId equals j.DepartmentId
        //               join k in context.designation on
        //               j.DesignationId equals k.DesignationId
        //               where k.IsDeleted==false && j.IsDeleted==false
        //               && i.DepartmentId == DepartmentId select
        //               new
        //               {
        //                   departmentdesignationid = j.DepartmentDesignationId,
        //                   designationname = k.DesignationName
        //               });
        //    return Json(new { data = deps.ToList() });
        //}
        [HttpPost]
        public string filehandler (HttpPostedFileBase profile)
        {
            string filename = profile.FileName;
            string ext = filename.Substring(filename.IndexOf('.'));
            Guid guid = Guid.NewGuid();
            string newname = guid.ToString() + ext;
            profile.SaveAs(this.Server.MapPath("~") + "Images/Profile/" + newname);
            return newname;
        }
    }
}