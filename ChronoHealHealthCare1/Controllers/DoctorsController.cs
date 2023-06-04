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
    public class DoctorsController : Controller
    {
        private ChronoHealDbEntities db = new ChronoHealDbEntities();

        // GET: Doctors
        
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Department).Include(d => d.Timing1).Include(d => d.Ward1);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Dep = new SelectList(db.Departments, "DepId", "Department1");
            ViewBag.Timing = new SelectList(db.Timings, "TId", "Timing1");
            ViewBag.Ward = new SelectList(db.Wards, "WId", "WardNo");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "DId,DName,Dep,Timing,Ward")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dep = new SelectList(db.Departments, "DepId", "Department1", doctor.Dep);
            ViewBag.Timing = new SelectList(db.Timings, "TId", "Timing1", doctor.Timing);
            ViewBag.Ward = new SelectList(db.Wards, "WId", "WardNo", doctor.Ward);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dep = new SelectList(db.Departments, "DepId", "Department1", doctor.Dep);
            ViewBag.Timing = new SelectList(db.Timings, "TId", "Timing1", doctor.Timing);
            ViewBag.Ward = new SelectList(db.Wards, "WId", "WardNo", doctor.Ward);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "DId,DName,Dep,Timing,Ward")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dep = new SelectList(db.Departments, "DepId", "Department1", doctor.Dep);
            ViewBag.Timing = new SelectList(db.Timings, "TId", "Timing1", doctor.Timing);
            ViewBag.Ward = new SelectList(db.Wards, "WId", "WardNo", doctor.Ward);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
