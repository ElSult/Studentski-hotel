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
    public class StrucnaSpremaController:Controller
    {
        MyContext db = new MyContext();

        public IActionResult DodajStrucnuSpremu()
        {
            DodajStrucnuSpremuVM Model = new DodajStrucnuSpremuVM();
            return PartialView(Model);
        }
        public IActionResult PrikaziStrucnuSpremu(string NazivStrucneSpreme, int ajax)
        {
            PrikaziStrucnuSpremuVM Model = new PrikaziStrucnuSpremuVM
            {
                StrucneSpreme = db.StrucnaSprema.Where(x => x.Naziv.Contains(NazivStrucneSpreme) || NazivStrucneSpreme == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
 
        public IActionResult SnimiStrucnuSpremu(DodajStrucnuSpremuVM temp)
        {
       
            bool ProvjeriDuplikatStrucnaSprema(string naziv, int id)
            {
                if (db.StrucnaSprema.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikatStrucnaSprema(temp.Naziv, temp.Id))
            {
                if (ProvjeriDuplikatStrucnaSprema(temp.Naziv, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesena!";
                return PartialView("UrediStrucnuSpremu", temp);
            }
            StrucnaSprema s;
            if(temp.Id==0)
            {
                s = new StrucnaSprema();
                db.StrucnaSprema.Add(s);
            }
            else
            {
                s = db.StrucnaSprema.Find(temp.Id);
            }
            s.Naziv = temp.Naziv;
            db.SaveChanges();
            return RedirectToAction("PrikaziStrucnuSpremu",new { @ajax=1});
        }
        public IActionResult UrediStrucnuSpremu(int StrucnaSpremaId)
        {
            DodajStrucnuSpremuVM Model = new DodajStrucnuSpremuVM();
            StrucnaSprema str = new StrucnaSprema();
            str = db.StrucnaSprema.Find(StrucnaSpremaId);
            Model.Id = str.Id;
            Model.Naziv = str.Naziv;
            return PartialView(Model);
        }
        public IActionResult ObrisiStrucnuSpremu(int StrucnaSpremaId)
        {
            StrucnaSprema s = db.StrucnaSprema.Find(StrucnaSpremaId);
            db.Remove(s);
            db.SaveChanges();
            return RedirectToAction("PrikaziStrucnuSpremu", new { @ajax = 1 });

        }
    }
   
}
