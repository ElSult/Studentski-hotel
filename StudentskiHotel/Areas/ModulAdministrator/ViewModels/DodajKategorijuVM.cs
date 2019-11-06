using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajKategorijuVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Naziv kategorije je obavezan")]
        [RegularExpression(@"^[a-žA-Ž ]+$", ErrorMessage = "Naziv treba sadrzavati velika i mala slova")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Cijena je obavezno polje!")]
        [Range(0.01, float.PositiveInfinity, ErrorMessage = "Cijena ne moze biti nula!")]
        public float? Cijena { get; set; }
    }
}
