using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using TuVanDuHoc_v2.Models;

namespace TuVanDuHoc_v2.Controllers
{
    public class LifeController : Controller
    {
        private tuvanduhocEntities db = new tuvanduhocEntities();
        
        public ActionResult Index() => View();
        public ActionResult America() => View();
        public ActionResult Australia() => View();
        public ActionResult Canada() => View();
        public ActionResult Korea() => View();
        public ActionResult Japan() => View();
        public ActionResult Singapore() => View();

    }
}