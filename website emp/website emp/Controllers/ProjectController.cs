using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;
using website_emp.Models.ViewModels;

namespace website_emp.Controllers
{
    public class ProjectController : Controller
    {
        Context context = new Context();
        // GET: Project
        [Route("")]
        [Route("Project")]
        [Route("Project/Index")]
        public ActionResult Index()
        {
            var projects = (from proj in context.project
                            where proj.Deleted == false
                            select proj
                             ).ToList();

            return View(Pagination<Project>.Paged(projects,1,10));
        }
        public ActionResult ProjectDetail()
        {
            Project proj = new Project();
            return View(proj);
        }


        [HttpGet]
        public ActionResult ProjectDetail(int? projectId,string search,int? pagenumber)
        {
            Project proj = context.project.Find(projectId.Value);
            proj.task = context.task.Where(p => p.ProjectId == proj.ProjectId).Select(p=>p).ToList();
            proj.department = context.department.Find(proj.DepartmentId);
            ViewData["CreatedBy"] = context.employe.Find(proj.Createdby).FirstName;
            if (!string.IsNullOrEmpty(search))
            {
                proj.task = (from i in proj.task
                             where i.TaskTitle.Contains(search)
                             select i).ToList();

            }
            if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            ProjectTaskViewModel model = new ProjectTaskViewModel();
            model.project = proj;
            model.tasks = Pagination<Task>.Paged(proj.task, pagenumber.Value, 10);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddProject()
        {
            IEnumerable<SelectListItem> items = from dep in context.department
                                                where dep.IsDeleted == false
                                                select new SelectListItem
                                                {
                                                    Value = dep.DepartmentId.ToString(),
                                                    Text = dep.DepartmentName
                                                };
            ViewData["DepartmentId"] = new SelectList(items, "Value", "Text");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProject(Project project)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Project").Select(p => p).FirstOrDefault();
            counter.Count++;
            project.ProjectId = (int)counter.Count;
            context.SaveChanges();
            project.department = context.department.Find(project.DepartmentId);
            project.Createdby = 1;
            project.Createdon = DateTime.Now;
            if (ModelState.IsValid)
            {
                context.project.Add(project);
                context.SaveChanges();
                return RedirectToAction("Index", "Project");
            }
            else
            {
                IEnumerable<SelectListItem> items = from dep in context.department
                                                    where dep.IsDeleted == false
                                                    select new SelectListItem
                                                    {
                                                        Value = dep.DepartmentId.ToString(),
                                                        Text = dep.DepartmentName
                                                    };
                ViewData["DepartmentId"] = new SelectList(items, "Value", "Text");
                return View();
            }
            
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateProject(int? projectid)
        {
            var deps = (from i in context.department
                        where i.IsDeleted == false
                        select new SelectListItem
                        {
                            Value = i.DepartmentId.ToString(),
                            Text = i.DepartmentName
                        }
                        ).ToList();
            SelectList  departments= new SelectList(deps, "Value", "Text");
            if (!projectid.HasValue)
            {
                ViewData["DepartmentId"] = departments;
                return View(new Project());
            }
            var project = (from i in context.project
                           where i.ProjectId == projectid.Value
                           select i
                           ).FirstOrDefault();
            foreach (var item in departments)
            {
                if (item.Value == project.DepartmentId.ToString())
                    item.Selected = true;
            }
            ViewData["DepartmentId"] = departments;
            return View(project);
            
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateProject (Project project)
        {
            if (project.ProjectId == 0)
            {
               // do nothing
            }else
            {
                Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
                var proj = context.project.Find(project.ProjectId);
                proj.ProjectTitle = project.ProjectTitle;
                proj.StartDate = proj.StartDate;
                proj.EndDate = proj.EndDate;
                proj.DepartmentId = project.DepartmentId;
                proj.department = context.department.Find(project.DepartmentId);
                proj.ModifiedBy = emp.EmployeId;
                proj.Modifiedon = DateTime.Now;
                context.Entry(proj).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Project");

        }

    }
}