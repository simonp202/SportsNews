using System.Linq;
using System.Web.Mvc;
using TinTuc.Models;

namespace TinTuc.Controllers
{
    public class AdminController : Controller
    {
        private TinTucEntities db = new TinTucEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Manager()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Toolbox()
        {
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("K dex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            try
            {
                string authTmp = SHA256.ToSHA256(admin.Password);
                Admin checkLogin = db.Admins.FirstOrDefault(k => k.UserName == admin.UserName && k.Password == authTmp);
                if(checkLogin == null)
                {
                    ViewBag.Error = "Tài khoản không hợp lệ";

                    return View("Index");
                }
                else
                {
                    Session["Admin"] = checkLogin.UserName;

                    return RedirectToAction("Manager", "Admin");
                }
            }
            catch
            {
                ViewBag.Error = "Lỗi máy chủ";

                return View("Index");
            }
        }
    }
}