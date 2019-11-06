using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajVrstuObrokaVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv vrste obroka je obavezno polje!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Potrebno unijeti validan naziv vrste obroka!")]
        public string Vrsta { get; set; }
    }
}
