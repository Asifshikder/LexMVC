using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexMVC.Models;

namespace LexMVC.Areas.Admin.Views
{
    public class AboutUsSCController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AboutUsSC
        public ActionResult Index()
        {
            return View(db.AboutUs.ToList());
        }

        // GET: Admin/AboutUsSC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // GET: Admin/AboutUsSC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutUsSC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutUsId,ImageUrl,Title,Details")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                db.AboutUs.Add(aboutUs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutUs);
        }

        // GET: Admin/AboutUsSC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/AboutUsSC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutUsId,ImageUrl,Title,Details")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutUs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutUs);
        }

        // GET: Admin/AboutUsSC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/AboutUsSC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutUs aboutUs = db.AboutUs.Find(id);
            db.AboutUs.Remove(aboutUs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
