using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziNacinPlacanjaVM
    {
        public List<NacinPlacanja> NaciniPlacanja { get; set; }
        public string NazivPlacanja { get; set; }
    }
}
