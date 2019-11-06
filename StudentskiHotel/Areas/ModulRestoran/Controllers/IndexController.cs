using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Helper;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    [AutorizacijaAttribute(TipZaposlenika.Konobar)]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}