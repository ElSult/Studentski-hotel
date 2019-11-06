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
    public class UgovorObrokController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziUgovorObrok(int ugovorid)
        {
            PrikaziUgovorObrokVM Model = new PrikaziUgovorObrokVM();
            Model.obrok = db.UgovorObrok.Where(x => x.UgovorId == ugovorid).
                Include(x => x.Obrok.VrstaObroka).ToList();
            Model.ugovorId = ugovorid;

           
            return View(Model);
        }
       public IActionResult DodajUO(int ugovorId,int studentId)
        {
            DodajUgovorObrokVM Model = new DodajUgovorObrokVM();
            Model.UgovorId = ugovorId;
            Model.studentId = studentId;
            List<SelectListItem> Obroci = new List<SelectListItem>();
            Obroci.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite obrok"
            });
            Obroci.AddRange(db.Obrok.Select(x=>new SelectListItem()
            {
                Value=x.Id.ToString(),
                Text=x.VrstaObroka.Vrsta
            }));
            Model.obroci = Obroci;
            return View(Model);
        }



        public IActionResult SnimiUO(DodajUgovorObrokVM temp)
        {
            if(!ModelState.IsValid)
            {
                List<SelectListItem> Obroci = new List<SelectListItem>();
                Obroci.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite obrok"
                });
                Obroci.AddRange(db.Obrok.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.VrstaObroka.Vrsta
                }));
                temp.obroci = Obroci;
                return View("DodajUO", temp);
            }
            UgovorObrok novi;
            if (temp.Id == 0)
            {
                novi = new UgovorObrok();
                db.UgovorObrok.Add(novi);
            }
            else
            {
                novi = db.UgovorObrok.Find(temp.Id);
            }

            novi.ObrokId = temp.ObrokId;
            novi.UgovorId = temp.UgovorId;
            db.SaveChanges();

            return RedirectToAction("PrikaziStudentskiUgovor", "StudentskiUgovor", new { StudentId = temp.studentId });
        }
        public IActionResult ObrisiUO(int id)
        {
            UgovorObrok u = db.UgovorObrok.Find(id);
            db.Remove(u);
            db.SaveChanges();
            return RedirectToAction("PrikaziUgovorObrok", new { ugovorId = u.UgovorId });
        }
    }
}