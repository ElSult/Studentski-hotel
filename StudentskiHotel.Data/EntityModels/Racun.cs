using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Racun
    {
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public float Iznos { get; set; }

        public int RezervacijaID { get; set; }
        [ForeignKey(nameof(RezervacijaID))]
        public Rezervacija Rezervacija { get; set; }
    }
}
