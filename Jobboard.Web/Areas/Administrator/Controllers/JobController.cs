using Jobboard.Web.Models;
using Jobboard.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Areas.Administrator.Controllers
{
    public class JobController : Controller
    {
        DataContext db = new DataContext();


        // GET: Administrator/News
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        public ActionResult Create()
        {
           // ViewBag.SelectList = db.Jobs.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Job model, HttpPostedFileBase PictureFile)
        {
            string DefaultAddress = "";
            if (PictureFile != null)
            {
                DefaultAddress = "/Upload/job/" + Guid.NewGuid().ToString();

                PictureFile.SaveAs(Server.MapPath( "~"+ DefaultAddress));

                model.PictureUrl = DefaultAddress;

            }
            db.Jobs.Add(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(db.Jobs.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(Job model, HttpPostedFileBase PictureFile)
        {
            Job Data = db.Jobs.Find(model.Id);

            if (PictureFile != null)
            {
                FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
                if (info.Exists)
                {
                    info.Delete();
                }

                string DefaultAddress = "/Upload/job/" + Guid.NewGuid().ToString();

                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));

                Data.PictureUrl = DefaultAddress;

            }

           Data.JobTitle = model.JobTitle;

            Data.JobType = model.JobType;

            Data.JobRegion = model.JobRegion;

            Data.Location = model.Location;

            Data.CompanyName = model.CompanyName;

           // Data.PictureUrl = model.PictureUrl;

            db.SaveChanges();

            return RedirectToAction("index");

        }

        public ActionResult Delete(long Id)
        {
            Job Data = db.Jobs.Find(Id);
            FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
            if (info.Exists)
            {
                info.Delete();
            }
            db.Jobs.Remove(Data);

            db.SaveChanges();
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}