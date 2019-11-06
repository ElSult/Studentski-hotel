using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziUsluguVM
    {
        public List<Usluga> Usluge { get; set; }
        public string NazivUsluge { get; set; }
    }
}
