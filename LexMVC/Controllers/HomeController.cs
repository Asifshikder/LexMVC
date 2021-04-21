using LexMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace LexMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public HomeController()
        {  
        }

        public ActionResult Index()
        {
            //List<Product> products = new List<Product>();
            //var product = new Product()
            //{
            //    ProductId = 1,
            //    ProductName = "Test",
            //    CartDescription = "test",
            //    Description = "test",
            //    OtherDescription = "test"
            //};
            //products.Add(product);
            //if (db.Product.Where(s => s.IsFeature == true).Count() == 0 )
            //    return View(products);
            var ffprod = db.Product.Where(s => s.IsFeature == true).ToList();
            return View(ffprod);
        }

        public ActionResult Privacy()
        {
            var model = db.Privacy.FirstOrDefault();
            return View(model);
        }
        public ActionResult Contact()
        {
            var model = db.ContactUs.FirstOrDefault();
            return View(model);
        }
        public ActionResult Aboutus()
        {
            var model = db.AboutUs.FirstOrDefault();
            return View(model);
        }
        public ActionResult Search(string search)
        {
            var prod = db.Product.Where(s => s.ProductName.Contains(search) || s.Description.Contains(search)).ToList();
            ViewBag.keyword = search;
            return View(prod);
        }
    }
}