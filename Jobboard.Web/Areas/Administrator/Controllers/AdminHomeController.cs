﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Areas.Administrator.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Administrator/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}