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
    public class OdabranaUslugaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziOdabranuUslugu()
        {
            PrikaziOdabranuUsluguVM Model = new PrikaziOdabranuUsluguVM();
            Model.odabraneUsluge = db.OdabranaUsluga.Include(x => x.Usluga).ToList();
            //Model.RezervacijaID = rezervacijaID;

            return View(Model);
        }
        public IActionResult DodajOdabranuUslugu(int rezervacijaId)
        {
            DodajOdabranuUsluguVM Model = new DodajOdabranuUsluguVM();
            Model.RezervacijaID = rezervacijaId;
            List<SelectListItem> OdabraneUsluge = new List<SelectListItem>();
            OdabraneUsluge.Add(new SelectListItem()
            {
                Value=null,
                Text="Odaberi uslugu"
            });
            OdabraneUsluge.AddRange(db.Usluga.Select(x => new SelectListItem()
            {
              Value=x.Id.ToString(),
              Text=x.Naziv

            }));
            Model.Usluge = OdabraneUsluge;
            return View(Model);
        }
        public IActionResult SnimiOdabranuUslugu(DodajOdabranuUsluguVM temp)
        {
            OdabranaUsluga nova;
            if (temp.Id == 0)
            {
                nova = new OdabranaUsluga();
                db.OdabranaUsluga.Add(nova);

            }
            else
            {
                nova = db.OdabranaUsluga.Find(temp.Id);
            }
            nova.RezervacijaID = temp.RezervacijaID;
            nova.UslugaID = temp.UslugaID;
            //nova.Cijena = db.Usluga.Where(x => x.Id == temp.UslugaID).Single().Cijena;
            db.SaveChanges();
            return RedirectToAction("PrikaziOdabranuUslugu");
        }
    }
}