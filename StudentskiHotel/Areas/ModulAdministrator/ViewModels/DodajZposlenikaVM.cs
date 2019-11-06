using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajZposlenikaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ime je obavezno")]
        [RegularExpression(@"^([A-Za-z]+)$",ErrorMessage ="Ime moze sadrzavati samo velika i mala slova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Prezime moze sadrzavati samo velika i mala slova")]

        public string Prezime { get; set; }

        [Required(ErrorMessage = "Maticni broj je obavezan")]
        [StringLength(13, MinimumLength = 13, ErrorMessage ="Maticni broj mora imati 13 karaktera")]
        [RegularExpression(@"^([0-9]+)$", ErrorMessage = "Maticni broj moze sadrzavati samo brojeve")]
        public string MaticniBroj { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumRodenja { get; set; }
        public Gender Spol { get; set; }

        [Required(ErrorMessage = "Odabir grada je obavezan")]
        public int GradID { get; set; }
        public IEnumerable<SelectListItem> GradoviStavke { get; set; }

        [Required(ErrorMessage = "Odabir strucne spreme je obavezan")]
        public int StrucnaSpremaID { get; set; }
        public IEnumerable<SelectListItem> StrucnaSpremaStavke { get; set; }

        [Required(ErrorMessage = "Odabir tipa zaposlenika je obavezan")]
        public TipZaposlenika Tip{ get; set; }

        [Required(ErrorMessage = "Korisnicko ime je obavezno")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Lozinka { get; set; }

    }

}
