using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziProizvodVM
    {
        public List<Proizvod> Proizvodi { get; set; }
        public string NazivProizvoda { get; set; }
    }
}
