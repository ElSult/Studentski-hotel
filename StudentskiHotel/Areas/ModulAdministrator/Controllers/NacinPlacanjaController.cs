using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class NacinPlacanjaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajNacinPlacanja()
        {
            DodajNacinPlacanjaVM Model = new DodajNacinPlacanjaVM();

            return PartialView(Model);
        }
        public IActionResult PrikaziNacinPlacanja(string NazivPlacanja, int ajax)
        {
            PrikaziNacinPlacanjaVM Model = new PrikaziNacinPlacanjaVM
            {
                NaciniPlacanja = db.NacinPlacanja.Where(x => x.Naziv.Contains(NazivPlacanja) || NazivPlacanja == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }

 
        public IActionResult SnimiNacinPlacanja(DodajNacinPlacanjaVM d)
        {
            bool ProvjeriDuplikatNacinPlacanja(string naziv, int id)
            {
                if (db.NacinPlacanja.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikatNacinPlacanja(d.Naziv, d.Id))
            {
                if (ProvjeriDuplikatNacinPlacanja(d.Naziv,d.Id))
                    ViewData["poruka"] = d.Naziv + " je već unesen!";
                return PartialView("UrediNacinPlacanja", d);
            }
            NacinPlacanja n;
            if (d.Id == 0)
            {
                n = new NacinPlacanja();
                db.NacinPlacanja.Add(n);
            }
            else
            {
                n = db.NacinPlacanja.Find(d.Id);
            }
            n.Naziv = d.Naziv;
            db.SaveChanges();
            return RedirectToAction("PrikaziNacinPlacanja", new { @ajax = 1 });
        }
        public IActionResult ObrisiNacinPlacanja(int NacinPlacanjaId)
        {
            NacinPlacanja n = db.NacinPlacanja.Find(NacinPlacanjaId);
            db.Remove(n);
            db.SaveChanges();
            return RedirectToAction("PrikaziNacinPlacanja", new { @ajax = 1 });
        }
        public IActionResult UrediNacinPlacanja(int NacinPlacanjaId)
        {
            DodajNacinPlacanjaVM Model = new DodajNacinPlacanjaVM();
            NacinPlacanja n = new NacinPlacanja();
            n = db.NacinPlacanja.Find(NacinPlacanjaId);
            Model.Id = n.Id;
            Model.Naziv = n.Naziv;
            return PartialView(Model);

        }
    }
}