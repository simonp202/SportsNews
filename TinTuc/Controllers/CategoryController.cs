using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TinTuc.Models;

namespace TinTuc.Controllers
{
    public class CategoryController : Controller
    {
        private TinTucEntities db = new TinTucEntities();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.DMBanTins.ToList());
        }
        public ActionResult CatePartial()
        {
            return PartialView();
        }
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDM")] DMBanTin dMBanTin)
        {
            if (ModelState.IsValid)
            {
                db.DMBanTins.Add(dMBanTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMBanTin);
        }
        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMBanTin dMBanTin = db.DMBanTins.Find(id);
            db.DMBanTins.Remove(dMBanTin);
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
