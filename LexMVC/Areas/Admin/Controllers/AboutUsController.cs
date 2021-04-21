using LexMVC.Helpers;
using LexMVC.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexMVC.Areas.Admin.Models;
using System.Data.Entity;
using System.Web;
using System.IO;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class AboutUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public AboutUsController()
        {

        }

        public ActionResult Index()
        {
            var list = db.AboutUs.FirstOrDefault();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutUsModel aboutUs, HttpPostedFileBase file)
        {
            if (file != null)
            {
                aboutUs.ImageUrl = FileUpload(file);
            }
            AboutUs model = new AboutUs();
            model.Title = aboutUs.Title;
            model.Details = aboutUs.Details;
            model.ImageUrl = aboutUs.ImageUrl;
            db.AboutUs.Add(model);
            db.SaveChanges();
            return Redirect("/admin/Aboutus/Index");
        }

        public ActionResult Edit()
        {
            var model = db.AboutUs.FirstOrDefault();
            AboutUsModel aboutUs = new AboutUsModel();
            aboutUs.AboutUsId = model.AboutUsId;
            aboutUs.Title = model.Title;
            aboutUs.Details = model.Details;
            aboutUs.ImageUrl = model.ImageUrl;
            return View(aboutUs);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AboutUsModel aboutUs, HttpPostedFileBase file)
        {
            if (file != null)
            {
                aboutUs.ImageUrl = FileUpdate(aboutUs.ImageUrl, file);
            }
            AboutUs model = new AboutUs();
            model.AboutUsId = aboutUs.AboutUsId;
            model.Title = aboutUs.Title;
            model.Details = aboutUs.Details;
            model.ImageUrl = aboutUs.ImageUrl;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Aboutus/Index");
        }

        private string FileUpload(HttpPostedFileBase file)
        {
            Guid nameguid = Guid.NewGuid();
            string FileName = nameguid.ToString() + Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images"), FileName);
            file.SaveAs(path);

            return "~/Images/" + FileName;
        }
        
        private string FileUpdate(string fileURL, HttpPostedFileBase file)
        {
            if (fileURL != null)
            {
                string fileName = fileURL.Replace("~/Images/", "").ToString();
                string fullpath = Server.MapPath("~/Images") + "\\" + fileName;
                System.IO.File.Delete(fullpath);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Guid nameguid = Guid.NewGuid();
            string FileName = nameguid.ToString() + Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images"), FileName);
            file.SaveAs(path);

            return "~/Images/" + FileName;
        }
        
        private void FileDelete(string fileURL)
        {
            if (fileURL != null)
            {
                string fileName = fileURL.Replace("~/Images/", "").ToString();
                string fullpath = Server.MapPath("~/Images") + "\\" + fileName;
                System.IO.File.Delete(fullpath);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
