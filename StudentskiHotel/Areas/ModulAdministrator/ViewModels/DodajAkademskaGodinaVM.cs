using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajAkademskaGodinaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Akademska godina je obavezno polje!")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[/]?([0-9]{4})$", ErrorMessage ="Akademska godina je u obliku 0000/2000!")]
      
        public string AkGodina { get; set; }
    }
}
