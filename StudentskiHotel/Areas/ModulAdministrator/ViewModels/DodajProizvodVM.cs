using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajProizvodVM
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-žA-Ž ]+$", ErrorMessage = "Koristiti samo slova!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Potrebno unijeti validan naziv vrste obroka!")]
        [Required(ErrorMessage = "Naziv proizvoda je obavezno polje!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage ="Cijena je obavezno polje!")]
        [Range(0.01, float.PositiveInfinity, ErrorMessage ="Cijena ne moze biti nula!")]
        public float Cijena { get; set; }

        [Required(ErrorMessage ="Obavezno odabrati kategoriju proizvoda!")]
        public int? KategorijaID { get; set; }
        public IEnumerable<SelectListItem> Kategorija { get; set; }
    }
}
