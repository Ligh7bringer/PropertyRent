using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyRent.Models;

namespace PropertyRent.Controllers
{
    public class AvailablePropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AvailableProperties
        public ActionResult Index()
        {
            return View(db.Properties.ToList());
        }

        // GET: AvailableProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyIdentity propertyIdentity = db.Properties.Find(id);
            if (propertyIdentity == null)
            {
                return HttpNotFound();
            }
            return View(propertyIdentity);
        }

        // GET: AvailableProperties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailableProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Location,Price,DateCreated")] PropertyIdentity propertyIdentity)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(propertyIdentity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyIdentity);
        }

        // GET: AvailableProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyIdentity propertyIdentity = db.Properties.Find(id);
            if (propertyIdentity == null)
            {
                return HttpNotFound();
            }
            return View(propertyIdentity);
        }

        // POST: AvailableProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Location,Price,DateCreated")] PropertyIdentity propertyIdentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyIdentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyIdentity);
        }

        // GET: AvailableProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyIdentity propertyIdentity = db.Properties.Find(id);
            if (propertyIdentity == null)
            {
                return HttpNotFound();
            }
            return View(propertyIdentity);
        }

        // POST: AvailableProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyIdentity propertyIdentity = db.Properties.Find(id);
            db.Properties.Remove(propertyIdentity);
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
