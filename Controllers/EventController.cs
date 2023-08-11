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
    public class EventController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();

        // GET: Event
        public ActionResult Index()
        {
            var eVENTDUHOCs = db.EVENTDUHOCs.Include(e => e.QUOCGIA).Include(e => e.TRUONGHOC);
            return View(eVENTDUHOCs.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTDUHOC eVENTDUHOC = db.EVENTDUHOCs.Find(id);
            if (eVENTDUHOC == null)
            {
                return HttpNotFound();
            }
            return View(eVENTDUHOC);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG");
            ViewBag.MATR = new SelectList(db.TRUONGHOCs, "MATR", "TENTR");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAEV,TENEV,MAQG,MATR,THOIGIANTOCHUC")] EVENTDUHOC eVENTDUHOC)
        {
            if (ModelState.IsValid)
            {
                db.EVENTDUHOCs.Add(eVENTDUHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", eVENTDUHOC.MAQG);
            ViewBag.MATR = new SelectList(db.TRUONGHOCs, "MATR", "TENTR", eVENTDUHOC.MATR);
            return View(eVENTDUHOC);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTDUHOC eVENTDUHOC = db.EVENTDUHOCs.Find(id);
            if (eVENTDUHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", eVENTDUHOC.MAQG);
            ViewBag.MATR = new SelectList(db.TRUONGHOCs, "MATR", "TENTR", eVENTDUHOC.MATR);
            return View(eVENTDUHOC);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAEV,TENEV,MAQG,MATR,THOIGIANTOCHUC")] EVENTDUHOC eVENTDUHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTDUHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", eVENTDUHOC.MAQG);
            ViewBag.MATR = new SelectList(db.TRUONGHOCs, "MATR", "TENTR", eVENTDUHOC.MATR);
            return View(eVENTDUHOC);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTDUHOC eVENTDUHOC = db.EVENTDUHOCs.Find(id);
            if (eVENTDUHOC == null)
            {
                return HttpNotFound();
            }
            return View(eVENTDUHOC);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTDUHOC eVENTDUHOC = db.EVENTDUHOCs.Find(id);
            db.EVENTDUHOCs.Remove(eVENTDUHOC);
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
