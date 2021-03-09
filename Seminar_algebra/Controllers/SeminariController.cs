using Seminar_algebra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;



namespace Seminar_algebra.Controllers
{
    public class SeminariController : Controller
    {
        private bazaDbContext _Db = new bazaDbContext();
        // GET: Seminari
        public ActionResult Popis()
        {
            return View(_Db._dboSm.ToList());
        }

        public ActionResult Predbiljezba(int? id, DateTime datum,string Naziv)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                Predbiljezba aktivna = new Predbiljezba();
                aktivna.FkSeminar = (int)id;
                aktivna.Datum = datum;
                
                    ViewBag.nazivSeminara = Naziv ;


                return View(aktivna);
            }
            //return View();
        }

        [HttpPost]
        public ActionResult Predbiljezba(Predbiljezba b)
        {

            if (ModelState.IsValid)
            {
                _Db._dboPb.Add(b);
                _Db.SaveChanges();
                ViewBag.uredu = "Osoba je dodana";
                return RedirectToAction("Popis");
            }
            else
            {
                ViewBag.greska = "Doslo je do pogreske";
                return View();
            }
            //return View();
        }
        [Authorize]
        [HttpGet]

        public ActionResult upisi(string odabirSeminara, string statusOdobrenja)
        {
            //izbor seminara za pretragu
            var listaSeminara = new List<string>();
            var popisSeminara = from d in _Db._dboSm
                                orderby d.Naziv
                                select d.Naziv;
            listaSeminara.AddRange(popisSeminara.Distinct());
            ViewBag.odabirSeminara = new SelectList(listaSeminara);
            //izbor statusa
            var listaStatusa = new List<string>();
            listaStatusa.Add("Odobreni");
            listaStatusa.Add("Neodobreni");
            ViewBag.statusOdobrenja = new SelectList(listaStatusa);


            var upisi = from m in _Db._dboPb select m;



            if (!string.IsNullOrEmpty(odabirSeminara) || !string.IsNullOrEmpty(statusOdobrenja))
            {

                if (statusOdobrenja == "Odobreni")
                {
                    upisi = upisi.Where(x => x.Status == true);
                }
                else if (statusOdobrenja == "Neodobreni")
                {
                    upisi = upisi.Where(x => x.Status == false);
                }


                upisi = upisi.Where(x => x.Seminar.Naziv == odabirSeminara);



                return View(upisi.ToList());
            }

            return View(_Db._dboPb.ToList());


        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {


            var uredi = _Db._dboPb.Where(o => o.IdPredbiljezba == id).FirstOrDefault();


            return View(uredi);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Predbiljezba uredena)
        {

            if (ModelState.IsValid)
            {
                _Db.Entry(uredena).State = EntityState.Modified;
                _Db.SaveChanges();
                return RedirectToAction("upisi");
            }
            return View(uredena);


        }


        [HttpGet]
        [Authorize]
        //Novi seminar
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _Db._dboSm.Add(seminar);
                _Db.SaveChanges();

                return RedirectToAction("Popis", "Seminari");

            }
            return View();
        }

     

        public ActionResult Delete(int? id)
        {
            var izbrisi = _Db._dboPb.Where(o => o.IdPredbiljezba == id).FirstOrDefault();
            return View(izbrisi);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Predbiljezba predbiljezba = _Db._dboPb.Find(id);
            _Db._dboPb.Remove(predbiljezba);
            _Db.SaveChanges();
            return RedirectToAction("upisi");
           
        }

        public ActionResult DetaljiSeminar (int? id)
        {
            Seminar seminar = _Db._dboSm.Find(id);
            
            return View(seminar);
        }

        public ActionResult DetaljiPredbiljezba (int? id)
        {
            Predbiljezba predbiljezba = _Db._dboPb.Find(id);
            return View(predbiljezba);
        }

        public ActionResult IzbrisiSeminar(int? id)
        {
            var izbrisi = _Db._dboSm.Where(o => o.IdSeminar == id).FirstOrDefault();
            return View(izbrisi);
        }
        [HttpPost]
        public ActionResult IzbrisiSeminar(int id)
        {
            Seminar seminar = _Db._dboSm.Find(id);
            //Predbiljezba predbiljezba = new Predbiljezba();
            //predbiljezba.FkSeminar = seminar.IdSeminar;

            //_Db._dboPb.Remove(predbiljezba);
            _Db._dboSm.Remove(seminar);

            _Db.SaveChanges();
            return RedirectToAction("Popis");

        }
    }
}
