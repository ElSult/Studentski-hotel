using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class DodajUgovorObrokVM
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public int UgovorId { get; set; }

      
        public int ObrokId { get; set; }
        public IEnumerable<SelectListItem> obroci { get; set; }
    }
}
