using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajOdabranuUsluguVM
    {
        public int Id { get; set; }
 
        public int RezervacijaID { get; set; }
        //public int Cijena { get; set; }
        public int UslugaID { get; set; }
        public IEnumerable<SelectListItem> Usluge { get; set; }
    }
}
