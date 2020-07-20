using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seminar_algebra.Models;

namespace Seminar_algebra.Controllers
{
    public class ZaposleniksController : Controller
    {
        private bazaDbContext db = new bazaDbContext();

        // GET: Zaposleniks
        public ActionResult Index()
        {
            return View(db._dboZp.ToList());
        }

        // GET: Zaposleniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db._dboZp.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // GET: Zaposleniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zaposleniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZaposlenik,Ime,Prezime,KorisnickoIme,Lozinka")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db._dboZp.Add(zaposlenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zaposlenik);
        }

        // GET: Zaposleniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db._dboZp.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposleniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZaposlenik,Ime,Prezime,KorisnickoIme,Lozinka")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposlenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zaposlenik);
        }

        // GET: Zaposleniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db._dboZp.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposleniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposlenik zaposlenik = db._dboZp.Find(id);
            db._dboZp.Remove(zaposlenik);
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
