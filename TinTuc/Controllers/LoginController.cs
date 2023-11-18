﻿using System.Linq;
using System.Web.Mvc;
using TinTuc.Models;

namespace TinTuc.Controllers
{
    public class LoginController : Controller
    {
        private TinTucEntities db = new TinTucEntities();

        // GET: Login
        public ActionResult Index() => View();
        public ActionResult Register() => View();

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NguoiDung user)
        {
            try
            {
                string authTmp = SHA256.ToSHA256(user.Password);
                NguoiDung checkLogin = db.NguoiDungs.FirstOrDefault
                (
                    k => k.UserName == user.UserName && k.Password == authTmp
                );
                if(checkLogin != null )
                {
                    Session["Customer"] = checkLogin.TenND;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.UserError = "Sai thông tin đăng nhập!";

                    return View("Index");
                }
            }
            catch
            {
                ViewBag.UserError = "Lỗi hệ thống!";

                return View("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NguoiDung user)
        {
            try
            {
                string authTmp = SHA256.ToSHA256(user.Password);
                user.Password = authTmp;
                if (ModelState.IsValid)
                {
                    db.NguoiDungs.Add(user);
                    db.SaveChanges();

                    return RedirectToActionPermanent("Index");
                }
                else
                {
                    ViewBag.UserError = "Lỗi hệ thống!";

                    return View();
                }
            }
            catch
            {
                ViewBag.UserError = "Lỗi hệ thống!";

                return View();
            }
        }
    }
}