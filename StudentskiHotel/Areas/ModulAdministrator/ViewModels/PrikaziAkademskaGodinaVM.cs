using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziAkademskaGodinaVM
    {
        public List<AkademskaGodina> Godine { get; set; }
         public string NazivPretrage { get; set; }
    }
}
