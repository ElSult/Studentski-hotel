using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziVrstuObrokaVM
    {
        public List<VrstaObroka> VrsteObroka { get; set; } 
        public string NazivVrste { get; set; }
    }
}
