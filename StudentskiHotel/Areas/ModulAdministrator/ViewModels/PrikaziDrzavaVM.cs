using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziDrzavaVM
    {
       public List<Drzava> Drzave { get; set; }
       public string NazivPretraga { get; set; }
    }
}
