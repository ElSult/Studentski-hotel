using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Kanton
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }
        [ForeignKey(nameof(DrzavaID))]
        public Drzava Drzava { get; set; }
    }
}
