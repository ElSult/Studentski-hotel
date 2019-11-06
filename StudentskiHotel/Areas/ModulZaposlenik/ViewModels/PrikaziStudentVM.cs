using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziStudentVM
    {
        public List<Student> studenti { get; set; }
        public string Prezime { get; set; }
    }
}
