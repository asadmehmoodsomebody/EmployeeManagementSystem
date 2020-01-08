using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using website_emp.Models;

namespace website_emp.Controllers
{
    public class HomeController : Controller
    {
        public context db = new context();
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
            var data = from user in db.Users
                       where username == user.UserName && password == user.Password
                       select user;
            if (data.Count() > 0)
            {
                return Redirect("/Home/Index");
                
            }
            ViewBag.msg = "Wrong Username of Password";
            return View();
        }
        public ActionResult Signup()
        {
            ViewBag.key = "sendsomedata";

            IEnumerable<SelectListItem> deps = db.Departments.Select(p => new SelectListItem { Value = p.DepartmentId.ToString(), Text = p.DepartmentName });
            IEnumerable<SelectListItem> des = db.Designations.Select(p => new SelectListItem { Value = p.DesignationId.ToString(), Text = p.DesignationName });
            ViewBag.departments = new SelectList(deps, "Value", "Text");
            ViewBag.designations = new SelectList(des, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user User ,string Department,string Designation, string gender)
        {
            if (User.UserName != "" || User.Name != "" || User.Password != "" || User.Email != "")
            {
                try
                {
                    int depid = int.Parse(Department);
                    int desid = int.Parse(Designation);
                    department dep = db.Departments.FirstOrDefault(p => p.DepartmentId == depid);
                    designation des = db.Designations.FirstOrDefault(p => p.DesignationId == desid);
                    status st = db.States.FirstOrDefault(p => p.StatusId == 1);
                    string role = "Employ";
                    User.Role = role;
                    User.Status = st;
                    User.Department = dep;
                    User.Designation = des;
                    db.Users.Add(User);
                    db.SaveChanges();
                    return Redirect("dashboard");
                }
                catch(Exception ex)
                {
                    ViewBag.errormsg = "Some Thing Went Wrong";
                    return Signup();

                }
              
            }
            return Signup();
        }
        
        public ActionResult dashboard()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getUserNames(string data)
        {
            if (data == "sendsomedata") {
                var names = (from user in db.Users
                             select new { username =user.UserName , email=user.Email}).ToArray();
                return Json(new { data = names });
            }
            else
            {
                return Json(new { data = "HelloWOrld" });
            }
            
        }

    }
}