using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;

namespace website_emp.Controllers
{
    public class TaskController : Controller
    {
        Context context = new Context();
       // Migrations.Configuration con = new Migrations.Configuration();

        // GET: Task
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string search)
        {
            
            return View();
        }
        [Route("Task/ViewAllTasks")]
        public ActionResult Tasks()
        {
            return View();
        }
        [Route("Task/AddTask")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTask()
        {
            //con.myseed(context);
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTask(Task task)
        {
            
            return View();
        }

        [Route("Task/EditTask")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Task task)
        {
            return View();
        }
        

    }
}