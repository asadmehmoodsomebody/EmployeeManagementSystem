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
         

            return View();
        }
        public ActionResult ProjectDetail()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ProjectDetail(int? projectId)
        {

            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            return View();
        }
        public ActionResult UpdateProject(int? projectid)
        {
            
            
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProject (Project project)
        {
            return View();
        }

    }
}