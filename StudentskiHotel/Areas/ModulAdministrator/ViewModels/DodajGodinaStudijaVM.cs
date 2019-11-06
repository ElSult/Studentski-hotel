using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajGodinaStudijaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Godina studija je obavezno polje!")]
        [RegularExpression(@"[1-6]", ErrorMessage ="Godina studija ne smije biti manja od 1 ili veća od 6!")]
          
        public int? Naziv { get; set; }
    }
}
