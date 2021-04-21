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
    public class PrivacyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public PrivacyController()
        {

        }
        public ActionResult Index()
        {
            var list = db.Privacy.FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Privacy model)
        {
            db.Privacy.Add(model);
            db.SaveChanges();
            return Redirect("/admin/Privacy/Index");
        }
        public ActionResult Edit()
        {
            var model = db.Privacy.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Privacy model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Privacy/Index");
        }
    }
}
