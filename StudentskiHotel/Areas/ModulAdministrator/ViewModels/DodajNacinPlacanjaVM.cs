using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajNacinPlacanjaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Naziv nacina placanja je obavezan")]
        [RegularExpression(@"^[A-Ža-ž]+$", ErrorMessage = "Nacin placanja moze sadrzavati samo velika i mala slova")]
        public string Naziv { get; set; }
    }
}
