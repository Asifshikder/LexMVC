using LexMVC.Areas.Admin.Models;
using LexMVC.Helpers;
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
    public class SiteSettingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public SiteSettingController()
        {

        }
        public ActionResult Index()
        {
            var list = db.SiteSetting.FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteSetting SiteSetting)
        {
            db.SiteSetting.Add(SiteSetting);
            db.SaveChanges();
            return Redirect("/admin/SiteSetting/Index");
        }
        public ActionResult Edit()
        {
            var model = db.SiteSetting.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SiteSetting SiteSetting)
        {
            db.Entry(SiteSetting).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/SiteSetting/Index");
        }
    }
}
