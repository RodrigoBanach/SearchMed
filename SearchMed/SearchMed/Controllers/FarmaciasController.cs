using SearchMed.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchMed.Models;
using System.Net;
using System.Data.Entity;

namespace SearchMed.Controllers
{
    public class FarmaciasController : Controller
    {
        private EFContext _context = new EFContext();

        // GET: Farmacia
        public ActionResult Index()
        {
            return View(_context
                .Farmacias
                .OrderBy(s => s.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Farmacia farmacia)
        {
            _context.Farmacias.Add(farmacia);
            _context.SaveChanges();
            return RedirectToAction("Create","Remedios");
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            // Farmacia farmacia = _context.Farmacias.Find(id);
            var farmacia = _context.Farmacias.Where(f => f.FarmaciaId == id)
                 .Include("Remedios")
                 .First();


            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(farmacia).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmacia);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }

            //Farmacia farmacia = _context.Farmacias.Find(id);

            var farmacia = _context.Farmacias.Where(f => f.FarmaciaId == id)
                .Include("Remedios")
                .First();

            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            //Farmacia farmacia = _context.Farmacias.Find(id);
            var farmacia = _context.Farmacias.Where(f => f.FarmaciaId == id)
                .Include("Remedios")
                .First();

            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Farmacia farmacia = _context.Farmacias.
            Find(id);
            _context.Farmacias.Remove(farmacia);
            _context.SaveChanges();
            TempData["Message"] = "Farmacia " + farmacia.Nome.ToUpper() + " foi removido com Sucesso";
            return RedirectToAction("Index");
        }

    }
}