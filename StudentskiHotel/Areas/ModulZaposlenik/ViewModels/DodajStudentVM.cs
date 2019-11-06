using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajStudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ime je obavezno polje!")]
        [RegularExpression(@"^[a-žA-Ž]+$", ErrorMessage ="Koristiti samo slova!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Nije moguće unijeti jedno slovo!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        [RegularExpression(@"^[a-žA-Ž]+$", ErrorMessage = "Koristiti samo slova!")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Nije moguće unijeti jedno slovo!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ime oca je obavezno polje!")]
        [RegularExpression(@"^[a-žA-Ž]+$", ErrorMessage = "Koristiti samo slova!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Nije moguće unijeti jedno slovo!")]
        public string ImeOca { get; set; }

        [Required(ErrorMessage ="Kontakt telefon je obavezno polje!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[/]?([0-9]{3})[-]?([0-9]{3})$", ErrorMessage ="Kontakt telefon nije validan (000/000-000)!")]
        public string KontaktTelefon { get; set; }

        [Required(ErrorMessage ="Matični broj je obavezno polje!")]
        [StringLength(13, MinimumLength =13, ErrorMessage ="Matični broj mora imati 13 karaktera!")]
        [RegularExpression(@"[0-9]+", ErrorMessage ="Matični broj mora sadržavati samo brojeve!")]
        public string MaticniBroj { get; set; }

        [Required(ErrorMessage ="Spol je obavezno polje!")]
        public Gender Spol { get; set; }

        public bool IsAktivan { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Format uzima sa sistemskog vremena
        public DateTime DatumRodenja { get; set; }

       
        public int GodinaStudijaID { get; set; }  
       public IEnumerable<SelectListItem> GodineStudija { get; set; }

       
        public int GradID { get; set; }     
       public IEnumerable<SelectListItem> Gradovi { get; set; }

       
        public int FakultetID { get; set; } 
        public IEnumerable<SelectListItem> Fakulteti { get; set; }
    }
}
