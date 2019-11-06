using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziKategorijuVM
    {
        public List<Kategorija> Kategorije { get; set; }
        public string NazivKategorije { get; set; }
    }
}
