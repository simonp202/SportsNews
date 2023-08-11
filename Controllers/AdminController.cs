using System.Linq;
using System.Web.Mvc;
using TuVanDuHoc_v2.Models;
using System.Collections.Generic;

namespace TuVanDuHoc_v2.Controllers
{
    public class AdminController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();

        // GET: Admin
        public ActionResult Index()
        {
            if(Session["admin"] != null)
                return RedirectToAction("Manager", "Admin");
            return View();
        }
        public ActionResult Logout() 
        { 
            Session["admin"] = null;

            return RedirectToAction("Index", "Admin"); 
        }
        public ActionResult Manager() 
        { 
            if(Session["admin"] != null)
                return View();
            return RedirectToAction("Index", "Admin");
        }
        //POST: Admin/Login/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "usrName,Password")] AdminUser adminUser) 
        {
            try
            {
                List<AdminUser> loginCheck = db.AdminUsers.Where
                (
                    s => s.UsrName == adminUser.UsrName
                    && s.Password == adminUser.Password
                ).ToList();

                if(loginCheck.Count > 0)
                {
                    Session["admin"] = adminUser.UsrName;
                    ViewBag.LoginStatus = "Dang nhap thanh cong!";

                    return RedirectToAction("Manager", "Admin");
                }
            } 
            catch
            {
                return View();
            }

            return View(); 
        }
    }
}