using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.Controllers
{
    [Area("ModulZaposlenik")]
    [AutorizacijaAttribute(TipZaposlenika.Recepcioner)]
    public class TuristController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziTurista(string prezime)
        {
            PrikaziTuristaVM Model = new PrikaziTuristaVM();
            Model.turisti = db.Turist.Include(m => m.Drzava).Where(x => x.Prezime.Contains(prezime) || prezime == null).ToList();
            return View(Model);
        }
        public IActionResult DodajTurista()
        {
            DodajTuristaVM Model = new DodajTuristaVM();

            List<SelectListItem> Dstavke = new List<SelectListItem>();

            Dstavke.Add(new SelectListItem()
            {
                Value=null,
                Text="Odaberite drzavu"
            });

            Dstavke.AddRange(db.Drzava.Select( x => new SelectListItem()
                {
                Value=x.Id.ToString(),
                Text=x.Naziv
                }));


            Model.Drzave = Dstavke;
            return View(Model);
        }
        public IActionResult SnimiTurista(DodajTuristaVM temp)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> Dstavke = new List<SelectListItem>();
                Dstavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite drzavu"
                });

                Dstavke.AddRange(db.Drzava.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }));
                temp.Drzave = Dstavke;
                return View("UrediTurista", temp);
            
            }
            Turist t;
            if (temp.Id == 0)
            {
                t = new Turist();
                db.Turist.Add(t);
            }
            else
            {
                t = db.Turist.Find(temp.Id);
            }
            t.Ime = temp.Ime;
            t.Prezime = temp.Prezime;
            t.BrojPasosa = temp.BrojPasosa;
            t.KontaktTelefon = temp.KontaktTelefon;
            t.DrzavaID = temp.DrzavaID;
            db.SaveChanges();

            return RedirectToAction("DodajRezervaciju", "Rezervacija", new { turistId=t.Id});
        }
        public IActionResult UrediTurista(int turistId)
        {
            DodajTuristaVM Model = new DodajTuristaVM();

            Turist t = new Turist();
            t = db.Turist.Find(turistId);

            Model.Id = t.Id;
            Model.Ime = t.Ime;
            Model.Prezime = t.Prezime;
            Model.BrojPasosa = t.BrojPasosa;
            Model.KontaktTelefon = t.KontaktTelefon;
            Model.DrzavaID = t.DrzavaID;

            List<SelectListItem> Dstavke = new List<SelectListItem>();

            Dstavke.Add(new SelectListItem()
            {
             Value=null,
             Text="Odaberi drzavu"
            });
            Dstavke.AddRange(db.Drzava.Select(x => new SelectListItem() {
                Value = x.Id.ToString(),
            Text=x.Naziv
            }));
            Model.Drzave = Dstavke;
            return View(Model);
        }
    }
}