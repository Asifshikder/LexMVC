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
    public class EmailTemplateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public EmailTemplateController()
        {

        }
        public ActionResult Index()
        {
            var list = db.MailBodyContent.FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MailBodyContent model)
        {
            db.MailBodyContent.Add(model);
            db.SaveChanges();
            return Redirect("/admin/EmailTemplate/Index");
        }
        public ActionResult Edit()
        {
            var model = db.MailBodyContent.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MailBodyContent model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/EmailTemplate/Index");
        }
    }
}
