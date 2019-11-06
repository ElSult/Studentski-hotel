using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajSobuVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezan broj sobe!")]
        [Range(100, 400, ErrorMessage = "Broj sobe mora biti u rangu od 100-400!")]
        public int? BrojSobe { get; set; }
        //zabraniti dupliciranje iste sobe

        public bool Balkon { get; set; }
        public bool TV { get; set; }

        [Required(ErrorMessage = "Odabir sprata je obavezan!")]
        public int SpratId { get; set; }
        public IEnumerable<SelectListItem> Spratovi { get; set; }

        [Required(ErrorMessage = "Odabir vrste sobe je obavezan!")]
        public int VrstaSobeId { get; set; }
        public IEnumerable<SelectListItem> VrsteSoba { get; set; }
    }
}
