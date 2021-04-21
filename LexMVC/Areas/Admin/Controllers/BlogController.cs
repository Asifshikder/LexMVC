using LexMVC.Helpers;
using LexMVC.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.IO;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public BlogController()
        {

        }
        [HttpGet]
        public ActionResult Index()
        {
            var BlogList = db.BlogPost.ToList();
            return View(BlogList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogPostVM Blog, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Blog.BlogImage = FileUpload(file);
            }
            
            BlogPost model = new BlogPost();
            model.BlogTitle = Blog.BlogTitle;
            model.BlogImage = Blog.BlogImage;
            model.Content = Blog.Content;
            model.PostTime = DateTime.Now;
            db.BlogPost.Add(model);
            db.SaveChanges();
            return Redirect("/admin/Blog/Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Blog = db.BlogPost.Where(s => s.BlogId == id).FirstOrDefault();
            return View(Blog);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Blog = db.BlogPost.Where(s => s.BlogId == id).FirstOrDefault();
            BlogPostVM model = new BlogPostVM();
            model.BlogId = Blog.BlogId;
            model.BlogTitle = Blog.BlogTitle;
            model.PostTime = DateTime.Now;
            model.BlogImage = Blog.BlogImage;
            model.Content = Blog.Content;
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogPostVM Blog, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Blog.BlogImage = FileUpdate(Blog.BlogImage, file);
            }

            BlogPost model = new BlogPost();
            model.BlogId = Blog.BlogId;
            model.BlogTitle = Blog.BlogTitle;
            model.PostTime = DateTime.Now;
            model.BlogImage = Blog.BlogImage;
            model.Content = Blog.Content;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Blog/Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Blog = db.BlogPost.Where(s => s.BlogId == id).FirstOrDefault();
            return View(Blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(BlogPost Blog)
        {
            if(Blog.BlogImage != null)
                FileDelete(Blog.BlogImage);
            if (!db.BlogPost.Local.Contains(Blog))
            {
                db.BlogPost.Attach(Blog);
            }
            db.BlogPost.Remove(Blog);
            db.SaveChanges();
            return Redirect("/admin/Blog/Index");
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
