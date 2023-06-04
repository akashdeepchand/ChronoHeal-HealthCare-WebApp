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
    public class AppointmentsController : Controller
    {
        private ChronoHealDbEntities db = new ChronoHealDbEntities();

        // GET: Appointments
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Gender).Include(a => a.State);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create()
        {
            ViewBag.AGender = new SelectList(db.Genders, "GId", "gender1");
            ViewBag.State1 = new SelectList(db.States, "StateId", "States");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create([Bind(Include = "AId,AFName,ALName,AContact,AEmail,ASymptoms,ADate,RecieptId,AGender,DOB,Addrss,City,State1")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Details/"+appointment.AId);
            }

            ViewBag.AGender = new SelectList(db.Genders, "GId", "gender1", appointment.AGender);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", appointment.State1);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AGender = new SelectList(db.Genders, "GId", "gender1", appointment.AGender);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", appointment.State1);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "AId,AFName,ALName,AContact,AEmail,ASymptoms,ADate,RecieptId,AGender,DOB,Addrss,City,State1")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + appointment.AId);
            }
            ViewBag.AGender = new SelectList(db.Genders, "GId", "gender1", appointment.AGender);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", appointment.State1);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
