using LexMVC.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class NavlinkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public NavlinkController()
        {
        }
        public ActionResult Index()
        {
            var list = db.NavlinkSetup.FirstOrDefault();
            NavlinkVM navlink = new NavlinkVM();

            if (list != null)
            {
                navlink.Id = list.SetupId;
                navlink.BasicName = db.Product.Where(s => s.ProductId == list.BasicProductId).FirstOrDefault().ProductName;
                navlink.AdvanceName = db.Product.Where(s => s.ProductId == list.AdvanceProductId).FirstOrDefault().ProductName;
                navlink.UltimateName = db.Product.Where(s => s.ProductId == list.UltimateProductId).FirstOrDefault().ProductName;
            }
            else
            {
                navlink = null;
            }
            return View(navlink);
        }
        public ActionResult Create()
        {

            ViewBag.products = new SelectList(db.Product.Select(s => new { Id = s.ProductId, Name = s.ProductName }), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NavlinkSetup model)
        {
            db.NavlinkSetup.Add(model);
            db.SaveChanges();
            return Redirect("/admin/Navlink/Index");
        }
        public ActionResult Edit()
        {
            ViewBag.products = new SelectList(db.Product.Select(s => new { Id = s.ProductId, Name = s.ProductName }), "Id", "Name");

            var model = db.NavlinkSetup.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NavlinkSetup model)
        {

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Navlink/Index");
        }
    }
    public class NavlinkVM
    {
        public int Id { get; set; }
        public string BasicName { get; set; }
        public string AdvanceName { get; set; }
        public string UltimateName { get; set; }


    }

}
