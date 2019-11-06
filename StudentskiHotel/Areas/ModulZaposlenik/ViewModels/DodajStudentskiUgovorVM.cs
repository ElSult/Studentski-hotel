using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajStudentskiUgovorVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Broj kartice je obavezno polje!")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage ="Potrebno unijeti četverocifren broj!")]
        public int? BrojKartice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime UgovorZakljucenDana { get; set; }

        [Required(ErrorMessage = "Mjesečna najamnina je obavezno polje!")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Koristiti samo brojeve!")]
        public float? MjesecnaNajamnina { get; set; }

        public int StudentID { get; set; }
        public bool IsAktivan { get; set; }

       
        public int AkademskaGodinaID { get; set; }
        public IEnumerable<SelectListItem> akGodine { get; set; }

      
        public int SobaID { get; set; }
        public IEnumerable<SelectListItem> sobe { get; set; }

       
        public int ZaposlenikID { get; set; }
        //public IEnumerable<SelectListItem> zaposlenik { get; set; }

       
    }
}