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
    public class VrstaObrokaController : Controller
    {
        MyContext db = new MyContext();

       public IActionResult PrikaziVrstuObroka(string NazivVrste, int ajax)
        {
            PrikaziVrstuObrokaVM Model = new PrikaziVrstuObrokaVM
            {
                VrsteObroka = db.VrstaObroka.Where(x => x.Vrsta.Contains(NazivVrste) || NazivVrste == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }

        public IActionResult DodajVrstuObroka()
        {
            DodajVrstuObrokaVM Model = new DodajVrstuObrokaVM();

            return PartialView(Model);
        }

        bool ProvjeriDuplikat(string naziv, int id)
        {
            if (db.VrstaObroka.Any(x => x.Vrsta == naziv && x.Id != id))
                return false;
            return true;

        }

        public IActionResult SnimiVrstuObroka(DodajVrstuObrokaVM obrok)
        {

            if(!ModelState.IsValid || !ProvjeriDuplikat(obrok.Vrsta, obrok.Id))
            {

                if (!ProvjeriDuplikat(obrok.Vrsta, obrok.Id))
                    ViewData["poruka"] ="Vrsta obroka: \" " + obrok.Vrsta + "\" je vec zauzet, odaberite drugu vrstu obroka!";

                return PartialView("UrediVrstuObroka", obrok);
            }


            VrstaObroka temp;
            if (obrok.Id == 0)
            {
                temp = new VrstaObroka();
                db.VrstaObroka.Add(temp);
            }
            else
            {
                temp = db.VrstaObroka.Find(obrok.Id);
            }

            temp.Id = obrok.Id;
            temp.Vrsta = obrok.Vrsta;

            db.SaveChanges();

            return RedirectToAction("PrikaziVrstuObroka", new { @ajax = 1 });
        }

        public IActionResult UrediVrstuObroka(int vrstaObrokaId)
        {
            DodajVrstuObrokaVM Model = new DodajVrstuObrokaVM();
            VrstaObroka o = new VrstaObroka();
            o = db.VrstaObroka.Find(vrstaObrokaId);

            Model.Id = o.Id;
            Model.Vrsta = o.Vrsta;


            return PartialView(Model);
        }

        public IActionResult ObrisiVrstuObroka(int VrstaObrokaId)
        {
            VrstaObroka u = db.VrstaObroka.Find(VrstaObrokaId);
            db.Remove(u);
            db.SaveChanges();

            return RedirectToAction("PrikaziVrstuObroka", new { @ajax = 1 });
        }

    }
}