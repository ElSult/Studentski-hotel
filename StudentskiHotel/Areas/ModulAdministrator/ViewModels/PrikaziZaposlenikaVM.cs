using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziZaposlenikaVM
    {
        public List<Zaposlenik> zaposlenici { get; set; }
        public string prezime { get; set; }
    }
}
