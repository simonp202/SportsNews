using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuVanDuHoc_v2.Models;

namespace TuVanDuHoc_v2.Controllers
{
    public class FileController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();

        // GET: File
        public ActionResult Index()
        {
            return View(db.HOSOes.ToList());
        }

        // GET: File/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSO hOSO = db.HOSOes.Find(id);
            if (hOSO == null)
            {
                return HttpNotFound();
            }
            return View(hOSO);
        }

        // GET: File/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: File/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKH,TENKH,DIACHIKH,SDTKH,NGAYSINH,GIOITINH")] HOSO hOSO)
        {
            if (ModelState.IsValid)
            {
                db.HOSOes.Add(hOSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOSO);
        }

        // GET: File/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSO hOSO = db.HOSOes.Find(id);
            if (hOSO == null)
            {
                return HttpNotFound();
            }
            return View(hOSO);
        }

        // POST: File/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKH,TENKH,DIACHIKH,SDTKH,NGAYSINH,GIOITINH")] HOSO hOSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOSO);
        }

        // GET: File/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSO hOSO = db.HOSOes.Find(id);
            if (hOSO == null)
            {
                return HttpNotFound();
            }
            return View(hOSO);
        }

        // POST: File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOSO hOSO = db.HOSOes.Find(id);
            db.HOSOes.Remove(hOSO);
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
