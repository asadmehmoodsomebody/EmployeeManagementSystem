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
                IEnumerable<Employe> result = (from user in _context.employe
                             where user.UserName == username && user.Password == password
                             && user.IsActive == true && user.IsDeleted == false
                             select user).ToList();
                if (result.Count() > 0) return RedirectToAction("Index","Dashboard");
            }
            ViewBag.msg = "Wrong username or password";
            return View();
        }
        
        public ActionResult Signup()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Signup(Employe emp)
        {
           try
            {
               

            }catch (Exception ex)
            {

            }
                
           
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