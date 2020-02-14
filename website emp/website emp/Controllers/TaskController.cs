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
            IEnumerable<Task> tasks = (from task in context.task
                                       where task.Deleted == false
                                       
                                       orderby task.Createdon descending
                                       select task
                                       ).ToList<Task>();
            foreach (var t in tasks)
            {
                t.project = context.project.Find(t.ProjectId);
                t.assingedby = context.employe.Find(t.AssignedById);
                t.assingedto = context.employe.Find(t.AssingedToId);
            }
            if (!String.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                tasks = from i in tasks
                        where i.TaskTitle.Contains(search)
        || i.project.ProjectTitle.Contains(search)
                        select i;
            }
            Pagination<Task> page = Pagination<Task>.Paged(tasks, 1, 10);
            return View(page);
        }
        [Route("Task/ViewAllTasks")]
        public ActionResult Tasks(string search)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            IEnumerable<Task> tasks = (from task in context.task
                                       where task.Deleted == false
                                       && task.AssingedToId == emp.EmployeId
                                       && task.Status=="Ongoing"
                                       select task
                                       ).ToList<Task>();
            foreach (var t in tasks)
            {
                t.project = context.project.Find(t.ProjectId);
                t.assingedby = context.employe.Find(t.AssignedById);
                t.assingedto = context.employe.Find(t.AssingedToId);
            }
           if (!String.IsNullOrEmpty(search))
            {
                ViewData["search"] = search;
                tasks = from i in tasks
                        where i.TaskTitle.Contains(search)
        || i.project.ProjectTitle.Contains(search)
                        select i;
            }
            Pagination<Task> page = Pagination<Task>.Paged(tasks, 1, 10);
            return View(page);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddTask(long? PorjectId)
        {
            //con.myseed(context);
            IEnumerable<SelectListItem> items = from project in context.project
                                                where project.Deleted == false
                                                select new SelectListItem {
                                                    Value = project.ProjectId.ToString(),
                                                    Text = project.ProjectTitle
                                                };
            IEnumerable<SelectListItem> emps = from emp in context.employe
                                               where emp.IsDeleted == false && emp.IsActive == true
                                               select new SelectListItem
                                               {
                                                   Value = emp.EmployeId.ToString(),
                                                   Text = emp.FirstName + " " + emp.LastName
                                       };
            if (PorjectId!=null)
            {
                foreach (SelectListItem item in items)
                {
                    if (item.Value==PorjectId.Value.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }

            ViewData["ProjectId"] = new SelectList(items, "Value", "Text");
            ViewData["AssignedBy"] = new SelectList(emps, "Value", "Text");
            ViewData["AssignedTo"] = new SelectList(emps, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult AddTask(Task task)
        {
            MentainanceCounter counter = context.counter.Where(p => p.TableName == "Task").Select(p => p).FirstOrDefault();
            counter.Count++;
            task.TaskId = counter.Count;
            context.SaveChanges();
            task.project = context.project.Find(task.ProjectId);
            task.Createdby = 1;
            task.Createdon = DateTime.Now;
            task.Deleted = false;
            task.assingedby = context.employe.Find(task.AssignedById);
            task.assingedto = context.employe.Find(task.AssingedToId);
            if (ModelState.IsValid)
            {
                context.task.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index", "Task");
            }else
            {
                IEnumerable<SelectListItem> items = from project in context.project
                                                    where project.Deleted == false
                                                    select new SelectListItem
                                                    {
                                                        Value = project.ProjectId.ToString(),
                                                        Text = project.ProjectTitle
                                                    };
                
                    foreach (SelectListItem item in items)
                    {
                        if (item.Value == task.ProjectId.ToString())
                        {
                            item.Selected = true;
                        }
                    }
                IEnumerable<SelectListItem> emps = from emp in context.employe
                                                   where emp.IsDeleted == false && emp.IsActive == true
                                                   select new SelectListItem
                                                   {
                                                       Value = emp.EmployeId.ToString(),
                                                       Text = emp.FirstName + " " + emp.LastName
                                                   };

                ViewData["ProjectId"] = new SelectList(items, "Value", "Text");
                ViewData["AssignedBy"] = new SelectList(emps, "Value", "Text");
                ViewData["AssignedTo"] = new SelectList(emps, "Value", "Text");
                return View();
            }
            
            
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