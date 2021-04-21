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
    public class EmailSettingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public EmailSettingController()
        {

        }
        public ActionResult Index()
        {
            var list = db.EmailSetting.FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmailSetting model)
        {
            db.EmailSetting.Add(model);
            db.SaveChanges();
            return Redirect("/admin/EmailSetting/Index");
        }
        public ActionResult Edit()
        {
            var model = db.EmailSetting.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmailSetting model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/EmailSetting/Index");
        }
    }
}
