using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajTuristaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ime je obavezno")]
        [RegularExpression(@"^([a-zA-Z ]+)$", ErrorMessage = "Ime moze sadrzavati samo velika i mala slova")]
        public string Ime { get; set; }
        [Required(ErrorMessage="Prezime je obavezno")]
        [RegularExpression(@"^([a-zA-z ]+)$",ErrorMessage ="Prezime moze sadrzavati samo velika i mala slova")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Broj pasosa je obavezan")]
        public string BrojPasosa { get; set; }
        [Required(ErrorMessage = "Kontakt telefon je obavezan")]
        [Phone]
        public string KontaktTelefon { get; set; }
        [Required(ErrorMessage = "Odabir drzave je obavezan")]
        public int DrzavaID { get; set; }
        public IEnumerable<SelectListItem> Drzave { get; set; }
    }
}
