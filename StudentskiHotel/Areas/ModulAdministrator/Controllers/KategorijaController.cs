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
    public class KategorijaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajKategoriju()
        {
            DodajKategorijuVM Model = new DodajKategorijuVM();
            return PartialView(Model);
        }
        public IActionResult PrikaziKategoriju(string NazivKategorije, int ajax)
        {
            PrikaziKategorijuVM Model = new PrikaziKategorijuVM
            {
                Kategorije = db.Kategorija.Where(x => x.Naziv.Contains(NazivKategorije) || NazivKategorije == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);

            return View(Model);
        }


        public IActionResult SnimiKategoriju(DodajKategorijuVM temp)
        {
            bool ProvjeriDuplikat(string naziv, int id)
            {
                if (db.Kategorija.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikat(temp.Naziv, temp.Id))
            {
                if (ModelState.Keys.Contains("Cijena") && ModelState["Cijena"].Errors.Count > 0)
                {
                    ModelState.Remove("Cijena");
                    if (temp.Cijena is null)
                        ModelState.AddModelError("Cijena", "Cijena mora biti numericka vrijednost");
                   else
                        ModelState.AddModelError("Cijena", "Cijena mora biti unesena");

                }
                if (ProvjeriDuplikat(temp.Naziv, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesen!";
                return PartialView("UrediKategoriju", temp);
            }
            Kategorija nova;
            if (temp.Id == 0)
            {
                nova = new Kategorija();
                db.Kategorija.Add(nova);
            }
            else
            {
                nova = db.Kategorija.Find(temp.Id);
            }

            nova.Naziv = temp.Naziv;
            nova.Cijena = temp.Cijena.Value;
            db.SaveChanges();
            return RedirectToAction("PrikaziKategoriju", new { @ajax = 1 });
        }

        public IActionResult UrediKategoriju(int KategorijaId)
        {
            DodajKategorijuVM Model = new DodajKategorijuVM();
            Kategorija k = new Kategorija();
            k = db.Kategorija.Find(KategorijaId);

            Model.Id = k.Id;
            Model.Naziv = k.Naziv;
            Model.Cijena = k.Cijena;


            return PartialView(Model);
        }
        public IActionResult ObrisiKategoriju(int KategorijaId)
        {
            Kategorija k = db.Kategorija.Find(KategorijaId);
            db.Remove(k);
            db.SaveChanges();
            return RedirectToAction("PrikaziKategoriju", new { @ajax = 1 });
        }
    }
}