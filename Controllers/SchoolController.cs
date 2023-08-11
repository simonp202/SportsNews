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
    public class SchoolController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();

        // GET: School
        public ActionResult Index()
        {
            var tRUONGHOCs = db.TRUONGHOCs.Include(t => t.QUOCGIA);
            return View(tRUONGHOCs.ToList());
        }

        // GET: School/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUONGHOC tRUONGHOC = db.TRUONGHOCs.Find(id);
            if (tRUONGHOC == null)
            {
                return HttpNotFound();
            }
            return View(tRUONGHOC);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG");
            return View();
        }

        // POST: School/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATR,TENTR,DIACHITR,SDTTR,EMAILTR,NGDAOTAO,DIEMCHUAN,HOCPHI,MAQG")] TRUONGHOC tRUONGHOC)
        {
            if (ModelState.IsValid)
            {
                db.TRUONGHOCs.Add(tRUONGHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tRUONGHOC.MAQG);
            return View(tRUONGHOC);
        }

        // GET: School/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUONGHOC tRUONGHOC = db.TRUONGHOCs.Find(id);
            if (tRUONGHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tRUONGHOC.MAQG);
            return View(tRUONGHOC);
        }

        // POST: School/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATR,TENTR,DIACHITR,SDTTR,EMAILTR,NGDAOTAO,DIEMCHUAN,HOCPHI,MAQG")] TRUONGHOC tRUONGHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRUONGHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tRUONGHOC.MAQG);
            return View(tRUONGHOC);
        }

        // GET: School/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUONGHOC tRUONGHOC = db.TRUONGHOCs.Find(id);
            if (tRUONGHOC == null)
            {
                return HttpNotFound();
            }
            return View(tRUONGHOC);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRUONGHOC tRUONGHOC = db.TRUONGHOCs.Find(id);
            db.TRUONGHOCs.Remove(tRUONGHOC);
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
