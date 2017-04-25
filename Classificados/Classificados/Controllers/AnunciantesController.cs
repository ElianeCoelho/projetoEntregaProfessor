using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Classificados.Models;

namespace Classificados.Controllers
{
    public class AnunciantesController : Controller
    {
        private ClassificadosContext db = new ClassificadosContext();

        // GET: Anunciantes
        public ActionResult Index()
        {
            var anunciantes = db.Anunciantes.Include(a => a._Anuncio);
            return View(anunciantes.ToList());
        }

        // GET: Anunciantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // GET: Anunciantes/Create
        public ActionResult Create()
        {
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "Titulo");
            return View();
        }

        // POST: Anunciantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnuncianteID,Nome,Cpf,Endereco,AnuncioID")] Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                db.Anunciantes.Add(anunciante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "Titulo", anunciante.AnuncioID);
            return View(anunciante);
        }

        // GET: Anunciantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "Titulo", anunciante.AnuncioID);
            return View(anunciante);
        }

        // POST: Anunciantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnuncianteID,Nome,Cpf,Endereco,AnuncioID")] Anunciante anunciante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anunciante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "Titulo", anunciante.AnuncioID);
            return View(anunciante);
        }

        // GET: Anunciantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return HttpNotFound();
            }
            return View(anunciante);
        }

        // POST: Anunciantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            db.Anunciantes.Remove(anunciante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
