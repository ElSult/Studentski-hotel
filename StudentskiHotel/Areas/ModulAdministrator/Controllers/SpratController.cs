using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class SpratController:Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajSprat()
        {
            DodajSpratVM Model = new DodajSpratVM();
            return PartialView(Model);
        }
        public IActionResult PrikaziSprat(int NazivSprata, int ajax)
        {
            PrikaziSpratVM Model = new PrikaziSpratVM
            {
                Spratovi = db.Sprat.Where(x => x.BrojSprata.Equals(NazivSprata) || NazivSprata == 0).OrderBy(x => x.BrojSprata).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }


        public IActionResult SnimiSprat(DodajSpratVM d)
        {
            bool ProvjeriDuplikat(int naziv, int id)
            {
                if (db.Sprat.Any(x => x.BrojSprata == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikat(d.BrojSprata??0, d.Id))
            {


                if (ModelState.Keys.Contains("BrojSprata") && ModelState["BrojSprata"].Errors.Count > 0)
                {
                    ModelState.Remove("BrojSprata");
                    if (d.BrojSprata is null)
                        ModelState.AddModelError("BrojSprata", "Broj sprata mora biti numericka vrijednost");
                    else
                        ModelState.AddModelError("BrojSprata", "Broj sprata mora biti u rangu od 0-1000!");
                }
                else
                {
                    if (ProvjeriDuplikat(d.BrojSprata ?? 0, d.Id))
                        ViewData["poruka"] = d.BrojSprata + " je već unesena!";
                }

                return PartialView("UrediSprat", d);
            }

            Sprat s;
            if (d.Id == 0)
            {
                s = new Sprat();
                db.Sprat.Add(s);
            }
            else
            {
                s = db.Sprat.Find(d.Id);
            }
            s.BrojSprata = d.BrojSprata??0;
            db.SaveChanges();
            return RedirectToAction("PrikaziSprat", new { @ajax = 1 });
        }
        public IActionResult ObrisiSprat(int SpratId)
        {
            Sprat s = db.Sprat.Find(SpratId);
            db.Remove(s);
            db.SaveChanges();
            return RedirectToAction("PrikaziSprat", new { @ajax = 1 });
        }
        public IActionResult UrediSprat(int SpratId)
        {
            DodajSpratVM Model = new DodajSpratVM();
            Sprat s = new Sprat();
            s = db.Sprat.Find(SpratId);
            Model.Id = s.Id;
            Model.BrojSprata = s.BrojSprata;
            return PartialView(Model);

        }
    }
}
