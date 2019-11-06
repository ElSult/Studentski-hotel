using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [AutorizacijaAttribute(TipZaposlenika.Admin)]
    public class FakultetController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult DodajFakultet()
        {
            DodajFakultetVM Model = new DodajFakultetVM();

            return PartialView(Model);
        }



    
        public IActionResult PrikaziFakultet(string nazivPretraga, int ajax)
        {
            PrikaziFakultetVM Model = new PrikaziFakultetVM
            {
                Fakulteti = db.Fakultet.Where(x => x.Naziv.Contains(nazivPretraga) || nazivPretraga == null).ToList()
            };


            if (ajax == 1)
                return PartialView(Model);

            return View(Model);
        }


        bool ProvjeriDuplikate(string Naziv, int id)
        {
            if (db.Fakultet.Any(x => x.Naziv == Naziv && x.Id != id))
            {

                return false;
            }

            return true;
        }

        public IActionResult SnimiFakultet(DodajFakultetVM temp )
        {
            
            if (!ModelState.IsValid || !ProvjeriDuplikate(temp.Naziv, temp.Id))
            {
                if (!ProvjeriDuplikate(temp.Naziv, temp.Id))
                    ViewData["poruka"] =temp.Naziv+" je već unesen!";

                return PartialView("UrediFakultet", temp); //Kada udej u ovaj dio koda, ne radi ajax
                
            }

            Fakultet f;
            if(temp.Id==0)
            {
                f = new Fakultet();
                db.Fakultet.Add(f);
            }
            else
            {
                f = db.Fakultet.Find(temp.Id);
            }
            f.Naziv = temp.Naziv;
            db.SaveChanges();
            return RedirectToAction("PrikaziFakultet", new { @ajax = 1 });
        }
        public IActionResult ObrisiFakultet(int FakultetId)
        {
            Fakultet f = db.Fakultet.Find(FakultetId);
            db.Remove(f);
            db.SaveChanges();
            return RedirectToAction("PrikaziFakultet", new { @ajax = 1 });
        }
        public IActionResult UrediFakultet(int FakultetId)
        {
            DodajFakultetVM Model = new DodajFakultetVM();
            Fakultet f = new Fakultet();
            f = db.Fakultet.Find(FakultetId);

            Model.Id = f.Id;
            Model.Naziv = f.Naziv;

            return PartialView(Model);
        }
   
    }
}