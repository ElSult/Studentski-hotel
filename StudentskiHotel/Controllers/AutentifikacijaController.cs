using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Models;
using StudentskiHotel.Web.Helper;
using StudentskiHotel.Web.ViewModels;

namespace StudentskiHotel.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult Index()
        {

            return View(new LoginVM()
            {
                ZapamtiLozinku = true,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = db.KorisnickiNalog.SingleOrDefault(x => x.KorisnickoIme == input.KorisnickoIme && x.Lozinka == input.Lozinka);
            if (korisnik == null)
            {
                ViewData["error_poruka"] = "Pogresno korisnicko ime ili lozinka";
                return View("Index", input);
            }
            Zaposlenik zap = new Zaposlenik();
            zap = db.Zaposlenik.Where(x => x.KorisnickiNalogID == korisnik.Id).FirstOrDefault();

            HttpContext.SetLogiraniKorisnik(zap);

            TipZaposlenika tip = HttpContext.GetLogiraniKorisnik().Tip;
            if (tip == TipZaposlenika.Admin)
            {
                return RedirectToAction("Index", "ModulAdministrator/Index");
            }
           else if (tip == TipZaposlenika.Konobar)
            {
                return RedirectToAction("Index", "ModulRestoran/Index");
            }
           else if (tip == TipZaposlenika.Recepcioner)
            {
                return RedirectToAction("Index", "ModulZaposlenik/Index");
            }



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}