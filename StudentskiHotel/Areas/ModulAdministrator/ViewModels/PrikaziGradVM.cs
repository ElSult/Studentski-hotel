using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziGradVM
    {
        public List<Grad> gradovi { get; set; }
        public int Kantonid { get; set; }
        public string nazivPretrage { get; set; }
        public int drzavaId { get; set; }
    }
}
