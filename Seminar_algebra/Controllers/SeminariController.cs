using Seminar_algebra.Models;
using System;
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

        public ActionResult Predbiljezba(int? id, DateTime datum)
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
                //var seminar = _Db._dboSm.Where(o => o.IdSeminar == id).FirstOrDefault();
                //int dd = (int)id;
                //ViewBag.Fkseminar = dd;
                //ViewData ["nesto"] = aktivna;

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
        public ActionResult upisi()
        {
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


    }
}
/*
            Account userAccount = _context.Accounts.SingleOrDefault(e => e.UserKey == userKey);
            User currentUser = _context.Users.SingleOrDefault(e => e.UserKey == userKey);
            var transactions = _context.Transactions.Where(e => e.AccountID == userAccount.AccountID).OrderBy(e => e.Created_at).ToList();
            transactions.Reverse();
            ViewBag.History = transactions;
            ViewBag.UserName = currentUser.FirstName;
            ViewBag.Balance = userAccount.Balance;
            ViewBag.UserId = currentUser.UserID;
            ViewBag.UserKey = currentUser.UserKey;
            return View("Account");
            */
