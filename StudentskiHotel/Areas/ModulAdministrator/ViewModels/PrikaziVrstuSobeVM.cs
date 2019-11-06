using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziVrstuSobeVM
    {
        public List<VrstaSobe> VrsteSobe { get; set; }
        public string NazivVrsteSobe { get; set; }
    }
}
