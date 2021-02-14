using Jobboard.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Controllers
{
    public class JobSingleController : Controller
    {
        // GET: JobSingle
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }
    }
}