using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Controllers
{
    public class PostJobController : Controller
    {
        // GET: PostJob
        public ActionResult Index()
        {
            return View();
        }
    }
}