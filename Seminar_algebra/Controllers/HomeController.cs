﻿using Seminar_algebra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Seminar_algebra.Controllers
{
    public class HomeController : Controller
    {
        private bazaDbContext _Db = new bazaDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _Db._dboZp.Any(u => u.KorisnickoIme.ToLower() == zaposlenik.KorisnickoIme.ToLower() && zaposlenik.Lozinka == zaposlenik.Lozinka);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(zaposlenik.KorisnickoIme, false);
                    return RedirectToAction("Index", "Zaposleniks");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                _Db._dboZp.Add(zaposlenik);
                _Db.SaveChanges();
                
                return RedirectToAction("Login");

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}  
    
