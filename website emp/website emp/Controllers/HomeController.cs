using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;
using website_emp.Models.ViewModels;

namespace website_emp.Controllers
{
    public class HomeController : Controller
    {
        private Context _context = new Context();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                var result = from user in _context.employe
                             where user.UserName == username && password == user.Password
                             && user.IsActive == true && user.IsDeleted == false
                             select user;
                if (result.Count() > 0) return Redirect("Dashboard/Index");
            }
            ViewBag.msg = "Wrong username or password";
            return View();
        }
        
        public ActionResult Signup()
        {

            var departments = (from dep in _context.department
                              where dep.Deleted == false
                              select new SelectListItem {Text= dep.DepartmentName, Value = dep.DepartmentId.ToString() }).ToList();
            ViewData["DepartmentId"] = new SelectList(departments, "Value", "Text");

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Employe emp)
        {
           try
            {
                emp.IsActive = null;
                emp.IsDeleted = false;
                emp.Createdon = DateTime.Now;
                _context.employe.Add(emp);
                _context.SaveChangesAsync();
                return Redirect("Dashboard/Index");

            }catch (Exception ex)
            {

            }
                
            var departments = (from dep in _context.department
                               where dep.Deleted == false
                               select new SelectListItem { Text = dep.DepartmentName, Value = dep.DepartmentId.ToString() }).ToList();
            ViewData["DepartmentId"] = new SelectList(departments, "Value", "Text");
            return View();
        }
        
        public ActionResult dashboard()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getUserNames()
        {

            IEnumerable<string> names = from name in _context.employe
                                        select name.UserName;
                return Json(new { names = names });
            
        }

    }
}