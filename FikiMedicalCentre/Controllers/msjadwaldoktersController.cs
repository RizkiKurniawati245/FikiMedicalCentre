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
    public class msjadwaldoktersController : Controller
    {
        private FIKIEntities db = new FIKIEntities();

        // GET: msjadwaldokters
        public ActionResult Index()
        {
            var msjadwaldokters = db.msjadwaldokters.Include(m => m.msdokter);
            return View(msjadwaldokters.ToList());
        }

        // GET: msjadwaldokters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msjadwaldokter msjadwaldokter = db.msjadwaldokters.Find(id);
            if (msjadwaldokter == null)
            {
                return HttpNotFound();
            }
            return View(msjadwaldokter);
        }

        // GET: msjadwaldokters/Create
        public ActionResult Create()
        {
            ViewBag.id_dokter = new SelectList(db.msdokters, "id_dokter", "nama");
            return View();
        }

        // POST: msjadwaldokters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_jadwal,hari,waktu_awal,waktu_akhir,id_dokter,status")] msjadwaldokter msjadwaldokter)
        {
            if (ModelState.IsValid)
            {
                msjadwaldokter.status = 1;
                db.msjadwaldokters.Add(msjadwaldokter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dokter = new SelectList(db.msdokters, "id_dokter", "nama", msjadwaldokter.id_dokter);
            return View(msjadwaldokter);
        }

        // GET: msjadwaldokters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msjadwaldokter msjadwaldokter = db.msjadwaldokters.Find(id);
            if (msjadwaldokter == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dokter = new SelectList(db.msdokters, "id_dokter", "nama", msjadwaldokter.id_dokter);
            return View(msjadwaldokter);
        }

        // POST: msjadwaldokters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_jadwal,hari,waktu_awal,waktu_akhir,id_dokter,status")] msjadwaldokter msjadwaldokter)
        {
            if (ModelState.IsValid)
            {
                msjadwaldokter.status = 1;
                db.Entry(msjadwaldokter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dokter = new SelectList(db.msdokters, "id_dokter", "nama", msjadwaldokter.id_dokter);
            return View(msjadwaldokter);
        }

        // GET: msjadwaldokters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msjadwaldokter msjadwaldokter = db.msjadwaldokters.Find(id);
            if (msjadwaldokter == null)
            {
                return HttpNotFound();
            }
            return View(msjadwaldokter);
        }

        // POST: msjadwaldokters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msjadwaldokter msjadwaldokter = db.msjadwaldokters.Find(id);
            msjadwaldokter.status = 0;
            db.Entry(msjadwaldokter).State = EntityState.Modified;
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
