using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    [Authorize]
    public class DrzaveController : Controller
    {
        AdventureWorksOBPContext _db = new AdventureWorksOBPContext();
        // GET: Drzave
        public ActionResult Index()
        {
            var model = _db.Drzava.Select(r => new Drzava
            {
                Naziv = r.Naziv,
                Grad = r.Grad
            });
            return View(model);
        }
        public ActionResult Gradovi(string naziv, int id)
        {
            var model = _db.Kupac.Where(r => r.GradId == id).Select(r => new Kupac
            {
                Ime = r.Ime,
                Prezime = r.Prezime,
                Email = r.Email,
                Telefon = r.Telefon,
                Idkupac = r.Idkupac
                
            });
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}