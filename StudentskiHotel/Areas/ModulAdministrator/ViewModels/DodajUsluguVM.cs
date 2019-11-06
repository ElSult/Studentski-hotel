using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajUsluguVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv usluge je obavezno polje!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Potrebno unijeti validan naziv usluge!")]
        [RegularExpression(@"^[a-ž A-Ž]+$", ErrorMessage = "Koristiti samo slova!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Cijena je obavezno polje!")]
        [Range(0.01, float.PositiveInfinity, ErrorMessage = "Cijena ne moze biti nula!")]
        public float Cijena { get; set; }
    }
}
