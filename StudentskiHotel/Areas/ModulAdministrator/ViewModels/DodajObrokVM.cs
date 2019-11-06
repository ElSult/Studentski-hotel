using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajObrokVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno polje za broj obroka!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Dozvoljen unos samo brojeva!")]
        public int BrojObroka { get; set; }


        [DataType(DataType.Time)] public TimeSpan VrijemePocetka { get; set; }

        [DataType(DataType.Time)] public TimeSpan VrijemeZavrsetka { get; set; }

        [Required(ErrorMessage = "Odabir vrste obroka je obavezano!")]
        public int VrstaObrokaID { get; set; }
        public IEnumerable<SelectListItem> VrstaObroka { get; set; }
    }
}
