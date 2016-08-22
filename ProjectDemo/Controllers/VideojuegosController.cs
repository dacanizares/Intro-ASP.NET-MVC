using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.Models;

namespace ProjectDemo.Controllers
{
    [Authorize]
    public class VideojuegosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videojuegos
        public ActionResult Index()
        {
            return View(db.Videojuegos.ToList());
        }

        // GET: Videojuegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuego videojuego = db.Videojuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            return View(videojuego);
        }

        // GET: Videojuegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videojuegos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,ImagenUrl")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                db.Videojuegos.Add(videojuego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videojuego);
        }

        // GET: Videojuegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuego videojuego = db.Videojuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            return View(videojuego);
        }

        // POST: Videojuegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,ImagenUrl")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videojuego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videojuego);
        }

        // GET: Videojuegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuego videojuego = db.Videojuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            return View(videojuego);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Videojuego videojuego = db.Videojuegos.Find(id);
            db.Videojuegos.Remove(videojuego);
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
