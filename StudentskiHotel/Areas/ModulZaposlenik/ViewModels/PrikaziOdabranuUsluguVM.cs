using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziOdabranuUsluguVM
    {
        public List<OdabranaUsluga> odabraneUsluge { get; set; }
        public int RezervacijaID { get; set; }
    }
}
