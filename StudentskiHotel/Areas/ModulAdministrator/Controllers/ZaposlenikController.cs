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
using StudentskiHotel.Web.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class ZaposlenikController : Controller
    {
        MyContext db = new MyContext();
        
        public IActionResult PrikaziZaposlenika(string prezime)
        {
            PrikaziZaposlenikaVM Model = new PrikaziZaposlenikaVM
            {
                zaposlenici = db.Zaposlenik.Include(x => x.Grad).Include(m => m.StrucnaSprema).Include(m => m.KorisnickiNalog).Where(x => x.Prezime.Contains(prezime) || prezime == null).ToList()
            };
            return View(Model);
        }
        public IActionResult DodajZaposlenika()
        {
            DodajZposlenikaVM Model = new DodajZposlenikaVM();
          
            List<SelectListItem> gradovi = new List<SelectListItem>();
            gradovi.Add(new SelectListItem()
            {
                Value=null,
                Text="Odaberite grad: "
            });

            gradovi.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value=x.Id.ToString(),
                Text=x.Naziv
            }));
            Model.GradoviStavke = gradovi;

            List<SelectListItem> strucneSpreme = new List<SelectListItem>();

            strucneSpreme.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite strucnu spremu: "
            });

            strucneSpreme.AddRange(db.StrucnaSprema.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.StrucnaSpremaStavke = strucneSpreme;
            return View(Model);
        }

        public IActionResult SnimiZaposlenika(DodajZposlenikaVM temp)
        {
            bool ProvjeriDuplikatZaposlenik(string naziv, int id)
            {
                if (db.Zaposlenik.Any(x => x.MaticniBroj == naziv && x.Id != id))
                    return true;
                return false;
            }
  
            if (!ModelState.IsValid || ProvjeriDuplikatZaposlenik(temp.MaticniBroj,temp.Id))
            {
                List<SelectListItem> Gradovi = new List<SelectListItem>();
                Gradovi.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite grad:"
                });

                Gradovi.AddRange(db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                temp.GradoviStavke = Gradovi;
                List<SelectListItem> StrucneSpreme = new List<SelectListItem>();
                StrucneSpreme.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite strucnu spremu:"
                });

                StrucneSpreme.AddRange(db.StrucnaSprema.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                temp.StrucnaSpremaStavke = StrucneSpreme;
                if (ProvjeriDuplikatZaposlenik(temp.MaticniBroj, temp.Id))
                    ViewData["poruka"] = temp.MaticniBroj + " je već unesen!";
                return View("UrediZaposlenika", temp);
            }

            Zaposlenik z;
            KorisnickiNalog k;
            if (temp.Id == 0)
            {
                z = new Zaposlenik();
                db.Zaposlenik.Add(z);
                k = new KorisnickiNalog();
                db.KorisnickiNalog.Add(k);

            }
            else
            {
                z = db.Zaposlenik.Find(temp.Id);
                k = db.KorisnickiNalog.Find(z.KorisnickiNalogID);
            }
            k.KorisnickoIme = temp.KorisnickoIme;
            k.Lozinka = temp.Lozinka;
            z.Ime = temp.Ime;
            z.Prezime = temp.Prezime;
            z.Spol = temp.Spol;
            z.MaticniBroj = temp.MaticniBroj;
            z.DatumRodenja = temp.DatumRodenja;
            z.GradID = temp.GradID;
            z.StrucnaSpremaID = temp.StrucnaSpremaID;
            z.Tip = temp.Tip;
            z.KorisnickiNalogID = k.Id;

            db.SaveChanges();
            return RedirectToAction("PrikaziZaposlenika");
        }
        public IActionResult ObrisiZaposlenika(int ZaposlenikId)
        {
            Zaposlenik z = db.Zaposlenik.Find(ZaposlenikId);
            db.Remove(z);
            db.SaveChanges();
            return RedirectToAction("PrikaziZaposlenika");
        }
        public IActionResult UrediZaposlenika(int ZaposlenikId)
        {
            DodajZposlenikaVM Model = new DodajZposlenikaVM();
            Zaposlenik z = new Zaposlenik();
            z = db.Zaposlenik.Find(ZaposlenikId);
            Model.Id = z.Id;
            Model.GradID = z.GradID;
            Model.StrucnaSpremaID = z.StrucnaSpremaID;
            Model.Ime = z.Ime;
            Model.Prezime = z.Prezime;
            Model.MaticniBroj = z.MaticniBroj;
            Model.Spol = z.Spol;
            Model.DatumRodenja = z.DatumRodenja;
            Model.Tip = z.Tip;

            KorisnickiNalog k = db.KorisnickiNalog.Find(z.KorisnickiNalogID);
            Model.KorisnickoIme = k.KorisnickoIme;
            Model.Lozinka = k.Lozinka;


            List<SelectListItem> Gradovi = new List<SelectListItem>();
            Gradovi.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite grad:"
            });

            Gradovi.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv

            }));
            Model.GradoviStavke = Gradovi;
            List<SelectListItem> StrucneSpreme = new List<SelectListItem>();
            StrucneSpreme.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite strucnu spremu:"
            });

            StrucneSpreme.AddRange(db.StrucnaSprema.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv

            }));
            Model.StrucnaSpremaStavke = StrucneSpreme;
            return View(Model);
        }
    }
}