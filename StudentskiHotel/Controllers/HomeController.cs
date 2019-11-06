using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Models;
using StudentskiHotel.Web.Helper;

namespace StudentskiHotel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null)
            {
                return Redirect("/Autentifikacija");
            }

            TipZaposlenika tip = k.Tip;
            if (tip == TipZaposlenika.Admin)
            {
                return RedirectToAction("Index", "ModulAdministrator/Index");
            }
            else if (tip == TipZaposlenika.Konobar)
            {
                return RedirectToAction("Index", "ModulRestoran/Index");
            }
            else if (tip == TipZaposlenika.Recepcioner)
            {
                return RedirectToAction("Index", "ModulZaposlenik/Index");
            }


            return View();
        }

   
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
