using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PropertyRent.Models;

namespace PropertyRent.Controllers
{
    public class EnquireController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enquire
        public ActionResult Index()
        {
            return View(db.Enquiries.ToList());
        }

        // GET: Enquire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.Enquiries.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // GET: Enquire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enquire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,DateSent")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                var users = db.Users.ToList();
                var properties = db.Properties.ToList();
                enquiryModel.Property = properties[0];

                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
                enquiryModel.User = currentUser; 

                db.Enquiries.Add(enquiryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enquiryModel);
        }

        // GET: Enquire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.Enquiries.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // POST: Enquire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,DateSent")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enquiryModel);
        }

        // GET: Enquire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryModel enquiryModel = db.Enquiries.Find(id);
            if (enquiryModel == null)
            {
                return HttpNotFound();
            }
            return View(enquiryModel);
        }

        // POST: Enquire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnquiryModel enquiryModel = db.Enquiries.Find(id);
            db.Enquiries.Remove(enquiryModel);
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
