using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class KategorijaProizvodaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajKategorijuProizvoda()
        {
            DodajKategorijaProizvodVM Model = new DodajKategorijaProizvodVM();
           
            return PartialView(Model);
        }
        public IActionResult PrikaziKategorijuProizvoda(string NazivKategorije, int ajax)
        {
            PrikaziKategorijaProizvodVM Model = new PrikaziKategorijaProizvodVM
            {
                kategorijeProizvoda = db.KategorijaProizvoda.Where(x => x.NazivKategorije.Contains(NazivKategorije) || NazivKategorije == null).ToList()
            };


            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }

        bool ProvjeriDuplikate(string naziv, int id)
        {
            if (db.KategorijaProizvoda.Any(x=>x.NazivKategorije==naziv && x.ID!=id))
                return false;
            return true;
        }

        public IActionResult SnimiKategorijuProizvoda(DodajKategorijaProizvodVM novaKategorijaPr)
        {
            if(!ModelState.IsValid || !ProvjeriDuplikate(novaKategorijaPr.NazivKategorije, novaKategorijaPr.ID))
            {
                if (!ProvjeriDuplikate(novaKategorijaPr.NazivKategorije, novaKategorijaPr.ID))
                    ViewData["poruka"] ="Naziv kategorije \"" + novaKategorijaPr.NazivKategorije + "\" je već unesen!";

                return PartialView("UrediKategorijuProizvoda", novaKategorijaPr);
            }
            KategorijaProizvoda temp;
            if(novaKategorijaPr.ID == 0)
            {
                temp = new KategorijaProizvoda();
                db.KategorijaProizvoda.Add(temp);
            }
            else
            {
                temp = db.KategorijaProizvoda.Find(novaKategorijaPr.ID);
            }
            temp.NazivKategorije = novaKategorijaPr.NazivKategorije;
            db.SaveChanges();
            return RedirectToAction("PrikaziKategorijuProizvoda", new { @ajax = 1});
        }
        public IActionResult UrediKategorijuProizvoda(int id)
        {
            DodajKategorijaProizvodVM Model = new DodajKategorijaProizvodVM();
            KategorijaProizvoda katPr = new KategorijaProizvoda();
            katPr = db.KategorijaProizvoda.Find(id);

            Model.ID = katPr.ID;
            Model.NazivKategorije = katPr.NazivKategorije;

            db.SaveChanges();

            return PartialView(Model);
        }
        public IActionResult ObrisiKategorijuProizvoda(int id)
        {
            KategorijaProizvoda katPr = db.KategorijaProizvoda.Find(id);
            db.Remove(katPr);
            db.SaveChanges();

            return RedirectToAction("PrikaziKategorijuProizvoda", new { @ajax = 1 });
        }

    }
}