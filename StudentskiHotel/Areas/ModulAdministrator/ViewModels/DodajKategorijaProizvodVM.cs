using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajKategorijaProizvodVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Naziv kategorije je obavezno polje!")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Potrebno unijeti ispravan naziv kategorije!")]
        [RegularExpression(@"^[a-žA-Ž ]+$", ErrorMessage = "Koristiti samo slova!")]
        public string NazivKategorije { get; set; }
    }
}
