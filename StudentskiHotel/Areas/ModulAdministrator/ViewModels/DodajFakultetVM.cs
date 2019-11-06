using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajFakultetVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Fakultet je obavezno polje!")]
     
      
        [StringLength(60,MinimumLength =5, ErrorMessage ="Potrebno unijeti puni naziv fakulteta!")]
        [RegularExpression(@"^[a-žA-Ž ]+$", ErrorMessage ="Koristiti samo slova!")]
        public string Naziv { get; set; }
    }
}
