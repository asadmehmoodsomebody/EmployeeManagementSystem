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
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProject(Project project)
        {
            return View();
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