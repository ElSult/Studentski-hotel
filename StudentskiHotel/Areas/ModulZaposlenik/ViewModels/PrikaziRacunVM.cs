using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziRacunVM
    {
        public List<OdabranaUsluga> odabraneUsluge { get; set; }
        public Rezervacija rezervacija { get; set; }
        public Racun racun { get; set; }

        public int trajanje { get; set; }
    }
}
