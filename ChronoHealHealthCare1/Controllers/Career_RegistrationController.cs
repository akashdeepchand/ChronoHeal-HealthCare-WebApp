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
    public class Career_RegistrationController : Controller
    {
        private ChronoHealDbEntities db = new ChronoHealDbEntities();

        // GET: Career_Registration
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var career_Registration = db.Career_Registration.Include(c => c.Gender1).Include(c => c.Marital).Include(c => c.State);
            return View(career_Registration.ToList());
        }

        // GET: Career_Registration/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career_Registration career_Registration = db.Career_Registration.Find(id);
            if (career_Registration == null)
            {
                return HttpNotFound();
            }
            return View(career_Registration);
        }

        // GET: Career_Registration/Create
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(db.Genders, "GId", "gender1");
            ViewBag.MartialStatus = new SelectList(db.Maritals, "MId", "MStatus");
            ViewBag.State1 = new SelectList(db.States, "StateId", "States");
            return View();
        }

        // POST: Career_Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create([Bind(Include = "CRId,CRName,Gender,Contact,Email,MartialStatus,Aadhar,DateOfBirth,Addrss,City,State1,DoctorRegistration,Qualification,EducationBoard,Specialization,ExperienceInYears,CRId1")] Career_Registration career_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Career_Registration.Add(career_Registration);
                db.SaveChanges();
                return RedirectToAction("Details/" + career_Registration.CRId);
            }

            ViewBag.Gender = new SelectList(db.Genders, "GId", "gender1", career_Registration.Gender);
            ViewBag.MartialStatus = new SelectList(db.Maritals, "MId", "MStatus", career_Registration.MartialStatus);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", career_Registration.State1);
            return View(career_Registration);
        }

        // GET: Career_Registration/Edit/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career_Registration career_Registration = db.Career_Registration.Find(id);
            if (career_Registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(db.Genders, "GId", "gender1", career_Registration.Gender);
            ViewBag.MartialStatus = new SelectList(db.Maritals, "MId", "MStatus", career_Registration.MartialStatus);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", career_Registration.State1);
            return View(career_Registration);
        }

        // POST: Career_Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Edit([Bind(Include = "CRId,CRName,Gender,Contact,Email,MartialStatus,Aadhar,DateOfBirth,Addrss,City,State1,DoctorRegistration,Qualification,EducationBoard,Specialization,ExperienceInYears,CRId1")] Career_Registration career_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(career_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/"+career_Registration.CRId);
            }
            ViewBag.Gender = new SelectList(db.Genders, "GId", "gender1", career_Registration.Gender);
            ViewBag.MartialStatus = new SelectList(db.Maritals, "MId", "MStatus", career_Registration.MartialStatus);
            ViewBag.State1 = new SelectList(db.States, "StateId", "States", career_Registration.State1);
            return View(career_Registration);
        }

        // GET: Career_Registration/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career_Registration career_Registration = db.Career_Registration.Find(id);
            if (career_Registration == null)
            {
                return HttpNotFound();
            }
            return View(career_Registration);
        }

        // POST: Career_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Career_Registration career_Registration = db.Career_Registration.Find(id);
            db.Career_Registration.Remove(career_Registration);
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
