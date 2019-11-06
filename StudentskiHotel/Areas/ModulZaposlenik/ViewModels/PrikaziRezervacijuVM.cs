using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziRezervacijuVM
    {
        public List<Rezervacija> Rezervacije { get; set; }
        public int TuristID { get; set; }
    }
}
