using System.Web.Mvc;

namespace TinTuc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Manager()
        {
            return View();  
        }
        public ActionResult Toolbox()
        {
            return PartialView();
        }
    }
}