using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;

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

            return View(projects);
        }
        public ActionResult ProjectDetail()
        {
            Project proj = new Project();
            return View(proj);
        }


        [HttpGet]
        public ActionResult ProjectDetail(int? projectId)
        {
            Project proj = context.project.Find(projectId.Value);
            proj.task = context.task.Where(p => p.ProjectId == proj.ProjectId).Select(p=>p).ToList();
            proj.department = context.department.Find(proj.DepartmentId);
            ViewData["CreatedBy"] = context.employe.Find(proj.Createdby).FirstName;
            return View(proj);
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
            
            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateProject (Project project)
        {
            return View();
        }

    }
}