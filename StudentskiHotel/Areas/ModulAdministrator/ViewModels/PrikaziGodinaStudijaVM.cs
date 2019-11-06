using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziGodinaStudijaVM
    {
       public List<GodinaStudija> GodineStudija { get; set; }
        public int? godina { get; set; }
    }
}
