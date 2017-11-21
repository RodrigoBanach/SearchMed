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
    public class RemediosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Remedios
        public ActionResult Index()
        {
            var list = context
                .Remedios
                .Include(f => f.Farmacia)
                .OrderBy(n => n.Nome)
                .ToList();
            return View(list);

            //return View(context.Remedios.OrderBy(c => c.Nome));
        }

        public ActionResult Create()

        {
            ViewBag.FarmaciaId = new SelectList(context
                .Farmacias
                .OrderBy(n => n.Nome), "FarmaciaId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Remedio remedio)
        {
            try
            {
                context.Remedios.Add(remedio);
                context.SaveChanges();
                return RedirectToAction("Create", "Remedios");
            }
            catch
            {
                return View(remedio);
            }

        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Remedio remedio = context.Remedios.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmaciaId = new SelectList(context
                .Farmacias
                .OrderBy(n => n.Nome), "FarmaciaId", "Nome", remedio
                .FarmaciaId);
            return View(remedio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Remedio remedio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(remedio).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(remedio);
            }
            catch
            {
                return View(remedio);
            }
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Remedio remedio = context
                .Remedios
                .Where(p => p.RemedioId == id)
                .Include(f => f.Farmacia)
                .First();
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }


        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Remedio remedio = context
                .Remedios
                .Where(p => p.RemedioId == id)
                .Include(f => f.Farmacia)
                .First();
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Remedio remedio = context.Remedios.Find(id);
                context.Remedios.Remove(remedio);
                context.SaveChanges();
                TempData["Message"] = "Remédio " + remedio.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
    