using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels;
using StudentskiHotel.Web.Helper;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.Controllers
{
    [Area("ModulZaposlenik")]
    [AutorizacijaAttribute(TipZaposlenika.Recepcioner)]
    public class RezervacijaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziRezervaciju()
        {
            PrikaziRezervacijuVM Model = new PrikaziRezervacijuVM();
            Model.Rezervacije = db.Rezervacija.
                Include(x => x.Soba).
                Include(x => x.Turist).
                Include(x => x.Zaposlenik).Include(x=>x.NacinPlacanja).Include(x=>x.Kategorija).ToList();
           // Model.TuristID = TuristId;
            return View(Model);
        }

        public IActionResult DodajRezervaciju(int TuristId)
        {
            DodajRezervacijuVM Model = new DodajRezervacijuVM();
            Model.TuristID = TuristId;

            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

            Model.VrijemeDolaska = Model.VrijemeOdlaska = hm;

            List<SelectListItem> naciniPlacanja = new List<SelectListItem>();
            naciniPlacanja.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite nacin placanja:"
            });
            naciniPlacanja.AddRange(db.NacinPlacanja.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv

            }));
            Model.NaciniPlacanja = naciniPlacanja;


            List<SelectListItem> kategorija = new List<SelectListItem>();
            kategorija.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite kategoriju:"
            });
            kategorija.AddRange(db.Kategorija.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM"

            }));
            Model.Kategorije = kategorija;

            List<SelectListItem> Sobe = new List<SelectListItem>();
            Sobe.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite sobu:"
            });
            Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSobe.ToString() +" - "+ x.VrstaSobe.Cijena.ToString("0.00") + "KM"

            }));
            Model.sobe = Sobe;


            List<SelectListItem> Usluge = new List<SelectListItem>();
            Usluge.AddRange(db.Usluga.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM"

            }));
            Model.Usluge = Usluge;

            return View(Model);
        }
        public IActionResult UrediRezervaciju(int RezervacijaId)
        {
            Rezervacija r = db.Rezervacija.Find(RezervacijaId);

            DodajRezervacijuVM Model = new DodajRezervacijuVM();
            Model.Id = r.Id;
            Model.TuristID = r.TuristID;

            Model.VrijemeDolaska = r.VrijemeDolaska;
            Model.VrijemeOdlaska = r.VrijemeOdlaska;

            Model.NacinPlacanjaID = r.NacinPlacanjaID;
            Model.KategorijaID = r.KategorijaID;
            Model.SobaID = r.SobaID;

            

            List<SelectListItem> naciniPlacanja = new List<SelectListItem>();
            naciniPlacanja.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite nacin placanja:"
            });
            naciniPlacanja.AddRange(db.NacinPlacanja.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv

            }));
            Model.NaciniPlacanja = naciniPlacanja;


            List<SelectListItem> kategorija = new List<SelectListItem>();
            kategorija.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite kategoriju:"
            });
            kategorija.AddRange(db.Kategorija.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM"

            }));
            Model.Kategorije = kategorija;

            List<SelectListItem> Sobe = new List<SelectListItem>();
            Sobe.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite sobu:"
            });
            Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSobe.ToString()

            }));
            Model.sobe = Sobe;


            List<SelectListItem> Usluge = new List<SelectListItem>();
            Usluge.AddRange(db.Usluga.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM"

            }));
            Model.Usluge = Usluge;

            return View(Model);
        }
        public IActionResult PrikaziRacun(int RezervacijaId)
        {
            PrikaziRacunVM Model = new PrikaziRacunVM();

            Model.rezervacija = db.Rezervacija
                .Include(x => x.Kategorija)
                .Include(x => x.Zaposlenik)
                .Include(x => x.NacinPlacanja)
                .Include(x => x.Soba)
                .ThenInclude(x=>x.VrstaSobe)
                .Include(x => x.Turist)
                .Where(x => x.Id == RezervacijaId)
                .First();

           Model.odabraneUsluge = db.OdabranaUsluga
                .Include(x => x.Usluga)
                .Where(x => x.RezervacijaID == RezervacijaId).ToList();
           Model.racun = db.Racun.Where(x => x.RezervacijaID == RezervacijaId).FirstOrDefault() ?? null;
            
            Model.trajanje = (Model.rezervacija.VrijemeOdlaska - Model.rezervacija.VrijemeDolaska).Days;

           return View(Model);
        }
        public IActionResult InformacijeORezervaciji(int turistId)
        {
            PrikaziRezervacijuVM Model = new PrikaziRezervacijuVM();
            Model.Rezervacije = db.Rezervacija.
                Include(x => x.Soba).
                Include(x => x.Turist).
                Include(x => x.Zaposlenik).Include(x => x.NacinPlacanja).Include(x => x.Kategorija).Where(x=>x.TuristID==turistId).ToList();

            return View(Model);
        }
        public IActionResult SnimiRezervaciju(DodajRezervacijuVM temp, int[] OdabraneUsluge)
        {
            bool provjeriSobu(int brojSobe,int id)
            {
                Rezervacija rez = db.Rezervacija.LastOrDefault(x => x.SobaID == brojSobe && x.Id != id);
             
                if (rez is null || rez.VrijemeOdlaska < temp.VrijemeDolaska) {
                    return true;
                }
                    return false;
            }
            Zaposlenik z = HttpContext.GetLogiraniKorisnik();

            if (!ModelState.IsValid || !provjeriSobu(temp.SobaID,temp.Id))
            {
             
                List<SelectListItem> naciniPlacanja = new List<SelectListItem>();
                naciniPlacanja.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite nacin placanja:"
                });
                naciniPlacanja.AddRange(db.NacinPlacanja.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                temp.NaciniPlacanja = naciniPlacanja;


                List<SelectListItem> kategorija = new List<SelectListItem>();
                kategorija.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite kategoriju:"
                });
                kategorija.AddRange(db.Kategorija.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM"

                }));
                temp.Kategorije = kategorija;

                List<SelectListItem> Sobe = new List<SelectListItem>();
                Sobe.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite sobu:"
                });
                Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.BrojSobe.ToString()

                }));
                temp.sobe = Sobe;

                List<SelectListItem> Usluge = new List<SelectListItem>();
                Usluge.AddRange(db.Usluga.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv + " - " + x.Cijena.ToString("0.00") + " KM",
                    Selected = OdabraneUsluge.Any(a => a == x.Id)

                }));
                temp.Usluge = Usluge;
                if (!provjeriSobu(temp.SobaID, temp.Id))
                    ViewData["poruka"] = db.Soba.Where(x=>x.Id==temp.SobaID).SingleOrDefault().BrojSobe + " je zauzeta, odaberite drugu!";

                
                return View("UrediRezervaciju", temp);
            }
            Rezervacija r;
            if (temp.Id == 0)
            {
                r = new Rezervacija();
                db.Rezervacija.Add(r);
            }
            else
            {
                r = db.Rezervacija.Find(temp.Id);
            }

            r.TuristID = temp.TuristID;

            r.VrijemeDolaska = temp.VrijemeDolaska;
            r.VrijemeOdlaska = temp.VrijemeOdlaska;
            r.NacinPlacanjaID=temp.NacinPlacanjaID;
            r.SobaID = temp.SobaID;
            r.KategorijaID = temp.KategorijaID;
            r.ZaposlenikID = z.Id;//uzeti iz sesije

            float ukupno = 0;
            int trajanje = 0;
            trajanje = (r.VrijemeOdlaska - r.VrijemeDolaska).Days;

            Kategorija kat = db.Kategorija.Where(x => x.Id == r.KategorijaID).First();
            ukupno += kat.Cijena;
            Soba s = db.Soba.Include(x=>x.VrstaSobe).Where(x => x.Id == r.SobaID).First();
            ukupno += s.VrstaSobe.Cijena;
            
            for (int i = 0; i < OdabraneUsluge.Count(); i++)
            {
                Usluga u = db.Usluga.Find(OdabraneUsluge[i]);

                if (u == null)
                    continue;

                ukupno += u.Cijena;

                OdabranaUsluga o = new OdabranaUsluga();
                o.RezervacijaID = r.Id;
                o.UslugaID = OdabraneUsluge[i];
                db.OdabranaUsluga.Add(o);
            }
            
            Racun racun = new Racun();
            racun.RezervacijaID = r.Id;
       
                racun.Iznos = ukupno * trajanje;
      
            racun.DatumUplate = r.VrijemeDolaska;
            db.Racun.Add(racun);

            db.SaveChanges();
            return RedirectToAction("PrikaziRezervaciju");
        }
    }
}