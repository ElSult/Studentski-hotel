using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajSpratVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Broj sprata je obavezan")]
        [Range(0, 1000)]
        public int? BrojSprata { get; set; }
    }
}