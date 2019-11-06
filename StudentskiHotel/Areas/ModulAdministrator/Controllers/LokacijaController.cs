using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Data;
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class LokacijaController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult PrikaziDrzava(string nazivPretraga, int ajax)
        {
            PrikaziDrzavaVM Model = new PrikaziDrzavaVM
            {
                Drzave = db.Drzava.Where(x => x.Naziv.Contains(nazivPretraga) || nazivPretraga == null).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }

        public IActionResult DodajDrzava()
        {
            DodajDrzavaVM Model = new DodajDrzavaVM();
            return PartialView(Model);
        }
       
       
       
        public IActionResult UrediDrzavu(int DrzavaId)
        {
            DodajDrzavaVM Model = new DodajDrzavaVM();
            Drzava d = new Drzava();
            d = db.Drzava.Find(DrzavaId);
            Model.Id = d.Id;
            Model.Naziv = d.Naziv;
            return PartialView(Model);
        }
        public IActionResult ObrisiDrzava(int DrzavaId)
        {
            Drzava d = db.Drzava.Find(DrzavaId);
            db.Remove(d);
            db.SaveChanges();

            return RedirectToAction("PrikaziDrzava", new { @ajax = 1 });
        }

        bool ProvjeriDuplikatDrzava(string naziv, int id)
        {
            if (db.Drzava.Any(x => x.Naziv == naziv && x.Id != id))
                return true;
            return false;
        }

        public IActionResult SnimiDrzava(DodajDrzavaVM temp)
        {
          
            if (!ModelState.IsValid || ProvjeriDuplikatDrzava(temp.Naziv, temp.Id))
            {
                if (ProvjeriDuplikatDrzava(temp.Naziv, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesena!";

                return PartialView("UrediDrzavu", temp);
            }
            Drzava nova;
            if (temp.Id == 0)
            {
                nova = new Drzava();
                db.Drzava.Add(nova);
            }
            else
            {
                nova = db.Drzava.Find(temp.Id);
            }
          
            nova.Naziv = temp.Naziv;

            db.SaveChanges();

            return RedirectToAction("PrikaziDrzava", new { @ajax = 1 });
        }
        public IActionResult DodajKanton(int drzavaId)
        {
            DodajKantonVM Model = new DodajKantonVM
            {
                DrzavaID = drzavaId
            };
            return PartialView(Model);
        }
        public IActionResult SnimiKanton(DodajKantonVM temp)
        {
           bool ProvjeriDuplikatKanton(string naziv, int id)
            {
                if (db.Kanton.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikatKanton(temp.Naziv, temp.Id))
            {
                if (ProvjeriDuplikatKanton(temp.Naziv, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesen!";
                return PartialView("UrediKanton", temp);
            }
            Kanton k;
            if(temp.Id==0)
            {
                k = new Kanton();
                db.Kanton.Add(k);
            }
            else
            {
                k = db.Kanton.Find(temp.Id);
            }

          
            k.DrzavaID =temp.DrzavaID ;
            k.Naziv = temp.Naziv;
            db.SaveChanges();
            return RedirectToAction("PrikaziKanton", new { DrzavaId = k.DrzavaID , @ajax=1});
        }
        public IActionResult PrikaziKanton(int DrzavaId, string nazivPretrage, int ajax)
        {
            PrikaziKantonVM Model = new PrikaziKantonVM
            {
                drzavaId = DrzavaId,  //ako trenutno nema kantona u drzavi, uzimamo id od drzave
                kantoni = db.Kanton.Where(x => (x.DrzavaID == DrzavaId && (x.Naziv.Contains(nazivPretrage) || nazivPretrage == null))).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
        public IActionResult ObrisiKanton(int id)
        {
            Kanton k = db.Kanton.Find(id);
            db.Remove(k);
            db.SaveChanges();
            return RedirectToAction("PrikaziKanton", new { DrzavaId = k.DrzavaID,  @ajax = 1  });
        }
        public IActionResult UrediKanton(int id)
        {
            DodajKantonVM Model = new DodajKantonVM();
            Kanton k = new Kanton();

            k = db.Kanton.Find(id);

            Model.DrzavaID = k.DrzavaID;
            Model.Id = k.Id;
            Model.Naziv = k.Naziv;
           
            return PartialView(Model);
        }

        public IActionResult PrikaziGrad(int kantonID, string nazivPretrage, int ajax)
        {
            PrikaziGradVM Model = new PrikaziGradVM
            {
                Kantonid = kantonID,
                gradovi = db.Grad.Where(x => x.KantonID == kantonID && (x.Naziv.Contains(nazivPretrage) || nazivPretrage == null)).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }
       public IActionResult DodajGrad(int kantonID)
        {
            DodajGradVM Model = new DodajGradVM
            {
                KantonID = kantonID
            };
            return PartialView(Model);
        }
        public IActionResult SnimiGrad(DodajGradVM temp)
        {
            bool ProvjeriDuplikatGrad(string naziv, int id)
            {
                if (db.Grad.Any(x => x.Naziv == naziv && x.Id != id))
                    return true;
                return false;
            }
            if (!ModelState.IsValid || ProvjeriDuplikatGrad(temp.Naziv, temp.Id))
            {
                if (ProvjeriDuplikatGrad(temp.Naziv, temp.Id))
                    ViewData["poruka"] = temp.Naziv + " je već unesen!";
                return PartialView("UrediGrad", temp);
            }
            Grad g;
            if(temp.Id==0)
            {
                g = new Grad();
                db.Grad.Add(g);
            }
            else
            {
                g = db.Grad.Find(temp.Id);
            }
            g.Naziv = temp.Naziv;
            g.KantonID = temp.KantonID;
            db.SaveChanges();
            return RedirectToAction("PrikaziGrad",new { kantonID=g.KantonID,  @ajax = 1  });
        }
        public IActionResult ObrisiGrad(int gradid)
        {
            Grad g = db.Grad.Find(gradid);
            db.Remove(g);
            db.SaveChanges();
            return RedirectToAction("PrikaziGrad", new { kantonID = g.KantonID,  @ajax = 1  });
        }
        public IActionResult UrediGrad(int gradid)
        {
            DodajGradVM Model = new DodajGradVM();
            Grad g = new Grad();
            g = db.Grad.Find(gradid);

            Model.Id = g.Id;
            Model.KantonID = g.KantonID;
            Model.Naziv = g.Naziv;
           
            return PartialView(Model);
        }
    }
}