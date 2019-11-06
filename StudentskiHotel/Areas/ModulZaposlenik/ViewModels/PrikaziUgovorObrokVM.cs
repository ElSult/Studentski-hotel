using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziUgovorObrokVM
    {
        public List<UgovorObrok> obrok { get; set; }
        public int ugovorId { get; set; }
        
    }
}
