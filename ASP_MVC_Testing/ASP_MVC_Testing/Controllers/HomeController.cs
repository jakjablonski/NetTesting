using ASP_MVC_Testing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Testing.Controllers
{
    public class HomeController : Controller

    {
        private WypoContext db;
        public HomeController()
        {
            db = new WypoContext();
        }
        public HomeController(WypoContext context)
        {
            this.db = context;
        }

        public ActionResult Index()
        {

            ViewBag.Message = "Test View Bag Index";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}