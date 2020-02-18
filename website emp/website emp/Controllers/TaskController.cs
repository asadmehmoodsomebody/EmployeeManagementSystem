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
        public ActionResult Index(string search, int? pagenumber)
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
            if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            Pagination<Task> page = Pagination<Task>.Paged(tasks, pagenumber.Value, 10);
            return View(page);
        }
        [Route("Task/ViewAllTasks")]
        public ActionResult Tasks(string search,int? pagenumber)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            IEnumerable<Task> tasks = (from task in context.task
                                       where task.Deleted == false
                                       && task.AssingedToId == emp.EmployeId
                                       orderby task.StartDate descending
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
           if (!pagenumber.HasValue)
            {
                pagenumber = 1;
            }
            ViewData["pagenumber"] = pagenumber.Value;
            Pagination<Task> page = Pagination<Task>.Paged(tasks, pagenumber.Value, 10);
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
        public ActionResult Edit(long? taskid)
        {
            var task = (from i in context.task
                        where i.TaskId == taskid.Value
                        select i
                        ).FirstOrDefault();
            SelectList status = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Value = "Pending",Text="Pending" },
                new SelectListItem {Value= "Ongoing", Text="Ongoing" ,Selected=true},
                new SelectListItem {Value="Completed",Text="Completed" }
            },"Value","Text",task.Status);
            SelectList type = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Value = "Bug",Text="Bug" },
                new SelectListItem {Value= "New", Text="New" }
            }, "Value", "Text", task.Type);
            SelectList priority = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Value = "High",Text="High" },
                new SelectListItem {Value= "Meduim", Text="Meduim" },
                new SelectListItem {Value="Low",Text="Low" }
            }, "Value", "Text", task.Priority);
            var projs = (from i in context.project
                         where i.Deleted == false
                         select new SelectListItem
                         {
                             Value = i.ProjectId.ToString(),
                             Text = i.ProjectTitle.ToString()
                         }
                         ).ToList();
            SelectList project = new SelectList(projs, "Value", "Text", task.ProjectId.ToString());
            ViewBag.status = status;
            ViewBag.type = type;
            ViewBag.priority = priority;
            ViewBag.project = project;
            return View(task);
        }
        [HttpPost]
        [Route("Task/EditTask")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Task task)
        {
            var emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var _task = context.task.Find(task.TaskId);
            task.Createdby = _task.Createdby;
            task.Createdon = _task.Createdon;
            task.project = context.project.Find(task.ProjectId);
            task.ModifiedBy = emp.EmployeId;
            task.Modifiedon = DateTime.Now;
            context.Entry(_task).CurrentValues.SetValues(task);
            context.SaveChanges();
            return RedirectToAction("ViewAllTasks", "Task");
        }
        public ActionResult UpdateTask (long? taskid)
        {
            if (taskid.HasValue)
            {
                var task = (from i in context.task
                            where i.TaskId == taskid.Value
                            select i
                            ).FirstOrDefault();
                return View(task);
            }else
            {
                return RedirectToAction("ViewAllTasks");
            }
        }
        [HttpPost]
        public ActionResult UpdateTask (Task task)
        {
            Employe emp = context.employe.Where(p => p.UserName == User.Identity.Name).Select(p => p).FirstOrDefault();
            var _task = context.task.Find(task.TaskId);
            _task.Modifiedon = DateTime.Now;
            _task.ModifiedBy = emp.EmployeId;
            _task.Status = task.Status;
            _task.StatusDescription = task.StatusDescription;
            if (task.Status == "Completed")
                _task.CompletionTime = DateTime.Now;
            context.Entry(_task).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return View();
        }
        

    }
}