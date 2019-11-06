using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziFakultetVM
    {
        public List<Fakultet> Fakulteti { get; set; }
       public string NazivPretraga { get; set; }

       
    }
}
