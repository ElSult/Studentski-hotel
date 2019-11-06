using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulRestoran.ViewModels;
using StudentskiHotel.Web.Helper;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    [AutorizacijaAttribute(TipZaposlenika.Konobar)]
    public class NarudzbaController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult PrikaziNarudzbu()
        {
            Zaposlenik z = HttpContext.GetLogiraniKorisnik();

            PrikaziNarudzbuVM Model = new PrikaziNarudzbuVM
            {
                narudzbe = db.Narudzba.Include(x => x.NacinPlacanja)
                    .Include(x => x.RacunRestoran)
                    .Where(x => x.ZaposlenikID == z.Id)
                    .OrderByDescending(x => x.DatumNarudzbe).ToList()
            };

            return View(Model);
        }

        public IActionResult DodajNarudzbu()
        {
            DateTime d = DateTime.Now;

            Narudzba temp = new Narudzba
            {
                ZaposlenikID = HttpContext.GetLogiraniKorisnik().Id,
                DatumNarudzbe = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0)
            };

            db.Narudzba.Add(temp);
            db.SaveChanges();

            return Redirect("/ModulRestoran/Narudzba/UrediNarudzbu/" + temp.Id);
            

        }


        public void PripremiCmb(DodajNarudzbuVM Model)
        {
            Model.nacinPlacanja = new List<SelectListItem>();
            Model.nacinPlacanja.AddRange(db.NacinPlacanja.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
        }

        public IActionResult UrediNarudzbu(int Id)
        {
            Narudzba temp = db.Narudzba.Find(Id);
            if (temp == null)
                return RedirectToAction("PrikaziNarudzbu");

            DodajNarudzbuVM Model = new DodajNarudzbuVM
            {
                Id = Id,
                NacinPlacanjaID = temp.NacinPlacanjaID,
                DatumNarudzbe = temp.DatumNarudzbe
            };

            PripremiCmb(Model);

            Model.KategorijaId = db.KategorijaProizvoda.First().ID; // odabir prve dostupne kategorije iz tabele

            return View(Model);
        }
        public IActionResult SnimiNarudzbu(DodajNarudzbuVM novaNarudzba)
        {
            bool ProvjeriStavke(int NarudzbaId)
            {
                if (db.StavkaRacuna.Any(x => x.NarudzbaID == NarudzbaId))
                    return true;
                return false;
            }


            if (!ModelState.IsValid || !ProvjeriStavke(novaNarudzba.Id))
            {

                if (!ProvjeriStavke(novaNarudzba.Id))
                    ViewData["poruka"] = "Narudzba mora imati barem 1 stavku!";

                PripremiCmb(novaNarudzba);

                return View("UrediNarudzbu", novaNarudzba);
            }

            Narudzba temp;
            if(novaNarudzba.Id == 0)
            {
                temp = new Narudzba();
                db.Narudzba.Add(temp);
            }
            else
            {
                temp = db.Narudzba.Find(novaNarudzba.Id);
            }

            temp.DatumNarudzbe = novaNarudzba.DatumNarudzbe;
            temp.NacinPlacanjaID = novaNarudzba.NacinPlacanjaID;  
            temp.ZaposlenikID = HttpContext.GetLogiraniKorisnik().Id;
            temp.Zavrsena = novaNarudzba.Zavrsena;

            // ako je narudzba zavrsena, kreiraj racun
            if (temp.Zavrsena == true)
            {
                float UkupanIznos = 0;

                List<StavkaRacuna> Stavke = db.StavkaRacuna
                    .Include(x => x.Proizvod)
                    .Where(x => x.NarudzbaID == temp.Id).ToList();

                foreach (var Stavka in Stavke)
                {
                    UkupanIznos += Stavka.Proizvod.Cijena * Stavka.Kolicina;
                }

                RacunRestoran racun = new RacunRestoran
                {
                    UkupanIznos = UkupanIznos
                };
                db.RacunRestoran.Add(racun);

                // dodjela racuna narudzbi
                temp.RacunRestoranID = racun.Id;

            }

            db.SaveChanges();

            return RedirectToAction("PrikaziNarudzbu");
        }
        public IActionResult IzbrisiNarudzbu(int Id)
        {
            Narudzba temp = db.Narudzba.Find(Id);
            if(temp != null)
            {
                db.Remove(temp);
                db.SaveChanges();
            }

            return RedirectToAction("PrikaziNarudzbu");
        }

        public IActionResult PrikaziRacunRestoran(int Id)
        {
            Narudzba n = db.Narudzba
                .Include(x => x.Zaposlenik)
                .Include(x => x.NacinPlacanja)
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if(n == null)
                return RedirectToAction("PrikaziNarudzbu");

            PrikaziRacunRestoranVM temp = new PrikaziRacunRestoranVM
            {
                narudzba = n,
                racun = db.RacunRestoran.Find(n.RacunRestoranID),
                stavke = db.StavkaRacuna
                    .Include(x => x.Proizvod)
                    .Where(x => x.NarudzbaID == Id).ToList()
            };

            return View(temp);
        }

    }
}