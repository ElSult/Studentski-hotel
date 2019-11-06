using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajVrstuSobeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tip sobe mora biti unesen")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Tip sobe moze sadrzavati samo velika i mala slova")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "Cijena je obavezno polje!")]
        [Range(0.01, float.PositiveInfinity, ErrorMessage = "Cijena ne moze biti nula!")]
        public float Cijena { get; set; }

    }
}