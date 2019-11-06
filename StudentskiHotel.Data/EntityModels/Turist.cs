using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Turist
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojPasosa { get; set; }
        public string KontaktTelefon { get; set; }

        public int DrzavaID { get; set; }
        [ForeignKey(nameof(DrzavaID))]
        public Drzava Drzava { get; set; }
    }
}
