using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FikiMedicalCentre.Models;

namespace FikiMedicalCentre.Controllers
{
    public class msrolesController : Controller
    {
        private FIKIEntities db = new FIKIEntities();

        // GET: msroles
        public ActionResult Index()
        {
            return View(db.msroles.ToList());
        }

        // GET: msroles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msrole msrole = db.msroles.Find(id);
            if (msrole == null)
            {
                return HttpNotFound();
            }
            return View(msrole);
        }

        // GET: msroles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msroles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_role,deskripsi,status")] msrole msrole)
        {
            if (ModelState.IsValid)
            {
                msrole.status = 1;
                db.msroles.Add(msrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msrole);
        }

        // GET: msroles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msrole msrole = db.msroles.Find(id);
            if (msrole == null)
            {
                return HttpNotFound();
            }
            return View(msrole);
        }

        // POST: msroles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_role,deskripsi,status")] msrole msrole)
        {
            if (ModelState.IsValid)
            {
                msrole.status = 1;
                db.Entry(msrole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msrole);
        }

        // GET: msroles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msrole msrole = db.msroles.Find(id);
            if (msrole == null)
            {
                return HttpNotFound();
            }
            return View(msrole);
        }

        // POST: msroles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msrole msrole = db.msroles.Find(id);
            msrole.status = 0;
            db.Entry(msrole).State = EntityState.Modified;
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
