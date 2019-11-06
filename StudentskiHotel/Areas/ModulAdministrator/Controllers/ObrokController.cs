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
    public class ObrokController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziObroke(int ajax)
        {
            PrikaziObrokVM Model = new PrikaziObrokVM
            {
                Obroci = db.Obrok.Include(x => x.VrstaObroka).ToList()
            };
            if (ajax == 1)
                return PartialView(Model);
            return View(Model);
        }


        public IActionResult DodajObrok()
        {
            DodajObrokVM Model = new DodajObrokVM();

            List<SelectListItem> obroci = new List<SelectListItem>();
            obroci.Add(new SelectListItem() {
                Value = null,
                Text = "Odaberite obrok"
            });
            obroci.AddRange(db.VrstaObroka.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Vrsta.ToString()

            }));
            Model.VrstaObroka = obroci;

            return PartialView(Model);
        }

        bool ProvjeriDuplikat(int vrsta, int id)
        {
            if (db.Obrok.Any(x => x.VrstaObrokaID == vrsta && x.Id != id))
                return false;
            return true;
        }


        public IActionResult SnimiObrok(DodajObrokVM obrok)
        {
            if (!ModelState.IsValid || !ProvjeriDuplikat(obrok.VrstaObrokaID, obrok.Id))
            {

                if (!ProvjeriDuplikat(obrok.VrstaObrokaID, obrok.Id))
                    ViewData["poruka"] = "Obrok je vec odabran, odaberite drugi!";

                List<SelectListItem> vrsteObroka = new List<SelectListItem>();
                vrsteObroka.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite vrstu obroka:"
                });

                vrsteObroka.AddRange(db.VrstaObroka.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Vrsta

                }));

                obrok.VrstaObroka = vrsteObroka;

                return PartialView("UrediObrok", obrok);
            }

            Obrok temp;

            if(obrok.Id == 0)
            {

                temp = new Obrok();
                db.Obrok.Add(temp);
            }
            else
            {
                temp = db.Obrok.Find(obrok.Id);
            }
            temp.VrijemePocetka = obrok.VrijemePocetka;
            temp.VrijemeZavrsetka = obrok.VrijemeZavrsetka;
            temp.BrojObroka = obrok.BrojObroka;
            temp.VrstaObrokaID = obrok.VrstaObrokaID;

            db.SaveChanges();
            return RedirectToAction("PrikaziObroke", new { @ajax=1});
        }
        public IActionResult ObrisiObrok(int Id)
        {
            Obrok o = db.Obrok.Find(Id);
            db.Remove(o);
            db.SaveChanges();

            return RedirectToAction("PrikaziObroke", new { @ajax = 1 });
        }

        public IActionResult UrediObrok(int Id)
        {
            DodajObrokVM Model = new DodajObrokVM();
            Obrok o = new Obrok();
            o = db.Obrok.Find(Id);

            Model.Id = o.Id;
            Model.BrojObroka = o.BrojObroka;
            Model.VrijemePocetka = o.VrijemePocetka;
            Model.VrijemeZavrsetka = o.VrijemeZavrsetka;
            Model.VrstaObrokaID = o.VrstaObrokaID;

            List<SelectListItem> obroci = new List<SelectListItem>();
            obroci.Add(new SelectListItem(){

                Value = null,
                Text = "Odaberite sprat"
            });

            obroci.AddRange(db.VrstaObroka.Select(x => new SelectListItem() {

                Value = x.Id.ToString(),
                Text = x.Vrsta.ToString()
            }));

            Model.VrstaObroka = obroci;


            return PartialView(Model);
        }
    }

 
}