using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajRezervacijuVM
    {
        public int Id { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemeOdlaska { get; set; }
        public int TuristID { get; set; }
        public int NacinPlacanjaID { get; set; }

        public IEnumerable<SelectListItem> NaciniPlacanja { get; set; }

        public int KategorijaID { get; set; }

        public IEnumerable<SelectListItem> Kategorije { get; set; }

        public int ZaposlenikID { get; set; }
       
        public int SobaID { get; set; }
        public IEnumerable<SelectListItem> sobe { get; set; }

        public List<SelectListItem> Usluge { get; set; }

    }
}
