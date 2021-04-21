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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ProductController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            var productList = db.Product.ToList();
            return View(productList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM product, HttpPostedFileBase FeatureImage1File,
                                                        HttpPostedFileBase FeatureImage2File,
                                                        HttpPostedFileBase FeatureImage3File,
                                                        HttpPostedFileBase FeatureImage4File,
                                                        HttpPostedFileBase FeatureImage5File,
                                                        HttpPostedFileBase ProfileImageFile,
                                                        HttpPostedFileBase ProfileImage1File,
                                                        HttpPostedFileBase ProfileImage2File)
        {
            if (FeatureImage1File != null)
            {
                product.FeatureImage1 = FileUpload(FeatureImage1File);
            }
            if (FeatureImage2File != null)
            {
                product.FeatureImage2 = FileUpload(FeatureImage2File);
            }
            if (FeatureImage3File != null)
            {
                product.FeatureImage3 = FileUpload(FeatureImage3File);
            }
            if (FeatureImage4File != null)
            {
                product.FeatureImage4 = FileUpload(FeatureImage4File);
            }
            if (FeatureImage5File != null)
            {
                product.FeatureImage5 = FileUpload(FeatureImage5File);
            }
            if (ProfileImageFile != null)
            {
                product.ProfileImage = FileUpload(ProfileImageFile);
            }
            if (ProfileImage1File != null)
            {
                product.ProfileImage1 = FileUpload(ProfileImage1File);
            }
            if (ProfileImage2File != null)
            {
                product.ProfileImage2 = FileUpload(ProfileImage2File);
            }
            Product model = new Product();
            model.ProductName = product.ProductName;
            model.Description = product.Description;
            model.CartDescription = product.CartDescription;
            model.Amazonlink = product.Amazonlink;
            model.ProfileImage = product.ProfileImage;
            model.ProfileImage1 = product.ProfileImage1;
            model.ProfileImage2 = product.ProfileImage2;
            model.OtherDescription = product.OtherDescription;

            model.VideoName = product.VideoName;
            model.VideoUrl = product.VideoUrl;
            model.ShortDescription = product.ShortDescription;
            model.IsFeature = product.IsFeature;
            model.FeatureImage1 = product.FeatureImage1;
            model.FeatureImage2 = product.FeatureImage2;
            model.FeatureImage3 = product.FeatureImage3;
            model.FeatureImage4 = product.FeatureImage4;
            model.FeatureImage5 = product.FeatureImage5;
            db.Product.Add(model);
            db.SaveChanges();
            return Redirect("/admin/Product/Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Product.Where(s => s.ProductId == id).FirstOrDefault();
            ProductVM model = new ProductVM();
            model.ProductId = product.ProductId; model.Amazonlink = product.Amazonlink;

            model.ProductName = product.ProductName;
            model.Description = product.Description;
            model.ProfileImage = product.ProfileImage;
            model.ProfileImage1 = product.ProfileImage1;
            model.ProfileImage2 = product.ProfileImage2;
            model.OtherDescription = product.OtherDescription;
            model.VideoName = product.VideoName;
            model.VideoUrl = product.VideoUrl;
            model.ShortDescription = product.ShortDescription;
            model.IsFeature = product.IsFeature;
            model.FeatureImage1 = product.FeatureImage1; model.CartDescription = product.CartDescription;

            model.FeatureImage2 = product.FeatureImage2;
            model.FeatureImage3 = product.FeatureImage3;
            model.FeatureImage4 = product.FeatureImage4;
            model.FeatureImage5 = product.FeatureImage5;
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM product, HttpPostedFileBase FeatureImage1File,
                                                        HttpPostedFileBase FeatureImage2File,
                                                        HttpPostedFileBase FeatureImage3File,
                                                        HttpPostedFileBase FeatureImage4File,
                                                        HttpPostedFileBase FeatureImage5File,
                                                        HttpPostedFileBase ProfileImageFile,
                                                        HttpPostedFileBase ProfileImage1File,
                                                        HttpPostedFileBase ProfileImage2File)
        {
            if (FeatureImage1File != null)
            {
                product.FeatureImage1 = FileUpdate(product.FeatureImage1, FeatureImage1File);
            }
            if (FeatureImage2File != null)
            {
                product.FeatureImage2 = FileUpdate(product.FeatureImage2, FeatureImage2File);
            }
            if (FeatureImage3File != null)
            {
                product.FeatureImage3 = FileUpdate(product.FeatureImage3, FeatureImage3File);
            }
            if (FeatureImage4File != null)
            {
                product.FeatureImage4 = FileUpdate(product.FeatureImage4, FeatureImage4File);
            }
            if (FeatureImage5File != null)
            {
                product.FeatureImage5 = FileUpdate(product.FeatureImage5, FeatureImage5File);
            }
            if (ProfileImageFile != null)
            {
                product.ProfileImage = FileUpdate(product.ProfileImage, ProfileImageFile);
            }
            if (ProfileImage1File != null)
            {
                product.ProfileImage1 = FileUpdate(product.ProfileImage1, ProfileImage1File);
            }
            if (ProfileImage2File != null)
            {
                product.ProfileImage2 = FileUpdate(product.ProfileImage2, ProfileImage2File);
            }
            Product model = new Product();
            model.ProductId = product.ProductId;
            model.Amazonlink = product.Amazonlink;

            model.ProductName = product.ProductName;
            model.Description = product.Description;
            model.ProfileImage = product.ProfileImage;
            model.ProfileImage1 = product.ProfileImage1;
            model.ProfileImage2 = product.ProfileImage2;
            model.VideoName = product.VideoName;
            model.VideoUrl = product.VideoUrl;
            model.ShortDescription = product.ShortDescription;
            model.IsFeature = product.IsFeature;
            model.CartDescription = product.CartDescription;
            model.OtherDescription = product.OtherDescription;

            model.FeatureImage1 = product.FeatureImage1;
            model.FeatureImage2 = product.FeatureImage2;
            model.FeatureImage3 = product.FeatureImage3;
            model.FeatureImage4 = product.FeatureImage4;
            model.FeatureImage5 = product.FeatureImage5;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Product/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.Product.Where(s => s.ProductId == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            if (product.ProfileImage != null)
                FileDelete(product.ProfileImage);
            if (product.ProfileImage1 != null)
                FileDelete(product.ProfileImage1);
            if (product.ProfileImage2 != null)
                FileDelete(product.ProfileImage2);
            if (product.FeatureImage1 != null)
                FileDelete(product.FeatureImage1);
            if (product.FeatureImage2 != null)
                FileDelete(product.FeatureImage2);
            if (product.FeatureImage3 != null)
                FileDelete(product.FeatureImage3);
            if (product.FeatureImage4 != null)
                FileDelete(product.FeatureImage4);
            if (product.FeatureImage5 != null)
                FileDelete(product.FeatureImage5);
            if (!db.Product.Local.Contains(product))
            {
                db.Product.Attach(product);
            }
            db.Product.Remove(product);
            db.SaveChanges();
            return Redirect("/admin/Product/Index");
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
