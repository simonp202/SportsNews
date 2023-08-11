using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TuVanDuHoc_v2.Models;

namespace TuVanDuHoc_v2.Controllers
{
    public class CountryController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();

        // GET: Country
        public ActionResult Index()
        {
            if(Session["admin"] != null)
                return View(db.QUOCGIAs.ToList());

            return RedirectToAction("Index", "Admin");
        }

        // GET: Country/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QUOCGIA qUOCGIA = db.QUOCGIAs.Find(id);
                if (qUOCGIA == null)
                {
                    return HttpNotFound();
                }
                return View(qUOCGIA);
            }

            return RedirectToAction("Index", "Admin");
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
                return View();

            return RedirectToAction("Index", "Admin");
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAQG,TENQG")] QUOCGIA qUOCGIA)
        {
            if (ModelState.IsValid)
            {
                qUOCGIA.MAQG = qUOCGIA.MAQG.Trim();
                db.QUOCGIAs.Add(qUOCGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUOCGIA);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QUOCGIA qUOCGIA = db.QUOCGIAs.Find(id);
                if (qUOCGIA == null)
                {
                    return HttpNotFound();
                }
                return View(qUOCGIA);
            }

            return RedirectToAction("Index", "Admin");
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAQG,TENQG")] QUOCGIA qUOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUOCGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUOCGIA);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QUOCGIA qUOCGIA = db.QUOCGIAs.Find(id);
                if (qUOCGIA == null)
                {
                    return HttpNotFound();
                }
                return View(qUOCGIA);
            }

            return RedirectToAction("Index", "Admin");
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUOCGIA qUOCGIA = db.QUOCGIAs.Find(id);
            db.QUOCGIAs.Remove(qUOCGIA);
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
