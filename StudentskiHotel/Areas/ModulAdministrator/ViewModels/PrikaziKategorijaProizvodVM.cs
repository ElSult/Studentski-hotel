using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziKategorijaProizvodVM
    {
        public List<KategorijaProizvoda> kategorijeProizvoda { get; set; }
        public string NazivKategorije { get; set; }
    }
}
