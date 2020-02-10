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
        // GET: Task
        [HttpGet]
        public ActionResult Index(string search)
        {
            
            return View();
        }

    }
}