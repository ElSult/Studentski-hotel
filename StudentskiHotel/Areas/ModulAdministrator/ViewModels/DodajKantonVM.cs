using Microsoft.AspNetCore.Mvc;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulAdministrator.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class DodajKantonVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kanton je obavezno polje!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Potrebno unijeti validan naziv kantona!")]
        [RegularExpression(@"^[a-žA-Ž -10]+$", ErrorMessage ="Koristiti samo slova!")]
       
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }
    }
}
