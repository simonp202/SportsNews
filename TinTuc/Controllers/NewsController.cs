using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TinTuc.Models;

namespace TinTuc.Controllers
{
    public class NewsController : Controller
    {
        private TinTucEntities db = new TinTucEntities();

        // GET: News
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var banTins = db.BanTins.Include(b => b.Admin).Include(b => b.DMBanTin);

                return View(banTins.ToList());
            }
            
            return RedirectToAction("Index", "Admin");
        }
        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.TKAdmin = new SelectList(db.Admins, "UserName", "UserName");
            ViewBag.MaDM = new SelectList(db.DMBanTins, "ID", "TenDM");

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BanTin banTin)
        {
            banTin.TKAdmin = Session["Admin"].ToString().Trim();
            banTin.SoSao = 0;
            if (ModelState.IsValid)
            {
                if(banTin.UploadImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(banTin.UploadImage.FileName);
                    string extension = Path.GetExtension(banTin.UploadImage.FileName);
                    fileName += extension;
                    banTin.HinhAnh = fileName;
                    banTin.UploadImage.SaveAs(Path.Combine(Server.MapPath(BanTin.SERVER_IMG_PATH), fileName));
                }
                db.BanTins.Add(banTin);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.TKAdmin = new SelectList(db.Admins, "UserName", "UserName", banTin.TKAdmin);
            ViewBag.MaDM = new SelectList(db.DMBanTins, "ID", "TenDM", banTin.MaDM);

            return View(banTin);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanTin banTin = db.BanTins.Find(id);
            if (banTin == null)
            {
                return HttpNotFound();
            }
            ViewBag.TKAdmin = new SelectList(db.Admins, "UserName", "UserName", banTin.TKAdmin);
            ViewBag.MaDM = new SelectList(db.DMBanTins, "ID", "TenDM", banTin.MaDM);

            return View(banTin);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BanTin banTin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banTin).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.TKAdmin = new SelectList(db.Admins, "UserName", "UserName", banTin.TKAdmin);
            ViewBag.MaDM = new SelectList(db.DMBanTins, "ID", "TenDM", banTin.MaDM);

            return View(banTin);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanTin banTin = db.BanTins.Find(id);
            if (banTin == null)
            {
                return HttpNotFound();
            }

            return View(banTin);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BanTin banTin = db.BanTins.Find(id);
            db.BanTins.Remove(banTin);
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
