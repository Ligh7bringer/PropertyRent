using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
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
            var currentUser = User.Identity.GetUserId();
            var userEnquiries = db.Enquiries.Where(x => x.User.Id == currentUser);
            return View(userEnquiries.ToList());
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
        public ActionResult Create(int? id)
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

            return View();
        }

        // POST: Enquire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "Id,Body,DateSent")] EnquiryModel enquiryModel)
        {
            if (ModelState.IsValid)
            {
                enquiryModel.Property = db.Properties.Find(id);

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
