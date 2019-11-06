using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajStrucnuSpremuVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Naziv strucne spreme mora biti unesen")]
        [RegularExpression(@"^[A-Ža-ž ]+$", ErrorMessage = "Naziv strucne spreme moze sadrzavati samo velika, mala slova i razmak")]
        public string Naziv { get; set; }
    }
}
