using LexMVC.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class WarrantyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public WarrantyController()
        {
        }
        [HttpGet]
        public ActionResult Index()
        {
            var dfgsd =db.Warranty.ToList();
            return View(dfgsd);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var warranty = db.Warranty.Where(s => s.WarrantyId == id).FirstOrDefault();
            return View(warranty);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Warranty product)
        {
            if (!db.Warranty.Local.Contains(product))
            {
                db.Warranty.Attach(product);
            }
            db.Warranty.Remove(product);
            db.SaveChanges();
            return Redirect("/admin/warranty/Index");
        }



    }

    public class WarrantyVM
    {
        public int WarrantyId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string OrderCode { get; set; }
        public bool? IsLikePurchase { get; set; }
        public string PurchaseLike { get; set; }
        public DateTime? AvailDate { get; set; }
    }
}
