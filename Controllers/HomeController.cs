using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TuVanDuHoc_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Contact() => View();
        public ActionResult IELTSExam() => View();
        public ActionResult TestEnglish() => View();
        public ActionResult News() => View();
        public ActionResult Blog() => View();
        public ActionResult USA() => View();
        public ActionResult Australia() => View();
        public ActionResult Canada() => View();
        public ActionResult Japan() => View();
        public ActionResult Korea() => View();
        public ActionResult Singapore() => View();
    }
    
}