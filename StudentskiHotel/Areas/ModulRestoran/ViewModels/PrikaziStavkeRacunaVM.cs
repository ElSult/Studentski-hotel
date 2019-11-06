using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziStavkeRacunaVM
    {
        public List<StavkaRacuna> _stavkeRacuna { get; set; }

        public int KategorijaId { get; set; }
        public List<SelectListItem> _kategorije { get; set; }

        public int NarudzbaId { get; set; }

        public List<Proizvod> _proizvodi { get; set; }

        public float UkupniIznos { get; set; } = 0;
    }
}
