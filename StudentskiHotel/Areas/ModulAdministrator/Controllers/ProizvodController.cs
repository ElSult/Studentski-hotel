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
    public class ProizvodController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult PrikaziProizvod(string NazivProizvoda, int ajax)
        {
            PrikaziProizvodVM Model = new PrikaziProizvodVM
            {
                Proizvodi = db.Proizvod
                    .Include(x => x.KategorijaProizvoda)
                    .Where(x => x.Naziv.Contains(NazivProizvoda) || NazivProizvoda == null)
                    .ToList()
            };

            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
        
        public IActionResult DodajProizvod()
        {
            DodajProizvodVM Model = new DodajProizvodVM();

            List<SelectListItem> _kategorije = new List<SelectListItem>();
            _kategorije.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite kategoriju"
            });
            _kategorije.AddRange(db.KategorijaProizvoda.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NazivKategorije
            }));
            Model.Kategorija = _kategorije;

            return PartialView(Model);
        }


        bool ProvjeriDuplikat(string naziv, int id)
        {
            if (db.Proizvod.Any(x => x.Naziv == naziv && x.Id != id))
                return false;
            return true;
        }

    
        public IActionResult SnimiProizvod(DodajProizvodVM temp)
        {
            if (!ModelState.IsValid || !ProvjeriDuplikat(temp.Naziv, temp.Id))
            {
                if (!ProvjeriDuplikat(temp.Naziv, temp.Id))
                    ViewData["poruka"] ="Naziv roizvoda: \"" + temp.Naziv + "\" je zauzet!";

                List<SelectListItem> _kategorije = new List<SelectListItem>();
                _kategorije.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite kategoriju"
                });
                _kategorije.AddRange(db.KategorijaProizvoda.Select(x => new SelectListItem()
                {
                    Value = x.ID.ToString(),
                    Text = x.NazivKategorije
                }));
                temp.Kategorija = _kategorije;

                return PartialView("UrediProizvod", temp);
            }

            Proizvod p;
            if (temp.Id == 0)
            {
                p = new Proizvod();
                db.Proizvod.Add(p);
            }
            else
            {
                p = db.Proizvod.Find(temp.Id);
            }

            p.Naziv = temp.Naziv;
            p.Cijena = temp.Cijena;
            p.KategorijaID = temp.KategorijaID;

            db.SaveChanges();


            return RedirectToAction("PrikaziProizvod", new { @ajax = 1 });
        }

        public IActionResult ObrisiProizvod(int ProizvodId)
        {
            Proizvod p = db.Proizvod.Find(ProizvodId);
            db.Remove(p);
            db.SaveChanges();

            return RedirectToAction("PrikaziProizvod", new { @ajax = 1 });
        }


        public IActionResult UrediProizvod(int ProizvodId)
        {
            DodajProizvodVM Model = new DodajProizvodVM();
            Proizvod p = new Proizvod();
            p = db.Proizvod.Find(ProizvodId);
            Model.Id = p.Id;
            Model.Naziv = p.Naziv;
            Model.Cijena = p.Cijena;
            Model.KategorijaID = p.KategorijaID;

            List<SelectListItem> _kategorije = new List<SelectListItem>();
            _kategorije.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite kategoriju"
            });
            _kategorije.AddRange(db.KategorijaProizvoda.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.NazivKategorije
            }));
            Model.Kategorija = _kategorije;

            return PartialView(Model);
        }
      
    }
}