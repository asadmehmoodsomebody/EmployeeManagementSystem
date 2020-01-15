using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website_emp.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration

        public ActionResult UserProfile()
        {
            return View();
        }
        






        public ActionResult ManageRoles()
        {
            return View();
        }
    }
}