﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website_emp.Controllers
{
    public class NoticeBoardController : Controller
    {
        // GET: NoticeBoard
        public ActionResult Notice_Board()
        {
            return View();
        }
    }
}