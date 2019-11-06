using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziKantonVM
    {
        public List<Kanton> kantoni { get; set; }
        public string nazivPretrage { get; set; }
        public int drzavaId { get; set; }
    }
}
