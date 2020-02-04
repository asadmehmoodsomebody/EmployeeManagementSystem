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
            IEnumerable<Project> projects = (from proj in context.project
                           where proj.Deleted == false
                           orderby proj.StartDate descending
                           select proj).ToList<Project>();

            return View(projects);
        }
        public ActionResult ProjectDetail()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ProjectDetail(int? projectId)
        {
            ProjectTaskViewModel model = new ProjectTaskViewModel();
            if (projectId == null) return Redirect("Index");
            else
            {

                model.project = (from project in context.project
                                 where project.ProjectId == projectId.Value
                                 select project).FirstOrDefault();
                model.Tasks = (from task in context.task
                               where task.ProjectId == projectId.Value
                               select task).ToList<Task>();
                model.employe = (from emp in context.employe
                                 where emp.EmployeId == model.project.Createdby
                                 select emp).FirstOrDefault();
                model.department = (from dep in context.department
                                    where dep.DepartmentId == model.project.DepartmentId
                                    select dep).FirstOrDefault();
                return View(model);
            }
            
        }
        public ActionResult AddProject()
        {
            ViewData["DepartmentId"] = from dep in context.department
                                      where dep.Deleted == false
                                      select
             new SelectListItem
             {
                 Value = dep.DepartmentId.ToString(),
                 Text = dep.DepartmentName
             };
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            project.Createdby = 1;
            project.Createdon = DateTime.Now;
            project.Deleted = false;
            if (ModelState.IsValid)
            {
                context.project.Add(project);
                context.SaveChangesAsync();
                return Redirect("Index");
            }
            ViewData["DepartmentId"] = from dep in context.department
                                       where dep.Deleted == false
                                       select
              new SelectListItem
              {
                  Value = dep.DepartmentId.ToString(),
                  Text = dep.DepartmentName
              };
            return View();
        }
        public ActionResult UpdateProject(int? projectid)
        {
            if (projectid == null) return Redirect("Index");
            Project project = (from proj in context.project
                               where proj.ProjectId == projectid.Value
                               select proj).FirstOrDefault();
            IEnumerable<SelectListItem> items = from dep in context.department
                                       where dep.Deleted == false
                                       select
              new SelectListItem
              {
                  Value = dep.DepartmentId.ToString(),
                  Text = dep.DepartmentName
              };
            SelectList list = new SelectList(items, "Value", "Text",project.DepartmentId);
            ViewData["DepartmentId"] = list;
            return View(project);
        }
        [HttpPost]
        public ActionResult UpdateProject (Project project)
        {
            project.Modifiedon = DateTime.Now;
            project.Modifiedby = 1;
            project.Deleted = false;
            if (ModelState.IsValid)
            {
                context.Entry(project).State = System.Data.Entity.EntityState.Modified;
                context.SaveChangesAsync();
                return Redirect("Index");
            }
            IEnumerable<SelectListItem> items = from dep in context.department
                                                where dep.Deleted == false
                                                select
                       new SelectListItem
                       {
                           Value = dep.DepartmentId.ToString(),
                           Text = dep.DepartmentName
                       };
            SelectList list = new SelectList(items, "Value", "Text", project.DepartmentId);
            return View(project);
        }

    }
}