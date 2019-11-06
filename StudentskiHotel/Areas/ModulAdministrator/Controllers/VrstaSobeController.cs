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
    public class VrstaSobeController:Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajVrstuSobe()
        {
            DodajVrstuSobeVM Model = new DodajVrstuSobeVM();
            return PartialView(Model);
        }
        public IActionResult PrikaziVrstuSobe(string NazivVrsteSobe, int ajax)
        {
            PrikaziVrstuSobeVM Model = new PrikaziVrstuSobeVM
            {
                VrsteSobe = db.VrstaSobe.Where(x => x.Tip.Contains(NazivVrsteSobe) || NazivVrsteSobe == null).ToList()
            };

            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }

        public IActionResult SnimiVrstuSobe(DodajVrstuSobeVM temp)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("UrediVrstuSobe", temp);
            //}
            bool ProvjeriDuplikatVrstaSobe(string naziv, int id)
            {
                if (db.VrstaSobe.Any(x => x.Tip == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikatVrstaSobe(temp.Tip, temp.Id))
            {
                if (ProvjeriDuplikatVrstaSobe(temp.Tip, temp.Id))
                    ViewData["poruka"] = temp.Tip + " je već unesena!";
                return PartialView("UrediVrstuSobe", temp);
            }

            VrstaSobe v;
            if (temp.Id == 0)
            {
                v = new VrstaSobe();
                db.VrstaSobe.Add(v);
            }
            else
            {
                v = db.VrstaSobe.Find(temp.Id);
            }
            v.Tip = temp.Tip;
            v.Cijena = temp.Cijena;
            db.SaveChanges();
            return RedirectToAction("PrikaziVrstuSobe",new { @ajax=1});
        }
        public IActionResult ObrisiVrstuSobe(int VrstaSobeId)
        {
            VrstaSobe s = db.VrstaSobe.Find(VrstaSobeId);
            db.Remove(s);
            db.SaveChanges();
            return RedirectToAction("PrikaziVrstuSobe",new { @ajax = 1 });
        }
        public IActionResult UrediVrstuSobe(int VrstaSobeId)
        {
            DodajVrstuSobeVM Model = new DodajVrstuSobeVM();
            VrstaSobe v = new VrstaSobe();
            v = db.VrstaSobe.Find(VrstaSobeId);
            Model.Id = v.Id;
            Model.Tip = v.Tip;
            Model.Cijena = v.Cijena;
            return PartialView(Model);
        }
    }
}
