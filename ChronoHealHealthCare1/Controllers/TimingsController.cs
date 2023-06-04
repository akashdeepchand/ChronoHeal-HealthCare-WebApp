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
    public class TimingsController : Controller
    {
        private ChronoHealDbEntities db = new ChronoHealDbEntities();

        // GET: Timings
        public ActionResult Index()
        {
            return View(db.Timings.ToList());
        }

        // GET: Timings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timing timing = db.Timings.Find(id);
            if (timing == null)
            {
                return HttpNotFound();
            }
            return View(timing);
        }

        // GET: Timings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TId,Timing1")] Timing timing)
        {
            if (ModelState.IsValid)
            {
                db.Timings.Add(timing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timing);
        }

        // GET: Timings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timing timing = db.Timings.Find(id);
            if (timing == null)
            {
                return HttpNotFound();
            }
            return View(timing);
        }

        // POST: Timings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TId,Timing1")] Timing timing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timing);
        }

        // GET: Timings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timing timing = db.Timings.Find(id);
            if (timing == null)
            {
                return HttpNotFound();
            }
            return View(timing);
        }

        // POST: Timings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timing timing = db.Timings.Find(id);
            db.Timings.Remove(timing);
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
