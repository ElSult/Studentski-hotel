using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajDrzavaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Država je obavezno polje!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Potrebno unijeti validan naziv države!")]
        [RegularExpression(@"^[a-žA-Ž ]+$", ErrorMessage ="Koristiti samo slova!")]
       
        public string Naziv { get; set; }
    }
}
