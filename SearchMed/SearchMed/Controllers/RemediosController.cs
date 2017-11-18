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
            return View(context.Remedios.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Remedio remedio)
        {
            context.Remedios.Add(remedio);
            context.SaveChanges();
            return RedirectToAction("Index","Farmacias");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Remedio remedio = context.Remedios.Find(id);
            if (remedio == null)
            {
                return HttpNotFound();
            }
            return View(remedio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                context.Entry(remedio).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(remedio);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }

            Remedio remedio = context.Remedios.Find(id);

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
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Remedio remedio = context.Remedios.Find(id);
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
            Remedio remedio = context.Remedios.Find(id);
            context.Remedios.Remove(remedio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}