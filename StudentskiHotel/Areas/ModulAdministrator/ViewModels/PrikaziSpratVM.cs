using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziSpratVM
    {
       public List<Sprat> Spratovi { get; set; }
        public int ?NazivSprata { get; set; }
    }
}
