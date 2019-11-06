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
    public class SobaController : Controller
    {
        MyContext db = new MyContext();
       public IActionResult PrikaziSobe(int? brojSobe, int ajax)
        {
            PrikaziSobuVM Model = new PrikaziSobuVM
            {
                rows = db.Soba
                .Where(s=>s.BrojSobe == brojSobe || brojSobe == null)
               .Select(x => new PrikaziSobuVM.Row
               {
                   Id = x.Id,
                   brojSobe = x.BrojSobe,
                   Balkon = x.Balkon,
                   TV = x.TV,
                   Sprat = x.Sprat,
                   VrstaSobe = x.VrstaSobe,
                   Cijena = x.VrstaSobe.Cijena + (x.Balkon ? 30 : 0) + (x.TV ? 20 : 0)
               }).ToList(),
                brojSobe = brojSobe
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
                 
        }

        public IActionResult DodajSobu()
        {
            DodajSobuVM Model = new DodajSobuVM();

            List<SelectListItem> _spratovi = new List<SelectListItem>();
            _spratovi.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite sprat"
            });

            _spratovi.AddRange(db.Sprat.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSprata.ToString()

            }));
            Model.Spratovi = _spratovi;


            List<SelectListItem> _vrsteSoba = new List<SelectListItem>();
            _vrsteSoba.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite vrstu sobe"
            });

            _vrsteSoba.AddRange(db.VrstaSobe.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Tip + " - " + x.Cijena.ToString("0.00") + " KM"
               
            }));
            Model.VrsteSoba = _vrsteSoba;
            Model.BrojSobe = null;

            return PartialView(Model);
        }


      

        public IActionResult SnimiSobu(DodajSobuVM soba)
        {
            bool ProvjeriDuplikate(int? BrojSobe, int Id)
            {
                if (db.Soba.Any(x => x.BrojSobe == BrojSobe && x.Id != Id))
                    return false;
                return true;
            }


            if (!ModelState.IsValid || !ProvjeriDuplikate(soba.BrojSobe, soba.Id))
            {

                if (!ProvjeriDuplikate(soba.BrojSobe, soba.Id))
                    ViewData["poruka"] = "Broj " + soba.BrojSobe + " je već unesen!";

                List<SelectListItem> spratovi = new List<SelectListItem>();
                spratovi.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite sprat"
                });
                spratovi.AddRange(db.Sprat.Select(x=>new SelectListItem() {

                    Value = x.Id.ToString(),
                    Text = x.BrojSprata.ToString()
                }));

                soba.Spratovi = spratovi;

                List<SelectListItem> _vrsteSoba = new List<SelectListItem>();
                _vrsteSoba.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite vrstu sobe"
                });

                _vrsteSoba.AddRange(db.VrstaSobe.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Tip

                }));
                soba.VrsteSoba = _vrsteSoba;


                //if (ModelState.Keys.Contains("BrojSobe") && ModelState["BrojSobe"].Errors.Count > 0)
                //{
                //    ModelState.Remove("BrojSobe");
                //    if (soba.BrojSobe == 0)
                //        ModelState.AddModelError("BrojSobe", "Obavezno unijeti broj sobe!");
                //    else
                //        ModelState.AddModelError("BrojSobe", "Broj sobe mora biti u rangu od 100-400!");
                //}

                return PartialView("UrediSobu", soba);
            }

            Soba temp;
            if(soba.Id == 0)
            {
                temp = new Soba();
                db.Soba.Add(temp);
            }
            else
            {
                temp = db.Soba.Find(soba.Id);
            }

            temp.BrojSobe = soba.BrojSobe ?? 0;
            temp.Balkon = soba.Balkon;
            temp.TV = soba.TV;
            temp.SpratID = soba.SpratId;
            temp.VrstaSobeID = soba.VrstaSobeId;
          
            db.SaveChanges();
            return RedirectToAction("PrikaziSobe", new { @ajax = 1});
        }

        public IActionResult UrediSobu(int Id)
        {
            DodajSobuVM Model = new DodajSobuVM();
            Soba s = new Soba();
            s = db.Soba.Find(Id);

            Model.Id = s.Id;
            Model.BrojSobe = s.BrojSobe;
            Model.Balkon = s.Balkon;
            Model.TV = s.TV;
            Model.SpratId = s.SpratID;
            Model.VrstaSobeId = s.VrstaSobeID;

            List<SelectListItem> _spratovi = new List<SelectListItem>();
            _spratovi.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite sprat"
            });

            _spratovi.AddRange(db.Sprat.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSprata.ToString()

            }));
            Model.Spratovi = _spratovi;

            List<SelectListItem> _vrsteSoba = new List<SelectListItem>();
            _vrsteSoba.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite vrstu sobe"
            });

            _vrsteSoba.AddRange(db.VrstaSobe.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Tip + " - " + x.Cijena.ToString("0.00") + " KM"

            }));
            Model.VrsteSoba = _vrsteSoba;

            return PartialView(Model);
        }
        public IActionResult ObrisiSobu(int Id)
        {
            Soba s = db.Soba.Find(Id);
            db.Remove(s);
            db.SaveChanges();
            return RedirectToAction("PrikaziSobe", new { @ajax = 1 });
        }
    }
}
////