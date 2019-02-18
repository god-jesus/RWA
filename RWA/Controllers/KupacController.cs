using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class KupacController : Controller
    {
        AdventureWorksOBPContext _db = new AdventureWorksOBPContext();
        // GET: Kupac
        public ActionResult Racuni(int id)
        {
            var model = _db.Racun.Where(r => r.KupacId == id).Select(r=> new Racun
            {
                BrojRacuna = r.BrojRacuna,
                Komercijalist = r.Komercijalist,
                DatumIzdavanja = r.DatumIzdavanja,
                KupacId = r.KupacId,
                Komentar = r.Komentar,
                Idracun = r.Idracun,
                
            });
            return View(model);
        }

        public ActionResult Stavke(int id)
        {
            var model = _db.Stavka.Where(r => r.RacunId == id).Select(r => new Stavka
            {
                Proizvod = r.Proizvod,
                Kolicina = r.Kolicina,
                CijenaPoKomadu = r.CijenaPoKomadu,
                PopustUpostocima = r.PopustUpostocima,
                UkupnaCijena = r.UkupnaCijena,
                Racun = r.Racun,
                
            });
            return View(model);
        }
        // GET: Kupac/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kupac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupac/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kupac/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kupac/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kupac/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kupac/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (_db!=null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
