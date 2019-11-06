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
    public class UslugaController : Controller
    {
        MyContext db = new MyContext();
        
        public IActionResult PrikaziUslugu(string NazivUsluge, int ajax)
        {
            PrikaziUsluguVM Model = new PrikaziUsluguVM
            {
                Usluge = db.Usluga.Where(x => x.Naziv.Contains(NazivUsluge) || NazivUsluge == null).ToList()
            };

            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
        public IActionResult DodajUslugu()
        {
            DodajUsluguVM Model = new DodajUsluguVM();
            return PartialView(Model);
        }

        bool ProvjeriDuplikate(string naziv, int id)
        {
            if (db.Usluga.Any(x => x.Naziv == naziv && x.Id != id))
                return false;
            return true;
        }

        public IActionResult SnimiUslugu(DodajUsluguVM temp)
        {
            if (!ModelState.IsValid || !ProvjeriDuplikate(temp.Naziv, temp.Id))
            {
                if (!ProvjeriDuplikate(temp.Naziv, temp.Id))
                    ViewData["poruka"] = "Naziv: \"" + temp.Naziv + "\" je već unesen!"; 

                return PartialView("UrediUslugu", temp);
            }

            Usluga u;
            if(temp.Id == 0)
            {
                u = new Usluga();
                db.Usluga.Add(u);
            }
            else
            {
                u = db.Usluga.Find(temp.Id);
            }

            u.Naziv = temp.Naziv;
            u.Cijena = temp.Cijena;
            db.SaveChanges();

            return RedirectToAction("PrikaziUslugu", new { @ajax = 1 });
        }

        public IActionResult ObrisiUslugu(int UslugaId)
        {
            Usluga u = db.Usluga.Find(UslugaId);
            db.Remove(u);
            db.SaveChanges();

            return RedirectToAction("PrikaziUslugu", new { @ajax = 1 });
        }

        public IActionResult UrediUslugu(int UslugaId)
        {
            DodajUsluguVM Model = new DodajUsluguVM();
            Usluga u = new Usluga();
            u = db.Usluga.Find(UslugaId);

            Model.Id = u.Id;
            Model.Naziv = u.Naziv;
            Model.Cijena = u.Cijena;

            return PartialView(Model);
        }
      


    }
}