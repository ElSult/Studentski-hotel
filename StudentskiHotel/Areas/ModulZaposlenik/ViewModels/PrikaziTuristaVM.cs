using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziTuristaVM
    {
        public List<Turist> turisti { get; set; }
        public string prezime { get; set; }
    }
}
