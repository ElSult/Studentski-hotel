using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziRacunRestoranVM
    {
        public List<StavkaRacuna> stavke { get; set; }
        public Narudzba narudzba { get; set; }
        public RacunRestoran racun { get; set; }
    }
}
