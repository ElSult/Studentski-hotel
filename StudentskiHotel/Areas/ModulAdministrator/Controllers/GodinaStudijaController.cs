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
    public class GodinaStudijaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziGodinaStudija(int Godina, int ajax)
        {
            PrikaziGodinaStudijaVM Model = new PrikaziGodinaStudijaVM
            {
                GodineStudija = db.GodinaStudija.Where(x => x.Naziv == Godina || Godina == 0).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
        public IActionResult DodajGodinaStudija()
        {
            DodajGodinaStudijaVM Model = new DodajGodinaStudijaVM();
            return PartialView(Model);
        }
       
        public IActionResult SnimiGodinaStudija(DodajGodinaStudijaVM temp)
        {
           bool ProvjeriDuplikat(int naziv, int id)
            {
                if (db.GodinaStudija.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikat(temp.Naziv??0, temp.Id))
            {
                if (ProvjeriDuplikat(temp.Naziv ?? 0, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesena!";
                return PartialView("UrediGodinaStudija", temp);
            }
            GodinaStudija g;
            if(temp.Id==0)
            {
                g = new GodinaStudija();
                db.GodinaStudija.Add(g);
            }
            else
            {
                g = db.GodinaStudija.Find(temp.Id);
            }

            g.Naziv = temp.Naziv??0;
            db.SaveChanges();
            return RedirectToAction("PrikaziGodinaStudija", new { @ajax = 1 });
        }
        public IActionResult ObrisiGodinaStudija(int id)
        {
            GodinaStudija g;
            g = db.GodinaStudija.Find(id);
            db.Remove(g);
            db.SaveChanges();
            return RedirectToAction("PrikaziGodinaStudija", new { @ajax = 1 });
        }
        public IActionResult UrediGodinaStudija(int id)
        {
            DodajGodinaStudijaVM Model = new DodajGodinaStudijaVM();
            GodinaStudija g=new GodinaStudija();
            g = db.GodinaStudija.Find(id);

            Model.Id = g.Id;
            Model.Naziv = g.Naziv;


            return PartialView(Model);
        }
    }
}