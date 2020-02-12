using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using website_emp.Models;

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
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                IEnumerable<Employe> result = (from user in _context.employe
                             where user.UserName == username && user.Password == password
                             && user.IsActive == true && user.IsDeleted == false
                             select user).ToList();
                if (result.Count() > 0) {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(username, true);
                    Employe emp = result.AsEnumerable().FirstOrDefault();
                    Session["name"] = emp.FirstName + emp.LastName;
                    Session["picture"] = emp.Picture;
                    return RedirectToAction("Index", "Dashboard");
                } 
            }
            ViewBag.msg = "Wrong username or password";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Signup()
        {
            IEnumerable<SelectListItem> shifts = (from i in _context.shift
                                                  where i.IsDeleted.Value == false
                                                  select new SelectListItem
                                                  {
                                                      Text = i.ShiftName,
                                                      Value = i.ShiftId.ToString(),
                                                  }
                                           ).ToList<SelectListItem>();
            IEnumerable<SelectListItem> st = (from k in _context.salarytemplate
                                              where k.IsDeleted.Value == false
                                              select new SelectListItem
                                              {
                                                  Text = k.TemplateName,
                                                  Value = k.SalaryTemplateId.ToString()
                                              }
                                              ).ToList<SelectListItem>();
            IEnumerable<SelectListItem> dep = (from deps in _context.department
                                           where deps.IsDeleted == false
                                           select new SelectListItem
                                           {
                                               Text = deps.DepartmentName,
                                               Value = deps.DepartmentId.ToString()
                                           }
                                           ).ToList<SelectListItem>();
            ViewData["DepartmentId"]= new SelectList(dep,"Value", "Text");
            ViewData["ShiftId"] = new SelectList(shifts,"Value", "Text"); 
            ViewData["SalaryTemplateId"] = new SelectList(st, "Value", "Text");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signup(Employe emp)
        {
            MentainanceCounter counter = _context.counter.Where(p => p.TableName == "Employe").Select(p => p).FirstOrDefault();
            counter.Count++;
            emp.EmployeId = counter.Count;
            _context.SaveChanges();

            emp.CreatedOn = DateTime.Now;
            emp.department = _context.department.Find(emp.Departmentid);
            emp.shift = _context.shift.Find(emp.ShiftId);
            emp.salarytemplate = _context.salarytemplate.Find(emp.SalaryTemplateId);
           try
            {
               if (ModelState.IsValid)
                {
                    _context.employe.Add(emp);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }

            }catch (Exception ex)
            { }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["name"] = null;
            Session["picture"] = null;
            return RedirectToAction("Login", "Home");
        }
        public ActionResult dashboard()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult getUserNames()
        {

            IEnumerable<string> names = from name in _context.employe
                                        select name.UserName;
                return Json(new { names = names });
            
        }

    }
}