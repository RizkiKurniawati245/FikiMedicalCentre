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
    public class mskaryawansController : Controller
    {
        private FIKIEntities db = new FIKIEntities();

        // GET: mskaryawans
        public ActionResult Index()
        {
            var mskaryawans = db.mskaryawans.Include(m => m.msrole);
            return View(mskaryawans.ToList());
        }

        // GET: mskaryawans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mskaryawan mskaryawan = db.mskaryawans.Find(id);
            if (mskaryawan == null)
            {
                return HttpNotFound();
            }
            return View(mskaryawan);
        }

        // GET: mskaryawans/Create
        public ActionResult Create()
        {
            ViewBag.id_role = new SelectList(db.msroles, "id_role", "deskripsi");
            return View();
        }

        // POST: mskaryawans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_karyawan,nama,tempat_lahir,tgl_lahir,jenis_kelamin,alamat,no_telp,email,id_role,username,password,status")] mskaryawan mskaryawan)
        {
            if (ModelState.IsValid)
            {
                mskaryawan.status = 1;
                db.mskaryawans.Add(mskaryawan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_role = new SelectList(db.msroles, "id_role", "deskripsi", mskaryawan.id_role);
            return View(mskaryawan);
        }

        // GET: mskaryawans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mskaryawan mskaryawan = db.mskaryawans.Find(id);
            if (mskaryawan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_role = new SelectList(db.msroles, "id_role", "deskripsi", mskaryawan.id_role);
            return View(mskaryawan);
        }

        // POST: mskaryawans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_karyawan,nama,tempat_lahir,tgl_lahir,jenis_kelamin,alamat,no_telp,email,id_role,username,password,status")] mskaryawan mskaryawan)
        {
            if (ModelState.IsValid)
            {
                mskaryawan.status = 1;
                db.Entry(mskaryawan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_role = new SelectList(db.msroles, "id_role", "deskripsi", mskaryawan.id_role);
            return View(mskaryawan);
        }

        // GET: mskaryawans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mskaryawan mskaryawan = db.mskaryawans.Find(id);
            if (mskaryawan == null)
            {
                return HttpNotFound();
            }
            return View(mskaryawan);
        }

        // POST: mskaryawans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mskaryawan mskaryawan = db.mskaryawans.Find(id);
            mskaryawan.status = 0;
            db.Entry(mskaryawan).State = EntityState.Modified;
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
