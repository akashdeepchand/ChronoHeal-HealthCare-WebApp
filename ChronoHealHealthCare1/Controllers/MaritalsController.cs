using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChronoHealHealthCare1.Models;

namespace ChronoHealHealthCare1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MaritalsController : Controller
    {
        private ChronoHealDbEntities db = new ChronoHealDbEntities();

        // GET: Maritals
        public ActionResult Index()
        {
            return View(db.Maritals.ToList());
        }

        // GET: Maritals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marital marital = db.Maritals.Find(id);
            if (marital == null)
            {
                return HttpNotFound();
            }
            return View(marital);
        }

        // GET: Maritals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maritals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MId,MStatus")] Marital marital)
        {
            if (ModelState.IsValid)
            {
                db.Maritals.Add(marital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marital);
        }

        // GET: Maritals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marital marital = db.Maritals.Find(id);
            if (marital == null)
            {
                return HttpNotFound();
            }
            return View(marital);
        }

        // POST: Maritals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MId,MStatus")] Marital marital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marital);
        }

        // GET: Maritals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marital marital = db.Maritals.Find(id);
            if (marital == null)
            {
                return HttpNotFound();
            }
            return View(marital);
        }

        // POST: Maritals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marital marital = db.Maritals.Find(id);
            db.Maritals.Remove(marital);
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
