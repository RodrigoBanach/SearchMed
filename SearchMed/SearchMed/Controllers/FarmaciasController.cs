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
        private EFContext context = new EFContext();

        // GET: Farmacia
        public ActionResult Index()
        {
            return View(context.Farmacias.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Farmacia farmacia)
        {
            context.Farmacias.Add(farmacia);
            context.SaveChanges();
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
            Farmacia farmacia = context.Farmacias.Find(id);
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
                context.Entry(farmacia).State = EntityState.Modified;
                context.SaveChanges();
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

            Farmacia farmacia = context.Farmacias.
            Find(id);

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
            Farmacia farmacia = context.Farmacias.Find(id);
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
            Farmacia farmacia = context.Farmacias.
            Find(id);
            context.Farmacias.Remove(farmacia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}