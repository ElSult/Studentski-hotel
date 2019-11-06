using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels
{
    public class PrikaziStudentskiUgovorVM
    {
        public List<StudentskiUgovor> ugovori { get; set; }
        public int studentId { get; set; }
    }
}
