using LexMVC.Areas.Admin.Models;
using LexMVC.Helpers;
using LexMVC.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ContactController()
        {

        }
        public ActionResult Index()
        {
            var list = db.ContactUs.FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactUs contactUs)
        {
            db.ContactUs.Add(contactUs);
            db.SaveChanges();
            return Redirect("/admin/Contact/Index");
        }
        public ActionResult Edit()
        {
            var model = db.ContactUs.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactUs contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/admin/Contact/Index");
        }
    }
}
