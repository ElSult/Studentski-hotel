using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziStrucnuSpremuVM
    {
        public List <StrucnaSprema> StrucneSpreme { get; set; }
        public string NazivStrucneSpreme { get; set; }
    }
}
