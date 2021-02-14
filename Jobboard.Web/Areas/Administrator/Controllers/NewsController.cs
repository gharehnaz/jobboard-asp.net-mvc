using Jobboard.Web.Models;
using Jobboard.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Areas.Administrator.Controllers
{
    public class NewsController : Controller
    {
        DataContext db = new DataContext();
        
        
        // GET: Administrator/News
        public ActionResult Index()
        {
            return View(db.News.Include("NewsCategory").ToList());
        }

        public ActionResult Create()
        {
            ViewBag.SelectList =db.NewsCategory.Include("NewsEntities").ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(News model,HttpPostedFileBase PictureFile)
        {
            string DefaultAddress = "";
            if(PictureFile!=null)
            {
                DefaultAddress = "/Upload/News/" + Guid.NewGuid().ToString();

                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));

                model.PictureUrl = DefaultAddress;

            }
            db.News.Add(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(db.News.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(News model, HttpPostedFileBase PictureFile)
        {
            News Data = db.News.Find(model.Id);

            if (PictureFile != null)
            {
                FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
                if(info.Exists)
                {
                    info.Delete();
                }

                string DefaultAddress = "/Upload/News/" + Guid.NewGuid().ToString();
                
                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));

                Data.PictureUrl = DefaultAddress;

            }

            Data.Author = model.Author;

            Data.Description = model.Description;

            Data.NewsCategory_Id = model.NewsCategory_Id;

            Data.Title = model.Title;

            db.SaveChanges();

            return RedirectToAction("index");

        }

        public ActionResult Delete(long Id)
        {
            News Data = db.News.Find(Id);
            FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
            if (info.Exists)
            {
                info.Delete();
            }
            db.News.Remove(Data);

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