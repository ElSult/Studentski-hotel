using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulRestoran.ViewModels
{
    public class DodajNarudzbuVM
    {
        public int Id { get; set; }

        public DateTime DatumNarudzbe { get; set; }

        [Required(ErrorMessage = "Nacin placanja je obavezno polje!")]
        public int? NacinPlacanjaID { get; set; }
        public List<SelectListItem> nacinPlacanja { get; set; }

        public int? RacunRestoranID { get; set; }

        public int KategorijaId { get; set; }
        
        [DisplayName("Narudzba zavrsena")]
        public bool Zavrsena { get; set; }
    }
}
