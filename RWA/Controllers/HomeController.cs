using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult Drzave()
        {
            var _db = new AdventureWorksOBPContext();
            var model = _db.Drzava.Select(r => new Drzava
            {
                Naziv = r.Naziv,
                Grad = r.Grad
            });
            return View(model);
        }
    }
}