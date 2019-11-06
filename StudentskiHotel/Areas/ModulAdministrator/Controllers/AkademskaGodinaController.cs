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
    public class AkademskaGodinaController : Controller
    {
        MyContext db = new MyContext();

       public IActionResult PrikaziAkademskaGodina(string NazivPretrage, int ajax)
        {
            PrikaziAkademskaGodinaVM Model = new PrikaziAkademskaGodinaVM
            {
                Godine = db.AkademskaGodina.Where(x => x.AkGodina == NazivPretrage || NazivPretrage == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }


        public IActionResult DodajAkademskaGodina()
        {
            DodajAkademskaGodinaVM Model = new DodajAkademskaGodinaVM();
            return PartialView(Model);
        }


        bool ProvjeriDuplikat(string naziv, int id)
        {
            if (db.AkademskaGodina.Any(x => x.AkGodina == naziv && x.Id != id))
                return true;
            return false;
        }

        public IActionResult SnimiAkademskaGodina(DodajAkademskaGodinaVM temp)
        {
           
            if (!ModelState.IsValid || ProvjeriDuplikat(temp.AkGodina, temp.Id))
            {
                if (ProvjeriDuplikat(temp.AkGodina, temp.Id))
                    ViewData["poruka"] = temp.AkGodina + " je već unesena!";
                return PartialView("UrediAkademskaGodina", temp);
            }
            AkademskaGodina nova;
            if(temp.Id==0)
            {
                nova = new AkademskaGodina();
                db.AkademskaGodina.Add(nova);
            }
            else
            {
                nova = db.AkademskaGodina.Find(temp.Id);
            }

            nova.AkGodina = temp.AkGodina;
            db.SaveChanges();
            return RedirectToAction("PrikaziAkademskaGodina", new { @ajax = 1 });
        }

        public IActionResult UrediAkademskaGodina(int id)
        {
            DodajAkademskaGodinaVM Model = new DodajAkademskaGodinaVM();
            AkademskaGodina a = new AkademskaGodina();
            a = db.AkademskaGodina.Find(id);

            Model.Id = a.Id;
            Model.AkGodina = a.AkGodina;
          
            return PartialView(Model);
        }
        public IActionResult ObrisiAkademskaGodina(int id)
        {
            AkademskaGodina a = db.AkademskaGodina.Find(id);
            db.Remove(a);
            db.SaveChanges();
            return RedirectToAction("PrikaziAkademskaGodina", new { @ajax = 1 });
        }
    }
}